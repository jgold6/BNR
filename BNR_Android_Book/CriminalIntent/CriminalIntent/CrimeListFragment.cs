using System;
using Android.Support.V4.App;
using System.Collections.Generic;
using Android.Widget;
using Android.OS;

namespace CriminalIntent
{
    public class CrimeListFragment : ListFragment
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
				
			ArrayAdapter<Crime> adapter = new ArrayAdapter<Crime>(Activity, 
													global::Android.Resource.Layout.SimpleListItem1, 
													CrimeLab.GetInstance(Android.App.Application.Context).Crimes.ToArray());
			this.ListAdapter = adapter;
		}
		#endregion

		#region overrides
		public override void OnListItemClick(ListView l, Android.Views.View v, int position, long id)
		{
			base.OnListItemClick(l, v, position, id);
			Crime c = (Crime)this.ListAdapter.GetItem(position);
			Console.WriteLine("Item clicked: {0}", c.Title);

		}
		#endregion
    }
}

