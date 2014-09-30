
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics.Drawables;

namespace CriminalIntent
{
	public class ImageFragment : Android.Support.V4.App.DialogFragment
    {
		public static readonly string EXTRA_IMAGE_PATH = "com.onobytes.criminalintent.image_path";

		ImageView mImageView;

		public static ImageFragment NewInstance(string imagePath)
		{
			Bundle args = new Bundle();
			args.PutString(EXTRA_IMAGE_PATH, imagePath);

			ImageFragment fragment = new ImageFragment();
			fragment.Arguments = args;
			fragment.SetStyle((int)DialogFragmentStyle.NoTitle, 0);

			return fragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			mImageView = new ImageView(Activity);
			string path = Arguments.GetString(EXTRA_IMAGE_PATH);
			BitmapDrawable image = PictureUtils.GetScaledDrawable(Activity, path);

			mImageView.SetImageDrawable(image);

			return mImageView;
		}

		public override void OnDestroyView()
		{
			base.OnDestroyView();
			PictureUtils.CleanImageView(mImageView);
		}
    }
}

