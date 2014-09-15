#region - using statements
using System;

using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.App;


#endregion

namespace CriminalIntent
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/ic_launcher", Theme="@style/AppTheme")]
	public class CrimeActivity : ActionBarActivity
    {
		#region - member variables
		#endregion

		#region - Lifecycle
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.activity_crime);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				ActionBar.SetSubtitle(Resource.String.title_activity_crime);

			Android.Support.V4.App.Fragment fragment = SupportFragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
			if (fragment == null) {
				fragment = new CrimeFragment();
				SupportFragmentManager.BeginTransaction().Add(Resource.Id.fragmentContainer, fragment).Commit();
			}

       }

		// To be used later
//		public override bool OnCreateOptionsMenu(IMenu menu) {
//			// Inflate the menu; this adds items to the action bar if it is present.
//			MenuInflater.Inflate(Resource.Menu.menu_quiz, menu);
//			return true;
//		}
//
//		public override bool OnOptionsItemSelected(IMenuItem item) {
//			// Handle action bar item clicks here. The action bar will
//			// automatically handle clicks on the Home/Up button, so long
//			// as you specify a parent activity in AndroidManifest.xml.
//			int id = item.ItemId;
//			if (id == Resource.Id.menu_settings) {
//				Console.WriteLine("Settings called");
//				return true;
//			}
//			return base.OnOptionsItemSelected(item);
//		}
		#endregion
    }
}


