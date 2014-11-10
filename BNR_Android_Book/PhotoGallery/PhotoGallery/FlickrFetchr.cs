using System;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Android.Graphics;
using Android.Widget;

namespace PhotoGallery
{
    public class FlickrFetchr
    {
		#region - Static members
		private static readonly string TAG = "FlickrFetchr";
		private static readonly string baseUrl = "https://api.flickr.com/services/rest/";
		private static readonly string apiKey = "api_key";
		private static readonly string flickrAPIKey = "ea248fbeac480b7c14fce5cece516ef0";
		private static readonly string method = "method";
		private static readonly string methodGetRecent = "flickr.photos.getRecent";
		private static readonly string methodSearch = "flickr.photos.search";
		private static readonly string paramExtras = "extras";
		private static readonly string extraSmallUrl = "url_s";
		private static readonly string paramText = "text";
		private static readonly string paramPage = "page";
		private static readonly string paramPerPage = "per_page";
		private static readonly string itemsPerPage = "20";

		public static readonly string PREF_SEARCH_QUERY = "searchQuery";
		public static readonly string PREF_LAST_RESULT_ID = "lastResultId";
		public uint NumberOfHits {get; set;}
		#endregion

		async Task<byte[]> GetUrlBytesAsync(string url) {
//			Console.WriteLine("[{0}] Start GetUrlBytesAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
			byte[] result = null;
			try {
				using (HttpClient httpCLient = new HttpClient())
				using (HttpResponseMessage response = await httpCLient.GetAsync(url).ConfigureAwait(false))
				using (HttpContent content = response.Content)
				{
					result = await content.ReadAsByteArrayAsync().ConfigureAwait(false);
				}
			}
			catch (Exception ex) {
				Console.WriteLine("Excpetion: {0}", ex.Message);
			}
//			Console.WriteLine("[{0}] End GetUrlBytesAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
			return result;
		}

		public async Task<string> GetUrlAsync(string url)
		{
//			Console.WriteLine("[{0}] Start GetUrlAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
			string result = "";
			byte[] bytes = await GetUrlBytesAsync(url).ConfigureAwait(false);
			foreach (byte bit in bytes) {
				result += Convert.ToChar(bit);
			}
//			Console.WriteLine("[{0}] End GetUrlAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
			return result;
		}

		public async Task<Bitmap> GetImageBitmapAsync(string url, int position)
		{
//			Console.WriteLine("[{0}] Start GetImageBitmapAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
			Bitmap bitmap = null;
			string path = GetPathFromUrl(url);
			// Check for cached images on filesystem. Filename will be the last part of the url+.bytes.
			if (File.Exists(path)) {
				try {
					byte[] bitmapBytes = File.ReadAllBytes(path);
					bitmap = await BitmapFactory.DecodeByteArrayAsync(bitmapBytes, 0, bitmapBytes.Length).ConfigureAwait(false);
//					Console.WriteLine("[{0}] Bitmap created from cache: Position: {1}", TAG, position);
				}
				catch (Exception ex) {
					Console.WriteLine("[{0}] Bitmap creation from cache failed: {1}, Position: {2}", TAG, ex.Message, position);
				}
			}
			// If not, download and cache it.
			else {
				try {
					byte[] bitmapBytes = await GetUrlBytesAsync(url).ConfigureAwait(false);
					bitmap = await BitmapFactory.DecodeByteArrayAsync(bitmapBytes, 0, bitmapBytes.Length).ConfigureAwait(false);
					File.WriteAllBytes(path, bitmapBytes);
//					Console.WriteLine("[{0}] Bitmap created from url: Position: {1}", TAG, position);
				}
				catch (Exception ex) {
					Console.WriteLine("[{0}] Bitmap creation from url failed: {1}}, Position: {2}", TAG, ex.Message, position);
				}
			}
//			Console.WriteLine("[{0}] End GetImageBitmapAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
			return bitmap;
		}

		public async Task<List<GalleryItem>> Fetchitems(string pageNum = "1")
		{
			Console.WriteLine("[{0}] Start Fetchitems: {1}", TAG, DateTime.Now.ToLongTimeString());

			var builder = new UriBuilder(baseUrl);

			var query = HttpUtility.ParseQueryString(builder.Query);
			query[method] = methodGetRecent;
			query[apiKey] = flickrAPIKey;
			query[paramExtras] = extraSmallUrl;
			query[paramPage] = pageNum;
			query[paramPerPage] = itemsPerPage;
			builder.Query = query.ToString();

			string url = builder.ToString();
//			Console.WriteLine("[{0}] End Fetchitems: {1}", TAG, DateTime.Now.ToLongTimeString());
			return await DownloadGalleryItems(url).ConfigureAwait(false);
		}

