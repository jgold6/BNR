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
using Android.Content.PM;
using Android.App;
using Android.Graphics.Drawables;
using System.IO;
using Android.Graphics;
using Android.Provider;
using Android.Media;

#endregion

namespace CriminalIntent
{
	public static class PhotoApp{
		public static Java.IO.File _file;
		public static Java.IO.File _dir;     
//		public static BitmapDrawable bitmap;
	}

	public enum PhotoOrienation {
		Normal = 1,
		Rotate180 = 3,
		Rotate90 = 6,
		Rotate270 = 8
	}

	public class CrimeFragment : Android.Support.V4.App.Fragment
    {
		#region - Static Members
		private static readonly string TAG = "CrimeFragment";
		private static readonly string DIALOG_IMAGE = "image";
		public static readonly string EXTRA_CRIME_ID = "com.onobytes.criminalintent.crime_id";
		public static readonly string DIALOG_DATE = "com.onobytes.criminalintent.dialog_date";
		public static readonly string DIALOG_TIME = "com.onobytes.criminalintent.dialog_time";
		public static readonly int REQUEST_DATE = 0;
		public static readonly int REQUEST_TIME = 1;
		public static readonly int REQUEST_PHOTO = 3;
		#endregion

		#region - member variables
		Crime mCrime;
		EditText mTitleField;
		Button mDateButton;
//		Button mTimeButton; // Separate date and time buttons
		CheckBox mSolvedCheckBox;
		ImageButton mPhotoButton;
		ImageView mPhotoView;
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
			// Title set in CrimePagerActivity when page is selected
//			Activity.SetTitle(Resource.String.crime_title);
			// Subtitle not used in this fragment
//			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
//				Activity.ActionBar.SetSubtitle(Resource.String.title_activity_crime);

            // Create your fragment here
			string crimeId = Arguments.GetString(EXTRA_CRIME_ID);
			mCrime = CrimeLab.GetInstance(Activity).GetCrime(crimeId);
			HasOptionsMenu = true;
        }

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_crime, container, false);

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb) {
				// Using ParentActivity and NavUtils causes OnCreate to be called again
				// in CrimeListFragment, causing the subtitle view to be reset
//				if (NavUtils.GetParentActivityName(Activity) != null) {
					Activity.ActionBar.SetDisplayHomeAsUpEnabled(true);
//				}
			}

			mTitleField = (EditText)v.FindViewById(Resource.Id.crime_title_edittext);
			mTitleField.SetText(mCrime.Title, TextView.BufferType.Normal);
			mTitleField.BeforeTextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				// nothing for now
			};
			mTitleField.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				mCrime.Title = e.Text.ToString();
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
					Android.Support.V4.App.FragmentManager fm = Activity.SupportFragmentManager;
					DatePickerFragment dialog = DatePickerFragment.NewInstance(mCrime.Date);
					dialog.SetTargetFragment(this, REQUEST_DATE);
					dialog.Show(fm, CrimeFragment.DIALOG_DATE);
				});
				builder.SetNegativeButton(Resource.String.date_or_time_alert_time, (object time, DialogClickEventArgs de) => {
					Android.Support.V4.App.FragmentManager fm = Activity.SupportFragmentManager;
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
			};

			mPhotoView = v.FindViewById<ImageView>(Resource.Id.crime_imageView);
			mPhotoView.Click += (object sender, EventArgs e) => {
				Photo p = mCrime.Photo;
				if (p == null)
					return;
				Android.Support.V4.App.FragmentManager fm = Activity.SupportFragmentManager;

				// BNR
//				string path = Activity.GetFileStreamPath(p.Filename).AbsolutePath;
				if (p.Filename != null)
					ImageFragment.NewInstance(p.Filename, p.GetRotation()).Show(fm, DIALOG_IMAGE);
			};

			// From Xamarin guide
			mPhotoButton = v.FindViewById<ImageButton>(Resource.Id.crime_imageButton);
			if (IsAppToTakePicture()) {

				CreateDirectoryForPictures();

				mPhotoButton.Click += (object sender, EventArgs e) => {
					// From xamarin guide
					Intent intent = new Intent(MediaStore.ActionImageCapture);

					PhotoApp._file = new Java.IO.File(PhotoApp._dir, String.Format("{0}.jpg", Guid.NewGuid()));

					intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(PhotoApp._file));

					StartActivityForResult(intent, REQUEST_PHOTO);

					// From BNR Book - trying Xamarin method above
//					Intent i = new Intent(Activity, typeof(CrimeCameraActivity));
//					StartActivityForResult(i, REQUEST_PHOTO);
				};
			}
			// If camera is not available, disable button - checked in the if statement above
