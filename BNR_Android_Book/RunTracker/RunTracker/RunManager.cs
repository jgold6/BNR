using System;
using Android.Content;
using Android.Locations;
using Android.App;

namespace RunTracker
{
    public class RunManager
    {
		public static readonly string TAG = "RunManager";

		public static readonly string ACTION_LOCATION = "com.onobytes.runtracker.ACTION_LOCATION";

		private static RunManager sRunManager;
		private Context mAppContext;
		private LocationManager mLocationManager;

        private RunManager(Context appContext)
        {
			mAppContext = appContext;
			mLocationManager = (LocationManager)mAppContext.GetSystemService(Context.LocationService);
        }

		public static RunManager Get(Context c)
		{
			if (sRunManager == null) {
				// Use the application context to avoid leaking activities
				sRunManager = new RunManager(c.ApplicationContext);
			}
			return sRunManager;
		}

		private PendingIntent GetLocationPendingIntent(bool shouldCreate)
		{
			Intent broadcast = new Intent(ACTION_LOCATION);
			int flags = (int)(shouldCreate ? 0 : PendingIntentFlags.NoCreate);
			return PendingIntent.GetBroadcast(mAppContext, 0, broadcast, (PendingIntentFlags)flags);
		}

		public void StartLocationUpdates() {
			string provider = LocationManager.GpsProvider;

			// Get the last known location and broadcast it if you have one
			Location lastKnown = mLocationManager.GetLastKnownLocation(provider);
			if (lastKnown != null) {
				// Reset the time to now
				lastKnown.Time =  Java.Lang.JavaSystem.CurrentTimeMillis();
				broadcastLocation(lastKnown);
			}

			// Start updates from the location manager
			PendingIntent pi = GetLocationPendingIntent(true);
			mLocationManager.RequestLocationUpdates(provider, 0, 0, pi);
		}

		private void broadcastLocation(Location location)
		{
			Intent broadcast = new Intent(ACTION_LOCATION);
			broadcast.PutExtra(LocationManager.KeyLocationChanged, location);
			mAppContext.SendBroadcast(broadcast);
		}

		public void StopLocationUpdates()
		{
			PendingIntent pi = GetLocationPendingIntent(false);
			if (pi != null) {
				mLocationManager.RemoveUpdates(pi);
				pi.Cancel();
			}
		}

		public bool IsTrackingRun()
		{
			return GetLocationPendingIntent(false) != null;
		}
    }
}

