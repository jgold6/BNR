using System;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Locations;

namespace RunTracker
{
    public class RunFragment : Fragment
    {
		public static readonly string TAG = "RunFragment";

		public static readonly string RUN_ID = "RUN_ID";
		public static readonly string RUN_START_DATE = "RUN_START_DATE";

		RunManager mRunManager;

		public Run CurrentRun {get; set;}
		public Location LastLocation {get; set;}
		public BroadcastReceiver CurrentLocationReceiver {get; set;}

		Button mStartButton, mStopButton;
		TextView mStartedTextView, mLatitudeTextView, mLongitudeTextView, mAltitudeTextView, mDurationTextView;

		public override void OnActivityCreated(Android.OS.Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);
			if (savedInstanceState != null && savedInstanceState.GetString(RUN_START_DATE) != null) {
				CurrentRun = new Run();
				CurrentRun.StartDate = DateTime.Parse(savedInstanceState.GetString(RUN_START_DATE));
				CurrentRun.Id = savedInstanceState.GetInt(RUN_ID);
			}
		}

		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			mRunManager = RunManager.Get(Activity);
			mRunManager.CreateDatabase();
			if (CurrentRun == null) {
				Run run = mRunManager.GetActiveRun();
				if (run != null)
					CurrentRun = run;
			}
			CurrentLocationReceiver = new RunLocationReceiver(this);
			Activity.RegisterReceiver(CurrentLocationReceiver, new IntentFilter(RunManager.ACTION_LOCATION));
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.fragment_run, container, false);

			mStartedTextView = view.FindViewById<TextView>(Resource.Id.run_startedTextView);
			mLatitudeTextView = view.FindViewById<TextView>(Resource.Id.run_latitudeTextView);
			mLongitudeTextView = view.FindViewById<TextView>(Resource.Id.run_longitudeTextView);
			mAltitudeTextView = view.FindViewById<TextView>(Resource.Id.run_altitudeTextView);
			mDurationTextView = view.FindViewById<TextView>(Resource.Id.run_durationTextView);

			mStartButton = view.FindViewById<Button>(Resource.Id.run_startButton);
			mStopButton = view.FindViewById<Button>(Resource.Id.run_stopButton);

			mStartButton.Click += (object sender, EventArgs e) => {
				mRunManager.StartLocationUpdates();
				CurrentRun = new Run();
				mRunManager.InsertItem<Run>(CurrentRun);
				UpdateUI();
			};

			mStopButton.Click += (object sender, EventArgs e) => {
				mRunManager.StopLocationUpdates();
				CurrentRun.Active = false;
				mRunManager.UpdateItem<Run>(CurrentRun);
				CurrentRun = null;
				UpdateUI();
			};

			UpdateUI();

			return view;
		}

		public override void OnSaveInstanceState(Android.OS.Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			if (CurrentRun != null) {
				outState.PutInt(RUN_ID, CurrentRun.Id);
				outState.PutString(RUN_START_DATE, CurrentRun.StartDate.ToString());
			}
		}
			
		public override void OnDestroy()
		{
			Activity.UnregisterReceiver(CurrentLocationReceiver);
			base.OnDestroy();
		}

		public void UpdateUI()
		{
			bool started = mRunManager.IsTrackingRun();

			if (CurrentRun != null)
				mStartedTextView.Text = CurrentRun.StartDate.ToLocalTime().ToString();
			else 
				mStartedTextView.Text = "";

			int durationSeconds = 0;
			if (CurrentRun != null && LastLocation != null) {
				DateTime lastLocTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(LastLocation.Time);
				durationSeconds = CurrentRun.GetDurationSeconds(lastLocTime);
				mLatitudeTextView.Text = LastLocation.Latitude.ToString();
				mLongitudeTextView.Text = LastLocation.Longitude.ToString();
				mAltitudeTextView.Text = LastLocation.Altitude.ToString();
			}
			else {
				mLatitudeTextView.Text = "";
				mLongitudeTextView.Text = "";
				mAltitudeTextView.Text = "";
			}
			mDurationTextView.Text = Run.FormatDuration(durationSeconds);

			mStartButton.Enabled = !started;
			mStopButton.Enabled = started;
		}
	}

	public class RunLocationReceiver : LocationReceiver
	{
		RunFragment mRunFragment;

		public RunLocationReceiver(RunFragment runFrag) : base()
		{
			mRunFragment = runFrag;
		}

		protected override void OnLocationReceived(Context context, Android.Locations.Location loc)
		{
			//base.OnLocationReceived(context, loc);
			mRunFragment.LastLocation = loc;

			if (mRunFragment.CurrentRun != null) {
				RunLocation rl = new RunLocation();
				rl.RunId = mRunFragment.CurrentRun.Id;
				rl.Latitude = loc.Latitude;
				rl.Longitude = loc.Longitude;
				rl.Altitude = loc.Altitude;
				rl.Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(loc.Time);
				//TODO: Add to database
				RunManager rm = RunManager.Get(mRunFragment.Activity);
				rm.InsertItem<RunLocation>(rl);
			}

			if (mRunFragment.IsVisible)
				mRunFragment.UpdateUI();
		}

		protected override void OnProviderEnabledChanged(bool enabled)
		{
			//base.OnProviderEnabledChanged(enabled);
			int toastText = enabled ? Resource.String.gps_enabled : Resource.String.gps_disabled;
			Toast.MakeText(mRunFragment.Activity, toastText, ToastLength.Long).Show();
		}
	}
}

