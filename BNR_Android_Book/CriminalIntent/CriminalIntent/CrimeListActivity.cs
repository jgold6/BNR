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
	public class CrimeListActivity : SingleFragmentActivity, CrimeListFragment.ICallbacks, CrimeFragment.ICallbacks
    {
		public static CrimeListActivity Context {get; private set;}

		#region - member variables
		#endregion

		#region - abstract overrides
		protected override Android.Support.V4.App.Fragment CreateFragment()
		{
			CrimeListActivity.Context = this;

			return new CrimeListFragment();
		}

		protected override int GetLayoutResId()
		{
			return Resource.Layout.activity_masterdetail;
		}
		#endregion

		#region - Lifecycle
		#endregion

		#region - CrimeListFragment and CrimeFragment ICallbacks
		public void OnCrimeSelected(Crime crime)
		{
			if (FindViewById(Resource.Id.detailFragmentContainter) == null) {
				// Start an instance of CrimePagerActivity
				Intent i = new Intent(this, typeof(CrimePagerActivity));
				i.PutExtra(CrimeFragment.EXTRA_CRIME_ID, crime.Id);
				StartActivity(i);
			}
			else {
				Android.Support.V4.App.FragmentManager fm = SupportFragmentManager;
				Android.Support.V4.App.FragmentTransaction ft = fm.BeginTransaction();

				Android.Support.V4.App.Fragment oldDetail = fm.FindFragmentById(Resource.Id.detailFragmentContainter);
				Android.Support.V4.App.Fragment newDetail = CrimeFragment.NewInstance(crime.Id);

				if (oldDetail != null) {
					ft.Remove(oldDetail);
				}

				ft.Add(Resource.Id.detailFragmentContainter, newDetail);
				ft.Commit();
			}
		}

		public void OnCrimeUpdated()
		{
			Android.Support.V4.App.FragmentManager fm = SupportFragmentManager;
			CrimeListFragment listFragment = (CrimeListFragment)fm.FindFragmentById(Resource.Id.fragmentContainer);
			listFragment.UpdateUI();
		}

		public void RemoveDetailView()
		{
			if (FindViewById(Resource.Id.detailFragmentContainter) != null) {
				Android.Support.V4.App.FragmentManager fm = SupportFragmentManager;
				Android.Support.V4.App.FragmentTransaction ft = fm.BeginTransaction();
				Android.Support.V4.App.Fragment oldDetail = fm.FindFragmentById(Resource.Id.detailFragmentContainter);
				if (oldDetail != null) {
					ft.Remove(oldDetail);
				}
				ft.Commit();
			}
		}

		public void OnCrimeDeleted()
		{
			RemoveDetailView();
			Android.Support.V4.App.FragmentManager fm = SupportFragmentManager;
			CrimeListFragment listFragment = (CrimeListFragment)fm.FindFragmentById(Resource.Id.fragmentContainer);
			listFragment.RemoveDeletedCrime();
		}
		#endregion
    }
}