		public async Task<List<GalleryItem>> Search(string queryText, string pageNum = "1")
		{
			Console.WriteLine("[{0}] Start Search: {1}", TAG, DateTime.Now.ToLongTimeString());

			var builder = new UriBuilder(baseUrl);

			var query = HttpUtility.ParseQueryString(builder.Query);
			query[method] = methodSearch;
			query[apiKey] = flickrAPIKey;
			query[paramExtras] = extraSmallUrl;
			query[paramText] = queryText;
			query[paramPage] = pageNum;
			query[paramPerPage] = itemsPerPage;
			builder.Query = query.ToString();

			string url = builder.ToString();
//			Console.WriteLine("[{0}] End Search: {1}", TAG, DateTime.Now.ToLongTimeString());
			return await DownloadGalleryItems(url).ConfigureAwait(false);
		}

		public async Task<List<GalleryItem>> DownloadGalleryItems(string url)
		{
//			Console.WriteLine("[{0}] Start DownloadGalleryItems: {1}", TAG, DateTime.Now.ToLongTimeString());
			List<GalleryItem> items = new List<GalleryItem>();

			try {

//				Console.WriteLine("[{0}] DownloadGalleryItems Start GetUrlAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
				string xmlString = await GetUrlAsync(url).ConfigureAwait(false);
//				Console.WriteLine("[{0}] DownloadGalleryItems End GetUrlAsync: {1}", TAG, DateTime.Now.ToLongTimeString());
//				Console.WriteLine("[{0}] Received xml from Url: {1}\n{2}", TAG, url, xmlString);
				Console.WriteLine("[{0}] Received xml from Url: {1}", TAG, url);
				//https://api.flickr.com:443/services/rest/?method=flickr.photos.getRecent&api_key=ea248fbeac480b7c14fce5cece516ef0&extras=url_s

				XmlSerializer serializer = new XmlSerializer(typeof(rsp));

//				Console.WriteLine("[{0}] Fetchitems Start Deserialzer: {1}", TAG, DateTime.Now.ToLongTimeString());
				using (var reader = new StringReader(xmlString)) {
					var rsp = (rsp)serializer.Deserialize(reader);
					NumberOfHits = rsp.photos.total;
					var photos = rsp.photos.photo;
					foreach (rspPhotosPhoto photo in photos) {
						//Console.WriteLine("[{0}]\nPhoto Id: {1}\nCaption: {2}\nUrl: {3}", TAG, photo.id, photo.title, photo.url_s);
						GalleryItem item = new GalleryItem(){
							Caption = photo.title,
							Id = photo.id.ToString(),
							Url = photo.url_s,
							Owner = photo.owner
						};
						items.Add(item);
					}
				}
//				Console.WriteLine("[{0}] Fetchitems End Deserialzer: {1}", TAG, DateTime.Now.ToLongTimeString());
			}
			catch (IOException ioex) {
				Console.WriteLine("[{0}] Failed to fetch items: {1}", TAG, ioex.Message);
			}
			catch (Exception ex){
				Console.WriteLine("[{0}] Failed to parse items: {1}", TAG, ex.Message);
			}

			Console.WriteLine("[{0}] End DownloadGalleryItems: {1}", TAG, DateTime.Now.ToLongTimeString());
			return items;
			// Using httpUtility to make query string... no ? added automatically
//			try {
//				var query = HttpUtility.ParseQueryString(string.Empty);
//				query["method"] = methodGetRecent;
//				query["api_key"] = flickrAPIKey;
//				query[paramExtras] = extraSmallUrl;
//
//				string url = baseUrl + query;
//				string xmlString = await GetUrlAsync(url).ConfigureAwait(false);
//				Console.WriteLine("[{0}] Received xml from Url: {1}\n{2}", TAG, url, xmlString); 
//				//https://api.flickr.com/services/rest/method=flickr.photos.getRecent&api_key=ea248fbeac480b7c14fce5cece516ef0&extras=url_s
//			}
//			catch (Exception ex) {
//				Console.WriteLine("[{0}] Failed to fetch items: {1}", TAG, ex.Message);
//			}

			// Using Android API to make query string
//			try {
//				string url = Android.Net.Uri.Parse(baseUrl).BuildUpon()
//					.AppendQueryParameter("method", methodGetRecent)
//					.AppendQueryParameter("api_key", flickrAPIKey)
//					.AppendQueryParameter(paramExtras, extraSmallUrl)
//					.Build().ToString();
//				string xmlString = await GetUrlAsync(url).ConfigureAwait(false);
//				Console.WriteLine("[{0}] Received xml from Url: {1}\n{2}", TAG, url, xmlString); 
//				//https://api.flickr.com/services/rest/?method=flickr.photos.getRecent&api_key=ea248fbeac480b7c14fce5cece516ef0&extras=url_s
//			}
//			catch (Exception ex) {
//				Console.WriteLine("[{0}] Failed to fetch items: {1}", TAG, ex.Message);
//			}
		}

