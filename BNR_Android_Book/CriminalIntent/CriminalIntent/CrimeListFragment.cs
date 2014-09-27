using System;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.App;
using Android.Content;

namespace CriminalIntent
{
    public class CrimeListFragment : Android.Support.V4.App.ListFragment
    {
		#region - member variables
		#endregion

		#region - Lifecycle
		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			HasOptionsMenu = true;

			Activity.SetTitle(Resource.String.crimes_title);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				Activity.ActionBar.SetSubtitle(Resource.String.title_activity_crimes);
				
			CrimeAdapter adapter = new CrimeAdapter(Activity, CrimeLab.GetInstance(CrimeListActivity.context).Crimes.ToArray());
			this.ListAdapter = adapter;
		}

		public override void OnResume()
		{
			base.OnResume();
			((CrimeAdapter)this.ListAdapter).NotifyDataSetChanged();
		}
		#endregion

		#region overrides
		public override void OnListItemClick(ListView l, View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);
			Crime c = ((CrimeAdapter)ListAdapter).GetItem(position);

			// Start crime activity
			Intent i = new Intent(Activity,typeof(CrimePagerActivity));
			i.PutExtra(CrimeFragment.EXTRA_CRIME_ID, c.Id);
			StartActivity(i);
		}
			

		// To be used later
		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater) {
			// Inflate the menu; this adds items to the action bar if it is present.
			base.OnCreateOptionsMenu(menu, inflater);
			inflater.Inflate(Resource.Menu.fragment_crime_list, menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			switch (item.ItemId) {
				case Resource.Id.menu_item_new_crime:
					Crime crime = new Crime();
					CrimeLab.GetInstance(Activity).AddCrime(crime);
					CrimeAdapter adapter = new CrimeAdapter(Activity, CrimeLab.GetInstance(CrimeListActivity.context).Crimes.ToArray());
					this.ListAdapter = adapter;
				
					Intent i = new Intent(Activity, typeof(CrimePagerActivity));
					i.PutExtra(CrimeFragment.EXTRA_CRIME_ID, crime.Id);
					StartActivity(i);
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}
		#endregion

		#region - ArrayAdapter inner subclass
		public class CrimeAdapter : ArrayAdapter<Crime>
		{
			Activity context;
			//Crime[] crimes;
			public CrimeAdapter(Activity context, Crime[] crimes) : base(context, 0, crimes)
			{
				this.context = context;
				//this.crimes = crimes;
			}

			public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
			{
				if (convertView == null) {
					convertView = context.LayoutInflater.Inflate(Resource.Layout.list_item_crime, null);
				}

				Crime c = GetItem(position);

				TextView titleTextView = (TextView)convertView.FindViewById(Resource.Id.crime_list_item_titleTextView);
				TextView dateTextView = (TextView)convertView.FindViewById(Resource.Id.crime_list_item_dateTextView);
				CheckBox solvedCheckBox = (CheckBox)convertView.FindViewById(Resource.Id.crime_list_item_solvedCheckBox);

				titleTextView.Text = c.Title;
				dateTextView.Text = String.Format("{0}\n{1}", c.Date.ToLongDateString(), c.Date.ToLongTimeString());
				solvedCheckBox.Checked = c.Solved;

				return convertView;
			}
				
		}

		#endregion
    }
}

