using System;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Locations;
using System.Collections.Generic;

//DONE! Give the current run a different color in the RunListFragment (Chapter 34 Challenge 1)
//TODO: Send a notification that the user's run is being tracked and open the App when clicked (Chapter 34 Challenge 2). 

//TODO:! Chapter 35 is about using loaders. I can do the same with async/await, so do that instead. Just don't block the UI thread when the Runs/RunLocations are loading.

//DONE: Chapter 36. Display a run on a map tracing a path for the run using the RunLocations. And that finishes the book!

//DONE! Just used my handy dandy RunManager singleton and updated the database with the new locations.
// I forgot I already made a GetActiveRun method in RunManager. Made it easy. 
// ****Make it so the current run updates wth new locations even if the RunFragmnet is not being displayed. 
// The system is creating a LocationReceiver, which continues to run after the RunFragment is off screen.
// RunLocationReceiver does not receive updates as it is not registered, but registering requires a default public constructor
// and then RunLocationReceiver won't have a reference to the RunFragment. Requires a bit of refactoring.****

using Android.Graphics;

namespace RunTracker
{
    public class RunListFragment : ListFragment
	{
		public static readonly string TAG = "RunListFragment";

		public static readonly string RUN_ID = "RUN_ID";

		private static readonly int REQUEST_NEW_RUN = 0;
		private static readonly int VIEW_RUN = 1;

		RunManager mRunManager;
		IMenu mMenu;

		public override async void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetHasOptionsMenu(true);
			RetainInstance = true;
			mRunManager = RunManager.Get(Activity);
			mRunManager.CreateDatabase();

			RunListAdapter adapter = new RunListAdapter(Activity, await mRunManager.GetRuns());
			ListAdapter = adapter;
		}

		public override void OnActivityCreated(Android.OS.Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);
			ListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
				// Open run in RunLocationListFragment
//				Run run = (Run)((RunListAdapter)ListAdapter).GetItem(e.Position);
//				Intent i = new Intent(Activity, typeof(RunLocationListActivity));
//				i.PutExtra(RUN_ID, run.Id);
//				i.SetFlags(ActivityFlags.ClearTop);
//				StartActivity(i);

				// Open run in RunFragment
				Run run = (Run)((RunListAdapter)ListAdapter).GetItem(e.Position);
				Intent i = new Intent(Activity, typeof(RunActivity));
				i.PutExtra(RUN_ID, run.Id);
				StartActivityForResult(i, VIEW_RUN);
			};

			ListView.ItemLongClick += (object sender, AdapterView.ItemLongClickEventArgs e) => {
				e.Handled = true;
				AlertDialog.Builder ad = new AlertDialog.Builder(Activity);
				ad.SetTitle(Activity.GetString(Resource.String.delete_item));
				ad.SetMessage(Activity.GetString(Resource.String.are_you_sure));
				ad.SetPositiveButton(Activity.GetString(Resource.String.ok), (s, dcea) => {
					Run run = (Run)((RunListAdapter)ListAdapter).GetItem(e.Position);
					mRunManager.DeleteItem(run);
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
			mMenu = menu;
			IMenuItem newRun = mMenu.FindItem(Resource.Id.menu_item_new_run);
			if (mRunManager.IsTrackingRun()) {
				newRun.SetTitle(Resource.String.current_run);
				newRun.SetIcon(Android.Resource.Drawable.IcMenuInfoDetails);
			}
			else {
				newRun.SetTitle(Resource.String.new_run);
				newRun.SetIcon(Android.Resource.Drawable.IcMenuAdd);
			}
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId) {
				case Resource.Id.menu_item_new_run:
					Intent i = new Intent(Activity, typeof(RunActivity));
					StartActivityForResult(i, REQUEST_NEW_RUN);
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		public override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (REQUEST_NEW_RUN == requestCode || VIEW_RUN == requestCode) {
				List<Run> runs = await mRunManager.GetRuns();
				// Lazy way to update all of the data on the adapter
				RunListAdapter adapter = new RunListAdapter(Activity, runs);
				ListAdapter = adapter;
				// This was working great to add a new run if there was one, but also needed to see if any
				// no longer active runs needed their item in the adapter updated. 
//				RunListAdapter adapter = (RunListAdapter)ListAdapter;
//				if (runs.Count > adapter.Count) {
//					adapter.Add(runs[runs.Count -1]);
//				}
//				adapter.NotifyDataSetChanged();

				IMenuItem newRun = mMenu.FindItem(Resource.Id.menu_item_new_run);
				if (mRunManager.IsTrackingRun()) {
					newRun.SetTitle(Resource.String.current_run);
					newRun.SetIcon(Android.Resource.Drawable.IcMenuInfoDetails);
				}
				else {
					newRun.SetTitle(Resource.String.new_run);
					newRun.SetIcon(Android.Resource.Drawable.IcMenuAdd);
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
				dateTextView.Text = String.Format("{0}: {1}", context.GetString(Resource.String.start_date), r.StartDate.ToLocalTime().ToLongDateString());

				if (r.Active) {
					view.SetBackgroundColor(Color.LightGray);
					timeTextView.Text += " - " + context.GetString(Resource.String.current_run);
				}
				else {
					view.SetBackgroundColor(Color.White);
				}

				return view;
			}
		}
		#endregion
    }
}

