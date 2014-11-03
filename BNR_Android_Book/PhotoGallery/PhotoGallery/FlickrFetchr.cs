using System;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using Android.Graphics;

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
		private static readonly string paramExtras = "extras";
		private static readonly string extraSmallUrl = "url_s";
		private static readonly string page = "page";

		#endregion

		async Task<byte[]> GetUrlBytesAsync(string url) {
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
			return result;
		}

		public async Task<string> GetUrlAsync(string url)
		{
			string result = "";
			byte[] bytes = await GetUrlBytesAsync(url).ConfigureAwait(false);
			foreach (byte bit in bytes) {
				result += Convert.ToChar(bit);
			}
			return result;
		}

		// TODO: Limit caching to 50 images.
		// TODO: Preload 50 images.

		public async Task<Bitmap> GetImageBitmapAsync(string url)
		{
			Bitmap bitmap = null;
			string[] split = url.Split(new char[]{'/'});
			string filename = split[split.Length-1];
			string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), filename + ".bytes");
			// Check for cached images on filesystem. Filename will be the last part of the url+.bytes.
			if (File.Exists(path)) {
				try {
					byte[] bitmapBytes = File.ReadAllBytes(path);
					bitmap = await BitmapFactory.DecodeByteArrayAsync(bitmapBytes, 0, bitmapBytes.Length);
					Console.WriteLine("[{0}] Bitmap created from cache", TAG);
				}
				catch (Exception ex) {
					Console.WriteLine("[{0}] Bitmap creation from cache failed: {1}", TAG, ex.Message);
				}
			}
			// If not, download and cache it.
			else {
				try {
					byte[] bitmapBytes = await GetUrlBytesAsync(url);
					bitmap = await BitmapFactory.DecodeByteArrayAsync(bitmapBytes, 0, bitmapBytes.Length);
					File.WriteAllBytes(path, bitmapBytes);
					Console.WriteLine("[{0}] Bitmap created from url", TAG);
				}
				catch (Exception ex) {
					Console.WriteLine("[{0}] Bitmap creation from url failed: {1}", TAG, ex.Message);
				}
			}
			return bitmap;
		}

		public async Task<List<GalleryItem>> Fetchitems(string pageNum = "1")
		{
			List<GalleryItem> items = new List<GalleryItem>();

			try {
				var builder = new UriBuilder(baseUrl);

				var query = HttpUtility.ParseQueryString(builder.Query);
				query[method] = methodGetRecent;
				query[apiKey] = flickrAPIKey;
				query[paramExtras] = extraSmallUrl;
				query[page] = pageNum;
				builder.Query = query.ToString();

				string url = builder.ToString();
				string xmlString = await GetUrlAsync(url).ConfigureAwait(false);

				//Console.WriteLine("[{0}] Received xml from Url: {1}\n{2}", TAG, url, xmlString);
				//https://api.flickr.com:443/services/rest/?method=flickr.photos.getRecent&api_key=ea248fbeac480b7c14fce5cece516ef0&extras=url_s

				XmlSerializer serializer = new XmlSerializer(typeof(rsp));

				using (var reader = new StringReader(xmlString)) {
					var rsp = (rsp)serializer.Deserialize(reader);
					var photos = rsp.photos.photo;
					foreach (rspPhotosPhoto photo in photos) {
						//Console.WriteLine("[{0}]\nPhoto Id: {1}\nCaption: {2}\nUrl: {3}", TAG, photo.id, photo.title, photo.url_s);
						GalleryItem item = new GalleryItem(){
							Caption = photo.title,
							Id = photo.id.ToString(),
							Url = photo.url_s
						};
						items.Add(item);
					}
				}
			}
			catch (IOException ioex) {
				Console.WriteLine("[{0}] Failed to fetch items: {1}", TAG, ioex.Message);
			}
			catch (Exception ex){
				Console.WriteLine("[{0}] Failed to parse items: {1}", TAG, ex.Message);
			}

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

			return items;
		}
    }
}

