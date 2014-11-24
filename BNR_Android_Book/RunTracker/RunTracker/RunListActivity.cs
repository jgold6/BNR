using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RunTracker
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/AppTheme")]
	public class RunListActivity : SingleFragmentActivity
    {
		public static readonly string TAG = "RunListActivity";

		RunListFragment mContent;

		protected override Fragment CreateFragment()
		{
			mContent = new RunListFragment();
			return mContent;
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			if (savedInstanceState != null) {
				// Restore the Fragments instance
				mContent = (RunListFragment)FragmentManager.GetFragment(savedInstanceState, "mContent");
			}
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			FragmentManager.PutFragment(outState, "mContent", mContent);
		}
    }
}


