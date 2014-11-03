using System;
using Android.App;
using Android.Widget;
using Android.Views;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace PhotoGallery
{
    public class PhotoGalleryFragment : Fragment
    {
		private static readonly string TAG = "PhotoGalleryFragment";

		GridView mGridView;
		List<GalleryItem> galleryItems;
		int currentPage;
		bool endReached;

		public override async void OnCreate(Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			RetainInstance = true;

			currentPage = 1;
			endReached = false;
			galleryItems = await new FlickrFetchr().Fetchitems(currentPage.ToString());
//			foreach (GalleryItem item in galleryItems) {
//				Console.WriteLine("[{0}]\nPhoto Id: {1}\nCaption: {2}\nUrl: {3}", TAG, item.Id, item.Caption, item.Url);
//			}
			SetupAdapter();
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View v = inflater.Inflate(Resource.Layout.fragment_photo_gallery, container, false);

			mGridView = v.FindViewById<GridView>(Resource.Id.gridView);

			mGridView.Scroll += async (object sender, AbsListView.ScrollEventArgs e) => {
				if (e.FirstVisibleItem + e.VisibleItemCount == e.TotalItemCount && !endReached && e.TotalItemCount > 0) {
					endReached = true;
					Console.WriteLine("[{0}] Scroll Ended", TAG);
					currentPage++;
					List<GalleryItem> newItems = await new FlickrFetchr().Fetchitems(currentPage.ToString());
					galleryItems = galleryItems.Concat(newItems).ToList();
					var adapter = (ArrayAdapter)mGridView.Adapter;
					adapter.AddAll(newItems);
					adapter.NotifyDataSetChanged();
					endReached = false;
				}
			};
			 
			SetupAdapter();

			return v;
		}

		void SetupAdapter() {
			if (Activity == null || mGridView == null) return;

			if (galleryItems != null) {
				mGridView.Adapter = new ArrayAdapter<GalleryItem>(Activity, Android.Resource.Layout.SimpleGalleryItem, galleryItems);
			}
			else {
				mGridView.Adapter = null;
			}

		}
    }
}

