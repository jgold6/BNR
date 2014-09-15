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
		#region - member variables
		Crime mCrime;
		EditText mTitleField;
		Button mDateButton;
		CheckBox mSolvedCheckBox;
		#endregion

		#region - Lifecycle
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
			mCrime = new Crime();

        }

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_crime, container, false);
			mTitleField = (EditText)v.FindViewById(Resource.Id.crime_title_edittext);
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
			mSolvedCheckBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
				mCrime.Solved = e.IsChecked;
				Console.WriteLine("IsChecked: {0}", e.IsChecked);
			};

			return v;
		}
		#endregion
    }
}

