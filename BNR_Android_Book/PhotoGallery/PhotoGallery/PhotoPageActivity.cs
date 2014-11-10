using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Preferences;
using Android.Content.PM;

namespace PhotoGallery
{
	[Activity(Label = "PhotoPageActivity", ConfigurationChanges=ConfigChanges.Orientation|ConfigChanges.ScreenSize|ConfigChanges.KeyboardHidden)]            
	public class PhotoPageActivity : SingleFragmentActivity
    {
		private static readonly string TAG = "PhotoPageActivity";

		#region - abstract overrides
		protected override Fragment CreateFragment()
		{
			return new PhotoPageFragment();
		}
		#endregion
    }
}

