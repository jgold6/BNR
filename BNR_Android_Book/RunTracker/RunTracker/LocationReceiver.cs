using System;

using Android.App;
using Android.Content;
using Android.Locations;

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
				OnProviderEnabledChanged(enabled);
			}
		}

		protected virtual void OnLocationReceived(Context context, Location loc)
		{
			//Console.WriteLine("[{0}] {1} Got location from {2}: {3}, {4}", TAG, this, loc.Provider, loc.Latitude, loc.Longitude);
		}

		protected virtual void OnProviderEnabledChanged(bool enabled)
		{
			//Console.WriteLine("[{0}] Provider {1}", TAG, (enabled ? "enabled" : "disabled"));
		}
    }
}

