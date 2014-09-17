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
	[Activity(Label = "@string/app_name", Icon = "@drawable/ic_launcher", Theme="@style/AppTheme")]
	public class CrimeActivity : SingleFragmentActivity
    {
		#region - member variables
		#endregion

		#region - abstract overrides
		protected override Android.Support.V4.App.Fragment CreateFragment()
		{
			string crimeId = Intent.GetStringExtra(CrimeFragment.EXTRA_CRIME_ID);
			return CrimeFragment.NewInstance(crimeId);
		}
		#endregion

		#region - Lifecycle
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


