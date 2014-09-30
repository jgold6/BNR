using System;
using Android.Support.V4.View;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.App;

namespace CriminalIntent
{
	// Command to start an activity from the command line when Exported=true (Exported=true not needed for MainLauncher)
	// adb -s <devicenumberFromAdbDevices> shell am start -n com.onobytes.criminalintent/criminalintent.CrimeCameraActivity
	[Activity(Label = "@string/app_name", Icon = "@drawable/ic_launcher", Theme="@style/AppTheme", Exported=true)]// , ParentActivity=typeof(CrimeListActivity)
	public class CrimePagerActivity : FragmentActivity //, Android.Support.V4.View.ViewPager.IOnPageChangeListener
    {
		public static CrimePagerActivity context {get; private set;}

		#region - member variables
		public CrimePagerAdapter mCrimePagerAdapter;
		public ViewPager mViewPager;
		public List<Crime> mCrimes {get; private set;}
		#endregion

		#region - Lifecycle
		protected override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			//RequestWindowFeature(Android.Views.WindowFeatures.ActionBar);
			base.OnCreate(savedInstanceState);
			CrimePagerActivity.context = this;
			mViewPager = new ViewPager(this);
			mViewPager.Id = (Resource.Id.viewPager);
			SetContentView(mViewPager);

			mCrimes = CrimeLab.GetInstance(CrimePagerActivity.context).Crimes;

			Title = mCrimes[0].Title;
			CrimePagerAdapter adapter = new CrimePagerAdapter(SupportFragmentManager);
			mViewPager.Adapter = adapter;
			mViewPager.PageSelected += (object sender, ViewPager.PageSelectedEventArgs e) => {
				var crime = mCrimes[e.Position];
				if (crime.Title != null)
					Title = crime.Title;
			};

//			mViewPager.SetOnPageChangeListener(this);

			string crimeId = Intent.GetStringExtra(CrimeFragment.EXTRA_CRIME_ID);
			for (int i = 0; i < mCrimes.Count; i++) {
				if (mCrimes[i].Id == crimeId) {
					mViewPager.SetCurrentItem(i, false);
					break;
				}
			}
		}
		#endregion

//		#region - Interface implementations
//		public void OnPageScrollStateChanged(int state) {}
//
//		public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels) {}
//
//		public void OnPageSelected(int position)
//		{
//			Crime crime = mCrimes[position];
//			if (crime.Title != null)
//				Title = crime.Title;
//		}
//		#endregion

    }

	#region - PagerAdapter
	public class CrimePagerAdapter : FragmentStatePagerAdapter
	{
		public static List<Crime> CONTENT;
		public CrimePagerAdapter(Android.Support.V4.App.FragmentManager fm) : base(fm)
		{
			CONTENT = CrimeLab.GetInstance(CrimePagerActivity.context).Crimes;
		}

		public override int Count
		{
			get{return CONTENT.Count;}
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			Crime crime = CONTENT[position];
			return CrimeFragment.NewInstance(crime.Id);
		}


	}
	#endregion
}

