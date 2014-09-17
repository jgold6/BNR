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
			Activity.SetTitle(Resource.String.crime_title);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
				Activity.ActionBar.SetSubtitle(Resource.String.title_activity_crime);
            // Create your fragment here
			string crimeId = Activity.Intent.GetStringExtra(EXTRA_CRIME_ID);
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
			mDateButton.Text = mCrime.Date.ToLongDateString();
			mDateButton.Enabled = false;

			mSolvedCheckBox = (CheckBox)v.FindViewById(Resource.Id.crime_solved_checkbox);
			mSolvedCheckBox.Checked = mCrime.Solved;
			mSolvedCheckBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
				mCrime.Solved = e.IsChecked;
				Console.WriteLine("IsChecked: {0}", e.IsChecked);
			};

			return v;
		}
		#endregion
    }
}

