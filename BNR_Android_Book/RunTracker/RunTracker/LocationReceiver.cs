using System;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.Widget;

namespace RunTracker
{
	[BroadcastReceiver(Name="com.onobytes.RunTracker.LocationReceiver", Exported=false)]
	[IntentFilter (new[]{"com.onobytes.runtracker.ACTION_LOCATION"})]
	public class LocationReceiver : BroadcastReceiver
	{
		public static readonly string TAG = "LocationReceiver";

		public override void OnReceive(Context context, Intent intent)
		{
			// If you got a location extra, use it
			Location loc = (Location)intent.GetParcelableExtra(LocationManager.KeyLocationChanged);
			if (loc != null) {
				OnLocationReceived(context, loc);
				return;
			}
			// If you get here, something else has happened
			if (intent.HasExtra(LocationManager.KeyProviderEnabled)) {
				bool enabled = intent.GetBooleanExtra(LocationManager.KeyProviderEnabled, false);
				OnProviderEnabledChanged(context, enabled);
			}
		}

		protected virtual async void OnLocationReceived(Context context, Location loc)
		{
			//			Console.WriteLine("[{0}] {1} Got location from {2}: {3}, {4}", TAG, this, loc.Provider, loc.Latitude, loc.Longitude);
			RunManager rm = RunManager.Get(context);
			Run run = await rm.GetActiveRun();
			if (rm.IsTrackingRun() && run != null) {
				RunLocation rl = new RunLocation();
				rl.RunId = run.Id;
				rl.Latitude = loc.Latitude;
				rl.Longitude = loc.Longitude;
				rl.Altitude = loc.Altitude;
				rl.Time = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(loc.Time);
				rl.Provider = loc.Provider;
				rm.InsertItem<RunLocation>(rl);
			}
		}

		protected virtual void OnProviderEnabledChanged(Context context, bool enabled)
		{
			//			Console.WriteLine("[{0}] Provider {1}", TAG, (enabled ? "enabled" : "disabled"));
			int toastText = enabled ? Resource.String.gps_enabled : Resource.String.gps_disabled;
			Toast.MakeText(context, toastText, ToastLength.Long).Show();
		}
	}
}

