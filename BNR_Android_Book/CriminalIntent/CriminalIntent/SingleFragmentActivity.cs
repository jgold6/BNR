using System;
using Android.Support.V4.App;
using Android.OS;
using Android.Support.V7.App;
using Android.App;

namespace CriminalIntent
{
    public abstract class SingleFragmentActivity : FragmentActivity
    {
		protected abstract Android.Support.V4.App.Fragment CreateFragment();

		protected override void OnCreate(Bundle savedInstanceState)
		{
			//RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_fragment);

			Android.Support.V4.App.Fragment fragment = SupportFragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
			if (fragment == null) {
				fragment = CreateFragment();
				SupportFragmentManager.BeginTransaction().Add(Resource.Id.fragmentContainer, fragment).Commit();
			}

		}
    }
}

