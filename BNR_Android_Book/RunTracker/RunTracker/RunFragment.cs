using System;
using Android.App;
using Android.Widget;
using Android.Views;
using Android.Content;
using Android.Locations;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;

namespace RunTracker
{
	public class RunFragment : Fragment, ViewTreeObserver.IOnGlobalLayoutListener
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
		GoogleMap mGoogleMap;
		LinearLayout mMapLayout;
		int mMapWidth;
		int mMapHeight;
		bool mMapShouldFollow = true;

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
				mGoogleMap.Clear();
				mMapShouldFollow = true;
				await UpdateUI();
			};

			mStopButton.Click += async (object sender, EventArgs e) => {
				mRunManager.StopRun(CurrentRun);
				CurrentRun = null;
				await UpdateUI();
			};

			mGoogleMap = ((MapFragment)FragmentManager.FindFragmentById(Resource.Id.mapFrag)).Map;
			mGoogleMap.MyLocationEnabled = true;

			mMapLayout = view.FindViewById<LinearLayout>(Resource.Id.mapLayout);
			ViewTreeObserver vto  = view.ViewTreeObserver;
			vto.AddOnGlobalLayoutListener(this);

			return view;
		}

		public async void OnGlobalLayout()
		{
			mMapWidth = mMapLayout.Width;
			mMapHeight = mMapLayout.Height;
			await UpdateUI();
		}

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
				if (run != null) {
					CurrentRun = run;
				}
			}
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

//				var location = new LatLng(mRunLocations[mRunLocations.Count -1].Latitude, mRunLocations[mRunLocations.Count -1].Longitude);
//				var cu = CameraUpdateFactory.NewLatLngZoom (location, 20);
//				mGoogleMap.MoveCamera (cu);
				DrawRunTrack(false);

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

				if (CurrentRun != null) {
					mRunLocations = await mRunManager.GetLocationsForRun(CurrentRun.Id);
					mStartedTextView.Text = CurrentRun.StartDate.ToLocalTime().ToString();
				}

				int durationSeconds = 0;
				if (CurrentRun != null && LastLocation != null) {
					DateTime lastLocTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(LastLocation.Time);
					durationSeconds = CurrentRun.GetDurationSeconds(lastLocTime);
					mLatitudeTextView.Text = LastLocation.Latitude.ToString();
					mLongitudeTextView.Text = LastLocation.Longitude.ToString();
					mAltitudeTextView.Text = LastLocation.Altitude.ToString();
					mDurationTextView.Text = Run.FormatDuration(durationSeconds);

//					var location = new LatLng(LastLocation.Latitude, LastLocation.Longitude);
//					var cu = CameraUpdateFactory.NewLatLngZoom (location, 20);
//					mGoogleMap.MoveCamera (cu);
					DrawRunTrack(true);
				}

				mStartButton.Enabled = !started;
				mStopButton.Enabled = started;
			}
		}

		void DrawRunTrack(bool mapShouldFollow) {
			if (mRunLocations.Count < 1)
				return;
			// Set up overlay for the map with the current run's locations
			// Create a polyline with all of the points
			PolylineOptions line = new PolylineOptions();
			// Create a LatLngBounds so you can zoom to fit
			LatLngBounds.Builder latLngBuilder = new LatLngBounds.Builder();
			// Add the locations of the current run
			foreach (RunLocation loc in mRunLocations) {
				LatLng latLng = new LatLng(loc.Latitude, loc.Longitude);
				line.Add(latLng);
				latLngBuilder.Include(latLng);
			}
			// Add the polyline to the map
			mGoogleMap.AddPolyline(line);

			// Add markers
			LatLng startLatLng = new LatLng(mRunLocations[0].Latitude, mRunLocations[0].Longitude);
			MarkerOptions startMarkerOptions = new MarkerOptions();
			startMarkerOptions.SetPosition(startLatLng);
			startMarkerOptions.SetTitle(Activity.GetString(Resource.String.run_start));
			startMarkerOptions.SetSnippet(Activity.GetString(Resource.String.run_started_at_format, new Java.Lang.Object[]{new Java.Lang.String(mRunLocations[0].Time.ToLongTimeString())}));
			mGoogleMap.AddMarker(startMarkerOptions);

			if (mRunManager.GetActiveRun() == null || (mRunManager.GetActiveRun() != null && CurrentRun.Id != mRunManager.GetActiveRun().Id)) {
				LatLng stopLatLng = new LatLng(mRunLocations[mRunLocations.Count-1].Latitude, mRunLocations[mRunLocations.Count-1].Longitude);
				MarkerOptions stopMarkerOptions = new MarkerOptions();
				stopMarkerOptions.SetPosition(stopLatLng);
				stopMarkerOptions.SetTitle(Activity.GetString(Resource.String.run_finish));
				stopMarkerOptions.SetSnippet(Activity.GetString(Resource.String.run_finished_at_format, new Java.Lang.Object[]{new Java.Lang.String(mRunLocations[mRunLocations.Count-1].Time.ToLongTimeString())}));
				mGoogleMap.AddMarker(stopMarkerOptions);
			}

			// Make the map zoom to show the track, with some padding
			// Use the size of the map linear layout in pixels as a bounding box
			LatLngBounds latLngBounds = latLngBuilder.Build();
			// Construct a movement instruction for the map
			CameraUpdate movement = CameraUpdateFactory.NewLatLngBounds(latLngBounds, mMapWidth, mMapHeight, 15);
			if (mMapShouldFollow) {
				try {
					mGoogleMap.MoveCamera(movement);
					mMapShouldFollow = mapShouldFollow;
				}
				catch (Exception ex) {
					Console.WriteLine("[{0}] No Layout yet {1}", TAG, ex.Message);
				}
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

