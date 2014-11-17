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


		RunManager mRunManager;

		public Run CurrentRun {get; set;}
		public Location LastLocation {get; set;}
		public BroadcastReceiver CurrentLocationReceiver {get; set;}

		Button mStartButton, mStopButton;
		TextView mStartedTextView, mLatitudeTextView, mLongitudeTextView, mAltitudeTextView, mDurationTextView;

		public override void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RetainInstance = true;
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

			mStartButton.Click += (object sender, EventArgs e) => {
				mRunManager.StartLocationUpdates();
				CurrentRun = new Run();
				UpdateUI();
			};

			mStopButton.Click += (object sender, EventArgs e) => {
				mRunManager.StopLocationUpdates();
				CurrentRun = null;
				UpdateUI();
			};

			UpdateUI();

			return view;
		}

		public override void OnDestroy()
		{
			Activity.UnregisterReceiver(CurrentLocationReceiver);
			base.OnStop();
		}

		public void UpdateUI()
		{
			bool started = mRunManager.IsTrackingRun();

			if (CurrentRun != null)
				mStartedTextView.Text = CurrentRun.StartDate.ToString();

			int durationSeconds = 0;
			if (CurrentRun != null && LastLocation != null) {
				durationSeconds = CurrentRun.GetDurationSeconds(LastLocation.Time);
				mLatitudeTextView.Text = LastLocation.Latitude.ToString();
				mLongitudeTextView.Text = LastLocation.Longitude.ToString();
				mAltitudeTextView.Text = LastLocation.Altitude.ToString();
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

