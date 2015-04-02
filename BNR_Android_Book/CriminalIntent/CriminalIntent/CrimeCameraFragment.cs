using System;
using Android.App;
using Android.Hardware;
using Android.Views;
using Android.Widget;
using System.Drawing;
using System.Collections.Generic;
using Java.Util;
using System.IO;
using Android.Content;

namespace CriminalIntent
{ 
	public class CrimeCameraFragment : Android.Support.V4.App.Fragment , ISurfaceHolderCallback , Camera.IShutterCallback, Camera.IPictureCallback
    {
		#region - static variables
		private static readonly string TAG = "CrimeCameraFragment";
		public static readonly string EXTRA_PHOTO_FILENAME = "com.onobyes.criminalintent.photo_filename";
		#endregion

		#region - member variables
		Camera mCamera;
		SurfaceView mSurfaceView;
		View mProgressViewContainer;
		#endregion

		#region - Lifecycle
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_crime_camera, container, false);

			Button takePictureButton = v.FindViewById<Button>(Resource.Id.crime_camera_takePictureButton);
			takePictureButton.Click += (object sender, EventArgs e) => {
				//Activity.Finish();
				if (mCamera != null) {
					mCamera.TakePicture(this, null, this);
				}
			};

			mSurfaceView = v.FindViewById<SurfaceView>(Resource.Id.crime_camera_surfaceView);
			ISurfaceHolder holder = mSurfaceView.Holder;
			holder.SetType(SurfaceType.PushBuffers);

			holder.AddCallback(this);

			mProgressViewContainer = v.FindViewById<View>(Resource.Id.crime_camera_progressContainer);
			mProgressViewContainer.Visibility = ViewStates.Invisible; 

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
			// Correcting aspect ratio error - gets rid of extraneous lines that jpeg fills in. 
			s.Width = s.Height > s.Width ? s.Height *3/4 : s.Height *4/3;
			parameters.SetPreviewSize(s.Width, s.Height);
			s = GetBestSupportedSize(parameters.SupportedPictureSizes , w, h);
			parameters.SetPictureSize(s.Width, s.Height);
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

		#region - Camera Callbacks
		public void OnShutter() 
		{
			// Display the progress indicator
			mProgressViewContainer.Visibility= ViewStates.Visible;
		}

		public void OnPictureTaken(byte[] data, Camera camera)
		{
			// Create a filename
			string filename = UUID.RandomUUID().ToString() + ".jpg";
			// Save the jpeg data to disk
			Stream os = null;
			bool success = true;
			try {
				os = Activity.OpenFileOutput(filename, Android.Content.FileCreationMode.Private);
				os.Write(data, 0, data.Length);
			}
			catch (Exception ex) {
				Debug.WriteLine(String.Format("Error writing image to file: {0}, {1}", filename, ex.Message), TAG);
				success = false;
			}
			finally {
				try {
					if (os != null)
						os.Close();
				}
				catch (Exception ex) {
					Debug.WriteLine(String.Format("Error closing file: {0}, {1}", filename, ex.Message), TAG);
					success = false;
				}
			}
			// Set the photo filename n the result intent
			if (success) {
				Debug.WriteLine(String.Format("Jpeg saved at: {0}", filename), TAG);
				Intent i = new Intent();
				i.PutExtra(EXTRA_PHOTO_FILENAME, filename);
				Activity.SetResult(Result.Ok, i);
			}
			else {
				Activity.SetResult(Result.Canceled);
			}
			Activity.Finish();
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

