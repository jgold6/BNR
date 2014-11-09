using System;
using Android.App;
using Android.Widget;
using Android.Views;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Util;

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
//			Console.WriteLine("[{0}] OnCreate Called: {1}", TAG, DateTime.Now.ToLongTimeString());
			base.OnCreate(savedInstanceState);
			RetainInstance = true;

			currentPage = 1;
			endReached = false;
			FlickrFetchr fetchr = new FlickrFetchr();

			ProgressDialog pg = new ProgressDialog(Activity);
			pg.SetMessage("This may take a minute or two");
			pg.SetTitle("Loading Images");
			pg.SetCancelable(false);
			pg.Show();

			galleryItems = await fetchr.Fetchitems(currentPage.ToString());
//			foreach (GalleryItem item in galleryItems) {
//				Console.WriteLine("[{0}]\nPhoto Id: {1}\nCaption: {2}\nUrl: {3}", TAG, item.Id, item.Caption, item.Url);
//			}

			pg.Dismiss();

			SetupAdapter();
//			Console.WriteLine("[{0}] OnCreate Done: {1}", TAG, DateTime.Now.ToLongTimeString());
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
//			Console.WriteLine("[{0}] OnCreateView Called: {1}", TAG, DateTime.Now.ToLongTimeString());
			View v = inflater.Inflate(Resource.Layout.fragment_photo_gallery, container, false);

			mGridView = v.FindViewById<GridView>(Resource.Id.gridView);

			mGridView.Scroll += async (object sender, AbsListView.ScrollEventArgs e) => {
				if (e.FirstVisibleItem + e.VisibleItemCount == e.TotalItemCount && !endReached && e.TotalItemCount > 0) {
					endReached = true;
//					Console.WriteLine("[{0}] Scroll Ended", TAG);
					currentPage++;
					List<GalleryItem> newItems = await new FlickrFetchr().Fetchitems(currentPage.ToString());
					galleryItems = galleryItems.Concat(newItems).ToList();
					var adapter = (ArrayAdapter)mGridView.Adapter;
					adapter.AddAll(newItems);
					adapter.NotifyDataSetChanged();
					endReached = false;
				}
			};

			mGridView.ScrollStateChanged += (object sender, AbsListView.ScrollStateChangedEventArgs e) => {
				var adapter = (ArrayAdapter)mGridView.Adapter;
				if (e.ScrollState == ScrollState.Idle) {
					Task.Run(async () => {
						await new FlickrFetchr().PreloadImages(mGridView.FirstVisiblePosition, mGridView.LastVisiblePosition, galleryItems);
					});
				}
			};

			SetupAdapter();
//			Console.WriteLine("[{0}] OnCreateView Done: {1}", TAG, DateTime.Now.ToLongTimeString());
			return v;
		}

		void SetupAdapter() {
			if (Activity == null || mGridView == null) return;

			if (galleryItems != null) {
				var adapter = new GalleryItemAdapter(Activity, galleryItems);
				mGridView.Adapter = adapter;
				Task.Run(async () => {
					Display display = Activity.WindowManager.DefaultDisplay;
					DisplayMetrics outMetrics = new DisplayMetrics();
					display.GetMetrics(outMetrics);

					float density = Activity.Resources.DisplayMetrics.Density;
					var height = outMetrics.HeightPixels / density;
					var width = outMetrics.WidthPixels / density;

					int itemsPerRow = (int)Math.Round(width/120);
					int numRows = (int)Math.Round(height/120);
					int numItems = itemsPerRow * numRows;

					await new FlickrFetchr().PreloadImages(0, numItems, galleryItems).ConfigureAwait(false);
				});
			}
			else {
				mGridView.Adapter = null;
			}

		}
    }

	public class GalleryItemAdapter : ArrayAdapter<GalleryItem>
	{
		Activity context;

		public GalleryItemAdapter(Activity context, List<GalleryItem> items) : base(context, 0 , items)
		{
			this.context = context;
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			// Recycle
//			View view = convertView;
//			if (view == null) {
//				view = context.LayoutInflater.Inflate(Resource.Layout.gallery_item, parent, false);
//			}

			// Don't recycle
			View view = context.LayoutInflater.Inflate(Resource.Layout.gallery_item, parent, false);

			ImageView imageView = view.FindViewById<ImageView>(Resource.Id.gallery_item_imageView);
			imageView.SetImageResource(Resource.Drawable.face_icon);

			GalleryItem item = GetItem(position);
			Task.Run(async () => {
				Bitmap image = await new FlickrFetchr().GetImageBitmapAsync(item.Url, position).ConfigureAwait(false);
				context.RunOnUiThread(() => {
					imageView.SetImageBitmap(image);
				});
			});

			return view;
		}


	}
}

