using System;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Locations;
using System.Collections.Generic;

//TODO: Allow a run to be continued, so selecting a run form the list opens it in the RunFragment. Need to rework RunFragment so it can continue a passed in Run
// Also give the current run a different color in the RunListFragment (Chapter 34 Challenge 1)
//TODO: Send a notification that the user's run is being tracked and open the App when clicked (Chapter 34 Challenge 2). 

//TODO: Chapter 35 is about using loaders. I can do the same with async/await, so do that instead. Just don't block the UI thread when the Runs/RunLocations are loading.

//TODO: Chapter 36. Display a run on a map tracing a path for the run using the RunLocations. And that finishes the book!

namespace RunTracker
{
    public class RunListFragment : ListFragment
	{
		public static readonly string TAG = "RunListFragment";

		public static readonly string RUN_ID = "RUN_ID";

		private static readonly int REQUEST_NEW_RUN = 0;

		RunManager mRunManager;
		List<Run> mRuns;

		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetHasOptionsMenu(true);
			mRunManager = RunManager.Get(Activity);
			mRunManager.CreateDatabase();

			mRuns = mRunManager.GetRuns();

			RunListAdapter adapter = new RunListAdapter(Activity, mRuns);
			ListAdapter = adapter;

		}

		public override void OnResume()
		{
			base.OnResume();
			ListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				Run run = (Run)((RunListAdapter)ListAdapter).GetItem(e.Position);
				Intent i = new Intent(Activity, typeof(RunLocationListActivity));
				i.PutExtra(RUN_ID, run.Id);
				i.SetFlags(ActivityFlags.ClearTop);
				StartActivity(i);
			};

			ListView.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) => {

				AlertDialog.Builder ad = new AlertDialog.Builder(Activity);
				ad.SetTitle(Activity.GetString(Resource.String.delete_item));
				ad.SetMessage(Activity.GetString(Resource.String.are_you_sure));
				ad.SetPositiveButton(Activity.GetString(Resource.String.ok), (s, dcea) => { 
					Run run = (Run)((RunListAdapter)ListAdapter).GetItem(e.Position);
					mRunManager.DeleteItem(run);
					mRuns = mRunManager.GetRuns();
					RunListAdapter adapter = (RunListAdapter)ListAdapter;
					adapter.Remove(run);
					adapter.NotifyDataSetChanged();
				});
				ad.SetNegativeButton(Activity.GetString(Resource.String.cancel), (s, dcea) => {});
				ad.Show();
			};
		}

		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
		{
			base.OnCreateOptionsMenu(menu, inflater);
			inflater.Inflate(Resource.Menu.run_list_options, menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.menu_item_new_run:
					Intent i = new Intent(Activity, typeof(RunActivity));
					i.SetFlags(ActivityFlags.ClearTop);
					StartActivityForResult(i, REQUEST_NEW_RUN);
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (REQUEST_NEW_RUN == requestCode && !mRunManager.IsTrackingRun()) {
				mRuns = mRunManager.GetRuns();
				RunListAdapter adapter = (RunListAdapter)ListAdapter;
				if (mRuns.Count > adapter.Count) {
					adapter.Add(mRuns[mRuns.Count -1]);
					adapter.NotifyDataSetChanged();
				}
			}
		}

		#region - ArrayAdapter inner subclass
		public class RunListAdapter : ArrayAdapter<Run>
		{
			Activity context;
			public RunListAdapter(Activity context, List<Run> runs) : base(context, 0, runs)
			{
				this.context = context;
			}

			public override Android.Views.View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
			{
				View view = convertView;
				if (view == null) {
					view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);
				}

				Run r = GetItem(position);

				TextView timeTextView = (TextView)view.FindViewById(Android.Resource.Id.Text1);
				TextView dateTextView = (TextView)view.FindViewById(Android.Resource.Id.Text2);

				timeTextView.Text = String.Format("{0}: {1}", context.GetString(Resource.String.start_time), r.StartDate.ToLocalTime().ToShortTimeString());
				dateTextView.Text = String.Format("{0}: {1}", context.GetString(Resource.String.start_date), r.StartDate.ToLocalTime().ToShortDateString());

				return view;
			}
		}
		#endregion
    }
}

