using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.Content.Res;

namespace PhotoGallery
{
    public abstract class VisibleFragment : Fragment
    {
		private static readonly string TAG = "VisibleFragment";

		private PGBroadcastReceiver mOnShowNotification = new PGBroadcastReceiver();

		public override void OnResume()
		{
			base.OnResume();
			IntentFilter filter = new IntentFilter(PollService.ACTION_SHOW_NOTIFICATION);
			Activity.RegisterReceiver(mOnShowNotification, filter, PollService.PERM_PRIVATE, null);
		}

		public override void OnPause()
		{
			base.OnPause();
			Activity.UnregisterReceiver(mOnShowNotification);
		}
    }

	public class PGBroadcastReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			//Toast.MakeText(context, context.Resources.GetString(Resource.String.got_a_broadcast) + intent.Action, ToastLength.Long).Show();
			// If we see this, we're visible, so cancel
			// the notification.
			ResultCode = Result.Canceled;
		}
	}
	[BroadcastReceiver(Name="com.onobytes.PhotoGallery.NotificationReceiver", Exported=false)]
	[IntentFilter(new[]{"com.onobytes.PhotoGallery.SHOW_NOTIFICATION"}, Priority=-999)]
	public class NotificationReceiver : BroadcastReceiver
	{
		private static readonly string TAG = "NotificationReceiver";

		public override void OnReceive(Context context, Intent intent)
		{
			//Console.WriteLine("[{0}] Received result: {1}", TAG, ResultCode);
			if (ResultCode != Result.Ok) {
				// A foreground activity cancelled the broadcast
				return;
			}

			int requestCode = intent.GetIntExtra("REQUEST_CODE", 0);
			Notification notification = (Notification)intent.GetParcelableExtra("NOTIFICATION");

			NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
			notificationManager.Notify(requestCode, notification);
		}
	}
}

