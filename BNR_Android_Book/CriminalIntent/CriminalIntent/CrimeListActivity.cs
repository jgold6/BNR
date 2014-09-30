#region - using statements
using System;

using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using Android.App;
#endregion

namespace CriminalIntent
{
	// Command to start an activity from the command line when Exported=true (Exported=true not needed for MainLauncher)
	// adb -s <devicenumberFromAdbDevices> shell am start -n com.onobytes.criminalintent/criminalintent.CrimeCameraActivity
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme="@style/AppTheme")]
	public class CrimeListActivity : SingleFragmentActivity
    {
		public static CrimeListActivity context {get; private set;}

		#region - member variables
		#endregion

		#region - abstract overrides
		protected override Android.Support.V4.App.Fragment CreateFragment()
		{
			CrimeListActivity.context = this;

			return new CrimeListFragment();
		}
		#endregion

		#region - Lifecycle
		#endregion
    }
}

