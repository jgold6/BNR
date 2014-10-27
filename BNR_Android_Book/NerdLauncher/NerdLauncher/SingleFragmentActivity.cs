using System;
using Android.OS;
using Android.App;

namespace NerdLauncher
{
    public abstract class SingleFragmentActivity : Activity
    {
		protected abstract Fragment CreateFragment();

		protected virtual int GetLayoutResId()
		{
			return Resource.Layout.activity_fragment;
		}

		protected override void OnCreate(Bundle savedInstanceState)
		{
			//RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
			base.OnCreate(savedInstanceState);
			SetContentView(GetLayoutResId());

			Fragment fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
			if (fragment == null) {
				fragment = CreateFragment();
				FragmentManager.BeginTransaction().Add(Resource.Id.fragmentContainer, fragment).Commit();
			}

		}
    }
}

