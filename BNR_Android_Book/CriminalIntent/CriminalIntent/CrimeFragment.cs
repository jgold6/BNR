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
			mTitleField = (EditText)v.FindViewById(Resource.Id.crime_title);
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

			return v;
		}
		#endregion
    }
}

