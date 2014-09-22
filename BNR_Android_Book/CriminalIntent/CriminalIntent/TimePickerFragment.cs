using System;
using Android.Support.V4.App;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Widget;
using Android.Content;

namespace CriminalIntent
{
	public class TimePickerFragment : Android.Support.V4.App.DialogFragment, TimePicker.IOnTimeChangedListener
    {
		public static string EXTRA_HOUR = "com.onobytes.criminalintent.hour";
		public static string EXTRA_MINUTE = "com.onobytes.criminalintent.minute";

		DateTime mDate;

		private TimePickerFragment() {}

		public static TimePickerFragment NewInstance(DateTime date)
		{
			TimePickerFragment fragment = new TimePickerFragment();
			fragment.mDate = date;

			Bundle args = new Bundle();
			args.PutInt(EXTRA_HOUR, date.Hour);
			args.PutInt(EXTRA_MINUTE, date.Minute);
			fragment.Arguments = args;

			return fragment;
		}

		public override Android.App.Dialog OnCreateDialog(Android.OS.Bundle savedInstanceState)
		{
			int hour = Arguments.GetInt(EXTRA_HOUR);
			int minute = Arguments.GetInt(EXTRA_MINUTE); 

			View v = Activity.LayoutInflater.Inflate(Resource.Layout.dialog_time, null);

			TimePicker timePicker = (TimePicker)v.FindViewById(Resource.Id.dialog_time_picker);
			timePicker.CurrentHour = (Java.Lang.Integer)hour;
			timePicker.CurrentMinute = (Java.Lang.Integer)minute;
			timePicker.SetOnTimeChangedListener(this);

			return new AlertDialog.Builder(Activity)
				.SetView(v)
				.SetTitle(Resource.String.time_picker_title)
				.SetPositiveButton(Android.Resource.String.Ok, (sender, e) => {
					Console.WriteLine("TimePicker OK Pressed");
					SendResult(CrimeFragment.RESULT_OK);
			}).Create();
		}

		public void OnTimeChanged(TimePicker view, int hour, int minute) {
			mDate = new DateTime(mDate.Year,  mDate.Month, mDate.Day, hour, minute, 0); 

			Arguments.PutInt(EXTRA_HOUR, mDate.Hour);
			Arguments.PutInt(EXTRA_MINUTE, mDate.Minute);

			Console.WriteLine("Time Changed: {0}", mDate.ToLongTimeString());
		}

		void SendResult(int resultCode) {
			if (TargetFragment == null)
				return;

			Intent i = new Intent();
			i.PutExtra(EXTRA_MINUTE, mDate.Minute);
			i.PutExtra(EXTRA_HOUR, mDate.Hour);

			TargetFragment.OnActivityResult(TargetRequestCode, resultCode, i);
		}

		public override void OnSaveInstanceState(Bundle outState)
		{
			base.OnSaveInstanceState(outState);

		}

		public override void OnViewStateRestored(Bundle savedInstanceState)
		{
			base.OnViewStateRestored(savedInstanceState);

		}
    }
}

				