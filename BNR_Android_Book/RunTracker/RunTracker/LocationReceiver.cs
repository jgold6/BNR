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

		public static readonly string ACTION_SHOW_NOTIFICATION = "com.onobytes.RunTracker.SHOW_NOTIFICATION";
		public static readonly string PERM_PRIVATE = "com.onobytes.RunTracker.PRIVATE";

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

				if ((DateTime.UtcNow - run.StartDate).Minutes % 5 == 0 && (DateTime.UtcNow - run.StartDate).Seconds % 60 == 0) { 

					// Open activity on click notification. (Need to handle properly so off for now) 
					Intent intent = new Intent(context, typeof(RunActivity));
					const int pendingIntentId = 0;
					PendingIntent pendingIntent = PendingIntent.GetActivity(context, pendingIntentId, intent, PendingIntentFlags.OneShot);

					Notification notification = new Notification.Builder(context)
						.SetTicker(context.Resources.GetString(Resource.String.tracking_run_notification_title))
						.SetSmallIcon(Android.Resource.Drawable.IcMenuView)
						.SetContentTitle(context.Resources.GetString(Resource.String.tracking_run_notification_title))
						.SetContentText(context.Resources.GetString(Resource.String.tracking_run_notification_text))
						.SetContentIntent(pendingIntent)
						.SetAutoCancel(true)
						.Build();

					NotificationManager notificationManager = context.GetSystemService(Context.NotificationService) as NotificationManager;

					const int notificationId = 0;
					notificationManager.Notify(notificationId, notification);
				}
			}
		}

		protected virtual void OnProviderEnabledChanged(Context context, bool enabled)
		{
			int toastText = enabled ? Resource.String.gps_enabled : Resource.String.gps_disabled;
			Toast.MakeText(context, toastText, ToastLength.Long).Show();
		}
	}
}

