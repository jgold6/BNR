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
		public static readonly int REQUEST_DATE = 0;
		public static readonly int RESULT_OK = 1;
		#endregion

		#region - member variables
		Crime mCrime;
		EditText mTitleField;
		Button mDateButton;
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

			mDateButton = (Button)v.FindViewById(Resource.Id.crime_date_button);
			UpdateDate();
			mDateButton.Click += (sender, e) => {
				FragmentManager fm = Activity.SupportFragmentManager;
				DatePickerFragment dialog = DatePickerFragment.NewInstance(mCrime.Date);
				dialog.SetTargetFragment(this, REQUEST_DATE);
				dialog.Show(fm, CrimeFragment.DIALOG_DATE);
			};

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
				mCrime.Date = new DateTime(year, month, day);
				UpdateDate();

			}
		}

		public void UpdateDate() {
			mDateButton.Text = mCrime.Date.ToLongDateString();
		}
    }
}

