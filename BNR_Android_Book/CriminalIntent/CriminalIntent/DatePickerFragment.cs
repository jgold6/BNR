using System;
using Android.Support.V4.App;
using Android.App;
using Android.Views;
using Android.OS;
using Android.Widget;
using Android.Content;

namespace CriminalIntent
{
	public class DatePickerFragment : Android.Support.V4.App.DialogFragment, DatePicker.IOnDateChangedListener
    {
		public static string EXTRA_YEAR = "com.onobytes.criminalintent.year";
		public static string EXTRA_MONTH = "com.onobytes.criminalintent.month";
		public static string EXTRA_DAY = "com.onobytes.criminalintent.day";

		DateTime mDate;

		private DatePickerFragment() {}

		public static DatePickerFragment NewInstance(DateTime date)
		{
			DatePickerFragment fragment = new DatePickerFragment();
			fragment.mDate = date;

			Bundle args = new Bundle();
			args.PutInt(EXTRA_YEAR, date.Year);
			args.PutInt(EXTRA_MONTH, date.Month);
			args.PutInt(EXTRA_DAY, date.Day);
			fragment.Arguments = args;

			return fragment;
		}

		public override Android.App.Dialog OnCreateDialog(Android.OS.Bundle savedInstanceState)
		{
			int year = Arguments.GetInt(EXTRA_YEAR);
			int month = Arguments.GetInt(EXTRA_MONTH); 
			int day = Arguments.GetInt(EXTRA_DAY);

			View v = Activity.LayoutInflater.Inflate(Resource.Layout.dialog_date, null);

			DatePicker datePicker = (DatePicker)v.FindViewById(Resource.Id.dialog_date_picker);
			datePicker.Init(year, month -1, day, this); // .NET uses 1 based months, Android uses 0 based months

			return new AlertDialog.Builder(Activity)
				.SetView(v)
				.SetTitle(Resource.String.date_picker_title)
				.SetPositiveButton(Android.Resource.String.Ok, (sender, e) => {
					Console.WriteLine("OK Pressed");
					SendResult(CrimeFragment.RESULT_OK);
			}).Create();
		}

		public void OnDateChanged(DatePicker view, int year, int month, int day) {
			mDate = new DateTime(year, month +1, day); // .NET uses 1 based months, Android uses 0 based months

			Arguments.PutInt(EXTRA_YEAR, mDate.Year);
			Arguments.PutInt(EXTRA_MONTH, mDate.Month);
			Arguments.PutInt(EXTRA_DAY, mDate.Day);

			Console.WriteLine("Date Changed: {0}", mDate.ToLongDateString());
		}

		void SendResult(int resultCode) {
			if (TargetFragment == null)
				return;

			Intent i = new Intent();
			i.PutExtra(EXTRA_YEAR, mDate.Year);
			i.PutExtra(EXTRA_MONTH, mDate.Month);
			i.PutExtra(EXTRA_DAY, mDate.Day);

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

				