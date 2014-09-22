using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace HelloMoon
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class HelloMoonActivity : Android.App.Activity
    {
		public static HelloMoonActivity Context {get; private set;}

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			HelloMoonActivity.Context = this;
            // Set our view from the "main" layout resource
			SetContentView(Resource.Layout.activity_hello_moon);

			// Using a FrameLayout instead of a fragment in the activity_hellomoon.axml layout
			Fragment fragment = FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
			if (fragment == null) {
				fragment = new HelloMoonFragment();
				FragmentManager.BeginTransaction().Add(Resource.Id.fragmentContainer, fragment).Commit();
				
			}
         }
    }
}


