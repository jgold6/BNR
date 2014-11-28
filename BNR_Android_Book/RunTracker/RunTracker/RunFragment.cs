using System;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Locations;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		List<RunLocation> mRunLocations;
		Button mStartButton, mStopButton;
		TextView mStartedTextView, mLatitudeTextView, mLongitudeTextView, mAltitudeTextView, mDurationTextView;

		public override async void OnActivityCreated(Android.OS.Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);
			if (savedInstanceState != null && savedInstanceState.GetInt(RUN_ID, -1) != -1) {
				CurrentRun = mRunManager.GetRun(savedInstanceState.GetInt(RUN_ID));
			}
			else if (Activity.Intent.GetIntExtra(RUN_ID, -1) != -1) {
				CurrentRun = mRunManager.GetRun(Activity.Intent.GetIntExtra(RUN_ID, -1));
			}
			else if (CurrentRun == null) {
				Run run = await mRunManager.GetActiveRun();
				if (run != null)
					CurrentRun = run;
			}

			await UpdateUI();
		}

		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			mRunManager = RunManager.Get(Activity);
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

			mStartButton.Click += async (object sender, EventArgs e) => {
				CurrentRun = mRunManager.StartNewRun();
				await UpdateUI();
			};

			mStopButton.Click += async (object sender, EventArgs e) => {
				mRunManager.StopRun(CurrentRun);
				CurrentRun = null;
				await UpdateUI();
			};

			UpdateUI().Wait();

			return view;
		}

		public override void OnSaveInstanceState(Android.OS.Bundle outState)
		{
			base.OnSaveInstanceState(outState);
			if (CurrentRun != null) {
				outState.PutInt(RUN_ID, CurrentRun.Id);
			}
		}
			
		public override void OnDestroy()
		{
			try {
				Activity.UnregisterReceiver(CurrentLocationReceiver);
			}
			catch (Exception ex) {
				Console.WriteLine("[{0}] Receiver not registered: {1}", TAG, ex.Message);
			}
			base.OnDestroy();
		}

		public async Task UpdateUI()
		{
			if (CurrentRun != null && !CurrentRun.Active) {
				mRunLocations = await mRunManager.GetLocationsForRun(CurrentRun.Id);

				mStartedTextView.Text = CurrentRun.StartDate.ToLocalTime().ToString();

				mLatitudeTextView.Text = mRunLocations[0].Latitude.ToString();
				mLongitudeTextView.Text = mRunLocations[0].Longitude.ToString();
				mAltitudeTextView.Text = mRunLocations[0].Altitude.ToString();

				int durationSeconds = (mRunLocations[mRunLocations.Count -1].Time - CurrentRun.StartDate).Seconds;
				mDurationTextView.Text = Run.FormatDuration(durationSeconds);

				if (mRunManager.IsTrackingRun()) {
					mStartButton.Enabled = false;
					mStartButton.Visibility = ViewStates.Invisible;
					mStopButton.Enabled = false;
					mStopButton.Visibility = ViewStates.Invisible;
				}
				else {
					mStartButton.Enabled = true;
					mStopButton.Enabled = false;
				}
			}
			else {
				bool started = mRunManager.IsTrackingRun();

				if (CurrentRun != null)
					mStartedTextView.Text = CurrentRun.StartDate.ToLocalTime().ToString();

				int durationSeconds = 0;
				if (CurrentRun != null && LastLocation != null) {
					DateTime lastLocTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(LastLocation.Time);
					durationSeconds = CurrentRun.GetDurationSeconds(lastLocTime);
					mLatitudeTextView.Text = LastLocation.Latitude.ToString();
					mLongitudeTextView.Text = LastLocation.Longitude.ToString();
					mAltitudeTextView.Text = LastLocation.Altitude.ToString();
					mDurationTextView.Text = Run.FormatDuration(durationSeconds);
				}

				mStartButton.Enabled = !started;
				mStopButton.Enabled = started;
			}
		}
	}
		
	public class RunLocationReceiver : LocationReceiver
	{
		RunFragment mRunFragment;

		public RunLocationReceiver(RunFragment runFrag) : base()
		{
			mRunFragment = runFrag;
		}

		protected override async void OnLocationReceived(Context context, Android.Locations.Location loc)
		{
			//base.OnLocationReceived(context, loc);
			RunManager rm = RunManager.Get(mRunFragment.Activity);

			// trying to ignore old locations, but this call always seems to pass a location with the current time
			// so leaving out for now
//			var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
//			var now = DateTime.UtcNow;
//			var seconds = (now - epoch).TotalSeconds;
//
//			var locTimeSeconds = loc.Time /1000;
//
//			if (locTimeSeconds < seconds - 60)
//				return;

			if (rm.IsTrackingRun()) {
				mRunFragment.LastLocation = loc;
				// Moved to LocationReceiver
//				RunLocation rl = new RunLocation();
//				rl.RunId = mRunFragment.CurrentRun.Id;
//				rl.Latitude = loc.Latitude;
//				rl.Longitude = loc.Longitude;
//				rl.Altitude = loc.Altitude;
//				rl.Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(loc.Time);
//				rl.Provider = loc.Provider;
//				rm.InsertItem<RunLocation>(rl);
			}

			if (mRunFragment.IsVisible)
				await mRunFragment.UpdateUI();
		}

		protected override void OnProviderEnabledChanged(Context context, bool enabled)
		{
			//base.OnProviderEnabledChanged(enabled);
			// Moved to LocationReceiver
//			int toastText = enabled ? Resource.String.gps_enabled : Resource.String.gps_disabled;
//			Toast.MakeText(mRunFragment.Activity, toastText, ToastLength.Long).Show();
		}
	}
}

