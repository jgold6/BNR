using System;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Locations;
using System.Collections.Generic;

namespace RunTracker
{
    public class RunLocationListFragment : ListFragment
	{
		public static readonly string TAG = "RunLocationListFragment";

		RunManager mRunManager;

		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			int runId = Activity.Intent.Extras.GetInt(RunListFragment.RUN_ID, -1);

			mRunManager = RunManager.Get(Activity);

			if (runId != -1) {
				RunLocationListAdapter adapter = new RunLocationListAdapter(Activity, mRunManager.GetLocationsForRun(runId));
				ListAdapter = adapter;
			}
		}

		#region - ArrayAdapter inner subclass
		public class RunLocationListAdapter : ArrayAdapter<RunLocation>
		{
			Activity context;
			public RunLocationListAdapter(Activity context, List<RunLocation> runLocations) : base(context, 0, runLocations)
			{
				this.context = context;
			}

			public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
			{
				View view = convertView;
				if (view == null) {
					view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
				}

				RunLocation rl = GetItem(position);

				TextView timeTextView = (TextView)view.FindViewById(Android.Resource.Id.Text1);
				TextView locTextView = (TextView)view.FindViewById(Android.Resource.Id.Text2);

				timeTextView.Text = String.Format("{0}: {1}", context.GetString(Resource.String.loc_time), rl.Time.ToLocalTime().ToShortTimeString());
				locTextView.Text = String.Format("{0} {1:F5}, {2} {3:F5}, {4} {5:F5}", 
					context.GetString(Resource.String.latitude), rl.Latitude,
					context.GetString(Resource.String.longitude), rl.Longitude,
					context.GetString(Resource.String.altitude), rl.Altitude
				);

				return view;
			}
		}
		#endregion
    }
}

