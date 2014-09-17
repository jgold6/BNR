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
			Activity.SetTitle(Resource.String.crimes_title);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				Activity.ActionBar.SetSubtitle(Resource.String.title_activity_crimes);
				
			CrimeAdapter adapter = new CrimeAdapter(Activity, 
													CrimeLab.GetInstance(Android.App.Application.Context).Crimes.ToArray());
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
			Intent i = new Intent(Activity,typeof(CrimeActivity));
			i.PutExtra(CrimeFragment.EXTRA_CRIME_ID, c.Id);
			StartActivity(i);
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
				dateTextView.Text = c.Date.ToShortDateString();
				solvedCheckBox.Checked = c.Solved;

				return convertView;
			}
				
		}
		#endregion
    }
}

