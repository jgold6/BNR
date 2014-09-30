using System;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Graphics;
using Android.Widget;

namespace CriminalIntent
{
    public class PictureUtils
    {
		// Get a bitmap drawable from a local file that is scaled down
		// to fit the current window size
		public static BitmapDrawable GetScaledDrawable(Activity a, string path) 
		{
			Display display = a.WindowManager.DefaultDisplay;
			float destWidth = display.Width;
			float destHeight = display.Height;

			// Read in the dimensions of the image on disk
			BitmapFactory.Options options = new BitmapFactory.Options();
			options.InJustDecodeBounds = true;
			BitmapFactory.DecodeFile(path, options);

			float srcWidth = options.OutWidth;
			float srcHeight = options.OutHeight;

			int inSampleSize = 1;
			if (srcHeight > destHeight || srcWidth > destWidth) {
				if (srcWidth > srcHeight) {
					inSampleSize = (int)Math.Round(srcHeight / destHeight);
				}
				else {
					inSampleSize = (int)Math.Round(srcWidth / destWidth);
				}
			}

			options = new BitmapFactory.Options();
			options.InSampleSize = inSampleSize;

			Bitmap bitmap = BitmapFactory.DecodeFile(path, options);
			return new BitmapDrawable(a.Resources, bitmap);
		}

		public static void CleanImageView(ImageView imageView)
		{
			if (imageView == null || imageView.Drawable == null || imageView.Drawable.GetType() != typeof(BitmapDrawable))
				return;

			// Clean up the view's image for the sake of memory
			BitmapDrawable b = (BitmapDrawable)imageView.Drawable;
			b.Bitmap.Recycle();
			imageView.SetImageDrawable(null);
		}
    }
}

