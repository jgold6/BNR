using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Preferences;

namespace PhotoGallery
{
    [Activity(Label = "PhotoActivity")]            
	public class PhotoActivity : SingleFragmentActivity
    {
		private static readonly string TAG = "PhotoActivity";

		#region - abstract overrides
		protected override Fragment CreateFragment()
		{
			return new PhotoFragment();
		}
		#endregion
    }
}

