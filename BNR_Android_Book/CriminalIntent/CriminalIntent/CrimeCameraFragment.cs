using System;
using Android.App;
using Android.Hardware;
using Android.Views;

namespace CriminalIntent
{
	public class CrimeCameraFragment : Android.Support.V4.App.Fragment
    {
		#region - static variables
		private static readonly string TAG = "CrimeCameraFragment";
		#endregion

		#region = member variables
		Camera mCamera;
		SurfaceView mSurfaceView;
		#endregion

		#region - Lifecycle
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			return base.OnCreateView(inflater, container, savedInstanceState);
		}
		#endregion
    }
}