		public async Task PreloadImages(int pos1, int pos2, List<GalleryItem> items)
		{
			Console.WriteLine("[{0}] Start PreloadImages: {1}", TAG, DateTime.Now.ToLongTimeString());
//			Console.WriteLine("[{0}] PreloadImages Start Load photos: {1}", TAG, DateTime.Now.ToLongTimeString());
			// Preload visible and 10 before and after photos
//			for  (int i = (pos1 - 10 >= 0 ? pos1 - 10 : 0); i < (pos2 + 10 < items.Count ? pos2 + 10 : items.Count); i++) {
//				string path = GetPathFromUrl(items[i].Url);
//				if (!File.Exists(path)) {
//					try {
//						byte[] bitmapBytes = await GetUrlBytesAsync(items[i].Url).ConfigureAwait(false);
//						File.WriteAllBytes(path, bitmapBytes);
//						Console.WriteLine("[{0}] Preload Bitmap created from url: Position: {1}", TAG, i);
//					}
//					catch (Exception ex) {
//						Console.WriteLine("[{0}] Preload Bitmap creation from url failed: {1}, Position: {2}", TAG, ex.Message, i);
//					}
//				}
//			}

			// Preload 10 before displated photos
			for  (int i = (pos1 - 10 >= 0 ? pos1 - 10 : 0); i < pos1; i++) {
				string path = GetPathFromUrl(items[i].Url);
				if (!File.Exists(path)) {
					try {
						byte[] bitmapBytes = await GetUrlBytesAsync(items[i].Url).ConfigureAwait(false);
						File.WriteAllBytes(path, bitmapBytes);
//						Console.WriteLine("[{0}] Preload Bitmap created from url: Position: {1}", TAG, i);
					}
					catch (Exception ex) {
						Console.WriteLine("[{0}] Preload Bitmap creation from url failed: {1}, Position: {2}", TAG, ex.Message, i);
					}
				}
			}
			// Preload 10 past displayed photos
			for  (int i = pos2; i < (pos2 + 10 < items.Count ? pos2 + 10 : items.Count); i++) {
				string path = GetPathFromUrl(items[i].Url);
				if (!File.Exists(path)) {
					try {
						byte[] bitmapBytes = await GetUrlBytesAsync(items[i].Url).ConfigureAwait(false);
						File.WriteAllBytes(path, bitmapBytes);
//						Console.WriteLine("[{0}] Preload Bitmap created from url: Position: {1}", TAG, i);
					}
					catch (Exception ex) {
						Console.WriteLine("[{0}] Preload Bitmap creation from url failed: {1}, Position: {2}", TAG, ex.Message, i);
					}
				}
			}
//			Console.WriteLine("[{0}] PreloadImages End Load photos: {1}", TAG, DateTime.Now.ToLongTimeString());
//			Console.WriteLine("[{0}] PreloadImages Start Delete photos: {1}", TAG, DateTime.Now.ToLongTimeString());
			// Delete out of range photos
			for (int i = 0; i < pos1 -10; i++) {
				string path = GetPathFromUrl(items[i].Url);
				if (File.Exists(path)) {
					File.Delete(path);
//					Console.WriteLine("[{0}] File Deleted: Position: {1}", TAG, i);
				}
			}
			if (pos2 + 10 < items.Count) {
				for (int i = pos2 + 10; i < items.Count; i++) {
					string path = GetPathFromUrl(items[i].Url);
					if (File.Exists(path)) {
						File.Delete(path);
//						Console.WriteLine("[{0}] File Deleted:  Position: {1}", TAG, i);
					}
				}
			}
//			Console.WriteLine("[{0}] PreloadImages End Delete photos: {1}", TAG, DateTime.Now.ToLongTimeString());
			Console.WriteLine("[{0}] End PreloadImages: {1}", TAG, DateTime.Now.ToLongTimeString());
		}

		string GetPathFromUrl(string url)
		{
			string[] split = url.Split(new char[]{'/'});
			string filename = split[split.Length-1];
			string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename + ".bytes");
			return path;
		}

		public void DeleteImageFile(string Url)
		{
			string path = GetPathFromUrl(Url);
			if (File.Exists(path))
				File.Delete(path);
		}
    }
}

