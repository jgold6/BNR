using System;
using Android.App;
using Android.Hardware;
using Android.Views;
using Android.Widget;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;

namespace CriminalIntent
{
	public class CrimeCameraFragment : Android.Support.V4.App.Fragment , ISurfaceHolderCallback
    {
		#region - static variables
		private static readonly string TAG = "CrimeCameraFragment";
		#endregion

		#region - member variables
		Camera mCamera;
		SurfaceView mSurfaceView;
		#endregion

		#region - Lifecycle
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_crime_camera, container, false);

			Button takePictureButton = v.FindViewById<Button>(Resource.Id.crime_camera_takePictureButton);
			takePictureButton.Click += (object sender, EventArgs e) => {
				Activity.Finish();
			};

			mSurfaceView = v.FindViewById<SurfaceView>(Resource.Id.crime_camera_surfaceView);
			ISurfaceHolder holder = mSurfaceView.Holder;
			holder.SetType(SurfaceType.PushBuffers);

			holder.AddCallback(this);

			return v;
		}

		public override void OnResume()
		{
			base.OnResume();
			if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Gingerbread) {
				mCamera = Camera.Open(0);
			}
			else {
				mCamera = Camera.Open();
			}
		}

		public override void OnPause()
		{
			base.OnPause();
			if (mCamera != null) {
				mCamera.Release();
				mCamera = null;
			}
		}

		#endregion

		#region - SurfaceHolderCallBacks
		public void SurfaceCreated(ISurfaceHolder holder)
		{
			// Tell the Camera to use this surface as its preview area
			try {
				if (mCamera != null) {
					mCamera.SetPreviewDisplay(holder);
				}
			}
			catch (Exception ex) {
				Debug.WriteLine(String.Format("Error setting up preview display: {0}", ex.Message), TAG);
			}
		}

		public void SurfaceDestroyed(ISurfaceHolder holder)
		{
			// We can no longer display on this surface, so stop the preview
			if (mCamera != null) {
				mCamera.StopPreview();
			}
		}

		public void SurfaceChanged(ISurfaceHolder holder, Android.Graphics.Format format, int w, int h)
		{
			if (mCamera == null) return;

			// The surface has changed size. Update the camera preview size
			Camera.Parameters parameters = mCamera.GetParameters();
			Camera.Size s = GetBestSupportedSize(parameters.SupportedPreviewSizes, w, h);
			parameters.SetPreviewSize(s.Width, s.Height);
			mCamera.SetParameters(parameters);
			try {
				mCamera.StartPreview();
			}
			catch (Exception ex) {
				Debug.WriteLine(String.Format("Could not start preview: {0}", ex.Message), TAG);
				mCamera.Release();
				mCamera = null;
			}
		}

		#endregion

		#region - methods
		// A simple algorithm to get the largest size available. For a more
		// robust version, see CameraPreview.java in the API demos
		// sample app from Android

		private Camera.Size GetBestSupportedSize(IList<Camera.Size> sizes, int width, int height) 
		{
			Camera.Size bestSize = sizes[0];
			int largestArea = bestSize.Width * bestSize.Height;
			foreach (Camera.Size s in sizes) {
				int area = s.Width * s.Height;
				if (area > largestArea) {
					bestSize = s;
					largestArea = area;
				}
			}
			return bestSize;
		}

		#endregion
    }
}

