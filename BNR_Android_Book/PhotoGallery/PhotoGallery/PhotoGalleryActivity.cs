using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PhotoGallery
{
	[Activity(Label = "PhotoGallery", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/AppTheme")]
	public class PhotoGalleryActivity : SingleFragmentActivity
    {
		public static PhotoGalleryActivity Context {get; private set;}

		#region - abstract overrides
		protected override Fragment CreateFragment()
		{
			PhotoGalleryActivity.Context = this;

			return new PhotoGalleryFragment();
		}
		#endregion
	}
}


