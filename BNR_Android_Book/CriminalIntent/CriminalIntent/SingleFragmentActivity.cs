using System;
using Android.Support.V4.App;
using Android.OS;
using Android.Support.V7.App;

namespace CriminalIntent
{
    public abstract class SingleFragmentActivity : ActionBarActivity
    {
		protected abstract Fragment CreateFragment();

		protected override void OnCreate(Bundle savedInstanceState)
		{
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

