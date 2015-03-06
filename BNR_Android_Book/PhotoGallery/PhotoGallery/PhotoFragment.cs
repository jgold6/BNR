using System;
using Android.App;
using Android.Widget;
using Android.Views;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Util;
using Android.Preferences;
using Android.OS;
using Android.Content;
using System.Threading;

namespace PhotoGallery
{
	public class PhotoFragment : VisibleFragment
    {
		private static readonly string TAG = "PhotoFragment";

		ImageView mImageView;
		string photoUrl;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
			RetainInstance = true;
            // Create your fragment here
        }

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			//			Console.WriteLine("[{0}] OnCreateView Called: {1}", TAG, DateTime.Now.ToLongTimeString());
			View v = inflater.Inflate(Resource.Layout.fragment_photo, container, false);

			mImageView = v.FindViewById<ImageView>(Resource.Id.photoView);

			photoUrl = Activity.Intent.GetStringExtra(PhotoGalleryFragment.PHOTO_URL_EXTRA);

			photoUrl = photoUrl.Substring(0, photoUrl.Length-6) + ".jpg";

			ProgressDialog pg = new ProgressDialog(Activity);
			pg.SetMessage(Resources.GetString(Resource.String.loading_photo_message));
			pg.SetTitle(Resources.GetString(Resource.String.loading_photo_title));
			pg.SetCancelable(false);
			pg.Show();

			Task.Run(async () => {
				Bitmap image = await new FlickrFetchr().GetImageBitmapAsync(photoUrl, 0, new CancellationTokenSource().Token).ConfigureAwait(false);
				Activity.RunOnUiThread(() => {
					mImageView.SetImageBitmap(image);
					//Console.WriteLine("[{0}] File created: {1}", TAG, photoUrl);
					pg.Dismiss();
				});
			});

			return v;
		}

		public override void OnDestroyView()
		{
			base.OnDestroyView();
			new FlickrFetchr().DeleteImageFile(photoUrl);
			//Console.WriteLine("[{0}] File deleted: {1}", TAG, photoUrl);
			mImageView = null;
		}
    }
}

