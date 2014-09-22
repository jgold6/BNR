#region - using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

#endregion

namespace CriminalIntent
{
	public class CrimeFragment : Fragment
    {
		#region - Sataic Members
		public static readonly string EXTRA_CRIME_ID = "com.onobytes.criminalintent.crime_id";
		public static readonly string DIALOG_DATE = "com.onobytes.criminalintent.dialog_date";
		public static readonly string DIALOG_TIME = "com.onobytes.criminalintent.dialog_time";
		public static readonly int REQUEST_DATE = 0;
		public static readonly int REQUEST_TIME = 1;
		public static readonly int RESULT_OK = 2;
		#endregion

		#region - member variables
		Crime mCrime;
		EditText mTitleField;
		Button mDateButton;
//		Button mTimeButton; // Separate date and time buttons
		CheckBox mSolvedCheckBox;
		#endregion

		#region - constructor ... kind of.
		public static CrimeFragment NewInstance(string guid)
		{
			Bundle args = new Bundle();
			args.PutString(EXTRA_CRIME_ID, guid);

			CrimeFragment fragment = new CrimeFragment();
			fragment.Arguments = args;

			return fragment;
		}
		#endregion

		#region - Lifecycle
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			//Activity.SetTitle(Resource.String.crime_title);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				Activity.ActionBar.SetSubtitle(Resource.String.title_activity_crime);
            // Create your fragment here
			string crimeId = Arguments.GetString(EXTRA_CRIME_ID);
			mCrime = CrimeLab.GetInstance(Activity).GetCrime(crimeId);
        }

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_crime, container, false);
			mTitleField = (EditText)v.FindViewById(Resource.Id.crime_title_edittext);
			mTitleField.SetText(mCrime.Title, TextView.BufferType.Normal);
			mTitleField.BeforeTextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				// nothing for now
			};
			mTitleField.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				mCrime.Title = e.Text.ToString();
				Console.WriteLine(mCrime.Title);
			};
			mTitleField.AfterTextChanged += (object sender, Android.Text.AfterTextChangedEventArgs e) => {
				// nothing for now
			};

			// One DateTime Button
			mDateButton = (Button)v.FindViewById(Resource.Id.crime_date_button);
			mDateButton.Click += (sender, e) => {
				Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(Activity);
				builder.SetTitle(Resource.String.date_or_time_alert_title);
				builder.SetPositiveButton(Resource.String.date_or_time_alert_date, (object date, DialogClickEventArgs de) => {
					FragmentManager fm = Activity.SupportFragmentManager;
					DatePickerFragment dialog = DatePickerFragment.NewInstance(mCrime.Date);
					dialog.SetTargetFragment(this, REQUEST_DATE);
					dialog.Show(fm, CrimeFragment.DIALOG_DATE);
				});
				builder.SetNegativeButton(Resource.String.date_or_time_alert_time, (object time, DialogClickEventArgs de) => {
					FragmentManager fm = Activity.SupportFragmentManager;
					TimePickerFragment dialog = TimePickerFragment.NewInstance(mCrime.Date);
					dialog.SetTargetFragment(this, REQUEST_TIME);
					dialog.Show(fm, CrimeFragment.DIALOG_TIME);
				});
				builder.Show();
					
			};

			// Separate date and time buttons
//			mDateButton = (Button)v.FindViewById(Resource.Id.crime_date_button);
//			mDateButton.Click += (sender, e) => {
//				FragmentManager fm = Activity.SupportFragmentManager;
//				DatePickerFragment dialog = DatePickerFragment.NewInstance(mCrime.Date);
//				dialog.SetTargetFragment(this, REQUEST_DATE);
//				dialog.Show(fm, CrimeFragment.DIALOG_DATE);
//			};
//
//			mTimeButton = (Button)v.FindViewById(Resource.Id.crime_time_button);
//			mTimeButton.Click += (sender, e) => {
//				FragmentManager fm = Activity.SupportFragmentManager;
//				TimePickerFragment dialog = TimePickerFragment.NewInstance(mCrime.Date);
//				dialog.SetTargetFragment(this, REQUEST_TIME);
//				dialog.Show(fm, CrimeFragment.DIALOG_TIME);
//			};

			UpdateDateTime();

			mSolvedCheckBox = (CheckBox)v.FindViewById(Resource.Id.crime_solved_checkbox);
			mSolvedCheckBox.Checked = mCrime.Solved;
			mSolvedCheckBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
				mCrime.Solved = e.IsChecked;
				Console.WriteLine("IsChecked: {0}", e.IsChecked);
			};

			return v;
		}
		#endregion

		public override void OnActivityResult(int requestCode, int resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (resultCode != CrimeFragment.RESULT_OK)
				return;
			if (requestCode == REQUEST_DATE) {
				int year = data.GetIntExtra(DatePickerFragment.EXTRA_YEAR, DateTime.Now.Year);
				int month = data.GetIntExtra(DatePickerFragment.EXTRA_MONTH,DateTime.Now.Month);
				int day = data.GetIntExtra(DatePickerFragment.EXTRA_DAY, DateTime.Now.Day);
				mCrime.Date = new DateTime(year, month, day, mCrime.Date.Hour, mCrime.Date.Minute, 0);
				UpdateDateTime();

			}
			else if (requestCode == REQUEST_TIME) {
				int hour = data.GetIntExtra(TimePickerFragment.EXTRA_HOUR, DateTime.Now.Hour);
				int minute = data.GetIntExtra(TimePickerFragment.EXTRA_MINUTE, DateTime.Now.Minute);
				mCrime.Date = new DateTime(mCrime.Date.Year, mCrime.Date.Month, mCrime.Date.Day, hour, minute, 0);
				UpdateDateTime();

			}
		}

		public void UpdateDateTime() {
			// One DateTime Button
			mDateButton.Text = String.Format("{0}\n{1}", mCrime.Date.ToLongDateString(), mCrime.Date.ToLongTimeString());
			// Separate date and time buttons
//			mDateButton.Text = mCrime.Date.ToLongDateString();
//			mTimeButton.Text = mCrime.Date.ToLongTimeString(); 

		}
    }
}

