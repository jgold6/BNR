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
	[Activity(Label = "PhotoGallery", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/AppTheme", LaunchMode=Android.Content.PM.LaunchMode.SingleTop)]
	[IntentFilter (new[]{Intent.ActionSearch})]
	[MetaData("android.app.searchable", Resource="@xml/searchable")]
	public class PhotoGalleryActivity : SingleFragmentActivity
    {
		private static readonly string TAG = "PhotoGalleryActivity";

		#region - abstract overrides
		protected override Fragment CreateFragment()
		{
			return new PhotoGalleryFragment();
		}

		protected override async void OnNewIntent(Intent intent)
		{
			PhotoGalleryFragment fragment = (PhotoGalleryFragment)FragmentManager.FindFragmentById(Resource.Id.fragmentContainer);
			if (Intent.ActionSearch.Equals(intent.Action)) {
				string query = intent.GetStringExtra(SearchManager.Query);
				Console.WriteLine("[{0}] Received a new search query: {1}", TAG, query);

				PreferenceManager.GetDefaultSharedPreferences(this).Edit().PutString(FlickrFetchr.PREF_SEARCH_QUERY, query).Commit();
			}
			await fragment.UpdateItems();
		}

		#endregion
	}
}


