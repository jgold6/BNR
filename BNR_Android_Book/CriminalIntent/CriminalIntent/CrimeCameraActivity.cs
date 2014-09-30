using System;
using Android.App;
using Android.Views;

namespace CriminalIntent
{
	// Command to start an activity from the command line when Exported=true (Exported=true not needed for MainLauncher)
	// adb -s <devicenumberFromAdbDevices> shell am start -n com.onobytes.criminalintent/criminalintent.CrimeCameraActivity
	[Activity(Label = "@string/app_name", Icon = "@drawable/ic_launcher", Theme="@style/AppTheme",
		ScreenOrientation=Android.Content.PM.ScreenOrientation.Landscape, Exported=true)]
	public class CrimeCameraActivity : SingleFragmentActivity
    {
		public static CrimeCameraActivity context {get; private set;}

		#region - member variables
		#endregion

		#region - abstract overrides
		protected override Android.Support.V4.App.Fragment CreateFragment()
		{
			CrimeCameraActivity.context = this;

			return new CrimeCameraFragment();
		}
		#endregion

		#region - Lifecycle
		protected override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			// Hide the window title
			RequestWindowFeature(WindowFeatures.NoTitle);
			// Hide the status bar and other OS-level chrome
			Window.AddFlags(WindowManagerFlags.Fullscreen);
			base.OnCreate(savedInstanceState);
		}

		#endregion
    }
}

