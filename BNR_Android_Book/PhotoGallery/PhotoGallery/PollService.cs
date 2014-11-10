using System;
using Android.App;
using Android.Net;
using Android.Content;
using Android.Preferences;
using System.Collections.Generic;
using Android.Content.Res;

namespace PhotoGallery
{
	[Service(Name="com.onobytes.PhotoGallery.PollService")]
    public class PollService : IntentService
    {
		private static readonly string TAG = "PollService";

		private static readonly int POLL_INTERVAL = 1000 * 15; // 15 seconds

		public PollService() : base(TAG)
        {
        }

		protected override async void OnHandleIntent(Android.Content.Intent intent)
		{
			Console.WriteLine("[{0}] Received an intent: {1}", TAG, intent);

			ConnectivityManager cm = (ConnectivityManager)GetSystemService(Context.ConnectivityService);
			bool isNetworkAvailable = cm.BackgroundDataSetting && cm.ActiveNetworkInfo != null;
			if (!isNetworkAvailable) 
				return;

			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
			string query = prefs.GetString(FlickrFetchr.PREF_SEARCH_QUERY, null);
			string lastResultId = prefs.GetString(FlickrFetchr.PREF_LAST_RESULT_ID, null);

			List<GalleryItem> items;
			if (query != null) {
				items = await new FlickrFetchr().Search(query);
			}
			else {
				items = await new FlickrFetchr().Fetchitems();
			}

			if (items.Count == 0)
				return;

			string resultId = items[0].Id;

			if (!resultId.Equals(lastResultId)) {
				Console.WriteLine("[{0}] Got a new result: {1}", TAG, resultId);

				Resources r = Resources;
				PendingIntent pi = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(PhotoGalleryActivity)), 0);

				Notification notification = new Notification.Builder(this)
					.SetTicker(Resources.GetString(Resource.String.new_pictures_title))
					.SetSmallIcon(Android.Resource.Drawable.IcMenuGallery)
					.SetContentTitle(Resources.GetString(Resource.String.new_pictures_title))
					.SetContentText(Resources.GetString(Resource.String.new_pictures_text))
					.SetContentIntent(pi)
					.SetAutoCancel(true)
					.Build();

				NotificationManager notificationManager = (NotificationManager)GetSystemService(NotificationService);

				notificationManager.Notify(0, notification);

			}
			else {
				Console.WriteLine("[{0}] Got an old result: {1}", TAG, resultId);
			}

			prefs.Edit().PutString(FlickrFetchr.PREF_LAST_RESULT_ID, resultId).Commit();
		}

		public static void SetServiceAlarm(Context context, bool isOn)
		{
			Intent i = new Intent(context, typeof(PollService));
			PendingIntent pi = PendingIntent.GetService(context, 0, i, 0);

			AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

			if (isOn) {
				alarmManager.SetRepeating(AlarmType.Rtc, DateTime.Now.Millisecond, POLL_INTERVAL, pi); 
			}
			else {
				alarmManager.Cancel(pi);
				pi.Cancel();
			}
		}

		public static bool IsServiceAlarmOn(Context context)
		{
			Intent i = new Intent(context, typeof(PollService));
			PendingIntent pi = PendingIntent.GetService(context, 0, i, PendingIntentFlags.NoCreate);
			return pi != null;
		}
    }
}

