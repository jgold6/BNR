using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace RunTracker
{
	[Activity(Label = "@string/app_name", Icon = "@drawable/icon", Theme="@style/AppTheme")]
	public class RunLocationListActivity : SingleFragmentActivity
    {
		public static readonly string TAG = "RunLocationListActivity";

		RunLocationListFragment mContent;

		protected override Fragment CreateFragment()
		{
			mContent = new RunLocationListFragment();
			return mContent;
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			if (savedInstanceState != null) {
				// Restore the Fragments instance
				mContent = (RunLocationListFragment)FragmentManager.GetFragment(savedInstanceState, "mContent");
			}
		}

		protected override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			FragmentManager.PutFragment(outState, "mContent", mContent);
		}
    }
}


