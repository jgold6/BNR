using System;

using Android.App;
using Android.Content;
using Android.Preferences;


namespace PhotoGallery
{
	[BroadcastReceiver(Name="com.onobytes.PhotoGallery.StartupReceiver")]
	[IntentFilter (new[]{Intent.ActionBootCompleted})]
    public class StartupReceiver : BroadcastReceiver
    {
		private static readonly string TAG = "StartupReceiver";

		public override void OnReceive(Context context, Intent intent)
		{
			Console.WriteLine("[{0}] Received broadcast intent: {1}", TAG, intent.Action);

			ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(context);
			bool isOn = prefs.GetBoolean(PollService.PREF_IS_ALARM_ON, false);
			PollService.SetServiceAlarm(context, isOn);
		}
    }
}