//			PackageManager pm = Activity.PackageManager;
//			if (!pm.HasSystemFeature(PackageManager.FeatureCamera) && !pm.HasSystemFeature(PackageManager.FeatureCameraFront)) {
//				mPhotoButton.Enabled = false;
//			}

			return v;
		}

		public override void OnStart()
		{
			base.OnStart();
			ShowPhoto();
		}

		public override void OnPause()
		{
			base.OnPause();
			CrimeLab.GetInstance(Activity).SaveCrimes();
		}

		public override void OnStop()
		{
			base.OnStop();
			PictureUtils.CleanImageView(mPhotoView);
		}

		#endregion

		#region - overrides
		public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater) {
			// Inflate the menu; this adds items to the action bar if it is present.
			base.OnCreateOptionsMenu(menu, inflater);
			inflater.Inflate(Resource.Menu.crime_list_item_context, menu);
		}

		public override bool OnOptionsItemSelected(IMenuItem item) {
			switch (item.ItemId) {
				case Resource.Id.menu_item_delete_crime:
					CrimeLab crimelab = CrimeLab.GetInstance(Activity);
					crimelab.DeleteCrime(mCrime);
					// Using ParentActivity and NavUtils causes OnCreate to be called again
					// in CrimeListFragment, causing the subtitle view to be reset
//					if (NavUtils.GetParentActivityName(Activity) != null) {
//						NavUtils.NavigateUpFromSameTask(Activity);
//					}
					Activity.Finish();
					return true;
				case Android.Resource.Id.Home:
					// Using ParentActivity and NavUtils causes OnCreate to be called again
					// in CrimeListFragment, causing the subtitle view to be reset
//					if (NavUtils.GetParentActivityName(Activity) != null) {
//						NavUtils.NavigateUpFromSameTask(Activity);
//					}
					Activity.Finish();
					return true;
				default:
					return base.OnOptionsItemSelected(item);
			}
		}

		#endregion

		#region - Event handlers
		public override void OnActivityResult(int requestCode, int resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (resultCode != (int)Result.Ok)
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
			else if (requestCode == REQUEST_PHOTO) {
				// From Xamarin guide - 
//				int height = Resources.DisplayMetrics.HeightPixels;
//				int width = mPhotoView.Width;
//				PhotoApp.bitmap = PhotoApp._file.Path.LoadAndResizeBitmap (width, height);

				// From BNR
				if (PhotoApp._file != null) {
//					PhotoApp.bitmap = PictureUtils.GetScaledDrawable(Activity, PhotoApp._file.Path);
					mCrime.Photo = new Photo(PhotoApp._file.Path);

					// Get and set picture orienation
					ExifInterface exif = new ExifInterface(mCrime.Photo.Filename);
					mCrime.Photo.Orientation = exif.GetAttributeInt(ExifInterface.TagOrientation, (int)PhotoOrienation.Normal);

					ShowPhoto();
					System.Diagnostics.Debug.WriteLine(String.Format("Crime '{0}' has a photo at: {1}", mCrime.Title, mCrime.Photo.Filename), TAG);
				}

				// From BNR book - trying Xamarin Method from guide
				// Create a new photo object and attach it to the crime
//				string filename = data.GetStringExtra(CrimeCameraFragment.EXTRA_PHOTO_FILENAME);
//				if (filename != null) {
//					mCrime.Photo = new Photo(filename);
//					ShowPhoto();
//					System.Diagnostics.Debug.WriteLine(String.Format("Crime '{0}' has a photo at: {1}", mCrime.Title, mCrime.Photo.Filename), TAG);
//				}
			}
		}

		#endregion

		#region - Helper Methods
		public void UpdateDateTime() {
			// One DateTime Button
			mDateButton.Text = String.Format("{0}\n{1}", mCrime.Date.ToLongDateString(), mCrime.Date.ToLongTimeString());
			// Separate date and time buttons
//			mDateButton.Text = mCrime.Date.ToLongDateString();
//			mTimeButton.Text = mCrime.Date.ToLongTimeString(); 

		}

		private bool IsAppToTakePicture()
		{
			Intent intent = new Intent(MediaStore.ActionImageCapture);
			PackageManager pm = Activity.PackageManager;
			IList<ResolveInfo> availableActivities = pm.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
			return availableActivities != null && availableActivities.Count > 0;
		}

		private void CreateDirectoryForPictures()
		{
			PhotoApp._dir = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryPictures), "CriminalIntent");
			if (!PhotoApp._dir.Exists())
			{
				PhotoApp._dir.Mkdirs();
			}
		}

		private void ShowPhoto() 
		{
			// (Re)set the image button's image based on our photo
			Photo p = mCrime.Photo;
			BitmapDrawable b = null;

			if (p != null) {
				//string path = Activity.GetFileStreamPath(p.Filename).AbsolutePath;
				b = PictureUtils.GetScaledDrawable(Activity, mCrime.Photo.Filename);

				// Set orientation for display
				mPhotoView.SetImageDrawable(b);
				mPhotoView.Rotation = mCrime.Photo.GetRotation();

				System.Diagnostics.Debug.WriteLine(String.Format("Photo path: {0}", mCrime.Photo.Filename), TAG);
			}
		}
		#endregion
    }

	// From Xamarin guide - use GetScaledDrawable from BNR instead - example of extension method
//	public static class BitmapHelpers
//	{
//		public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
//		{
//			// First we get the the dimensions of the file on disk
//			BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
//			BitmapFactory.DecodeFile(fileName, options);
//
//			// Next we calculate the ratio that we need to resize the image by
//			// in order to fit the requested dimensions.
//			int outHeight = options.OutHeight;
//			int outWidth = options.OutWidth;
//			int inSampleSize = 1;
//
//			if (outHeight > height || outWidth > width)
//			{
//				inSampleSize = outWidth > outHeight
//					? outHeight / height
//					: outWidth / width;
//			}
//
//			// Now we will load the image and have BitmapFactory resize it for us.
//			options.InSampleSize = inSampleSize;
//			options.InJustDecodeBounds = false;
//			Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);
//
//			return resizedBitmap;
//		}
//	}
}

