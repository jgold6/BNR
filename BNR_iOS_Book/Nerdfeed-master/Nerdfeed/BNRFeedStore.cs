using System;
using System.Collections.Generic;
using UIKit;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Foundation;
using System.IO;
using SQLite;
using System.Threading.Tasks;
using System.Xml;

namespace Nerdfeed
{
	public static class BNRFeedStore
	{
		public delegate void Block(string error);
		public static List<RSSItem> items = new List<RSSItem>();
		public static RSSChannel channel {get; set;}
		// Top Songs Cache
//		public static DateTime topSongsCacheDate {
//			get {
//				return (DateTime)NSUserDefaults.StandardUserDefaults.ValueForKey(new NSString("topSongsCacheDate"));
//			}
//			set {
//				topSongsCacheDate = value;
//				NSUserDefaults.StandardUserDefaults.SetValueForKey(value, new NSString("topSongsCacheDate"));
//			}
//		}
			
		public static void FetchRSSFeed(Block completionBlock) // UITableViewController tvc)
		{
			channel = new RSSChannel();
			channel.type = "posts";
			items.Clear();

			string dbPath = GetDBPath();
			SQLiteConnection db;
			if (!File.Exists(dbPath)) {
				db = new SQLiteConnection(dbPath);
				db.CreateTable<RSSItem>();
				db.Close();
				db = null;
			}
			db = new SQLiteConnection(dbPath);
			items = db.Query<RSSItem>("SELECT * FROM RSSItems WHERE type='post' ORDER BY ID DESC");
			db.Close();
			db = null;

			FetchRSSAsync(completionBlock);
		}

		static async void FetchRSSAsync(Block completionBlock)
		{
			string url = "http://blog.onobytes.com/feed/"; // count_limit=10&
			string xmlData = null;
			XDocument doc = null;

			using (var wc = new WebClient ()) {

				try {
					xmlData = await wc.DownloadStringTaskAsync (new Uri (url));
				} catch (WebException ex) {
					Console.WriteLine ("Exception: {0}", ex.Message);
					completionBlock (ex.Message);
				}
			}

			try {
				xmlData = XmlConvert.VerifyXmlChars (xmlData);
			} 
			catch (XmlException ex)
			{
				Console.WriteLine("Exception: {0}", ex.Message);
				//completionBlock ("Invalid XML received from RSS feed.");
				List<char> invalidChars = new List<char> () {
					(char)0x00,
					(char)0x01,
					(char)0x02,
					(char)0x03,
					(char)0x04,
					(char)0x05,
					(char)0x06,
					(char)0x07,
					(char)0x08,
					(char)0x0B,
					(char)0x0C,
					(char)0x0E,
					(char)0x0F,
					(char)0x10,
					(char)0x11,
					(char)0x12,
					(char)0x13,
					(char)0x14,
					(char)0x15,
					(char)0x16,
					(char)0x17,
					(char)0x18,
					(char)0x19,
					(char)0x1A,
					(char)0x1B,
					(char)0x1C,
					(char)0x1D,
					(char)0x1E,
					(char)0X1F,
					(char)0x7F,
					(char)0x80,
					(char)0x81,
					(char)0x82,
					(char)0x83,
					(char)0x84,
					(char)0x86,
					(char)0x87,
					(char)0x88,
					(char)0x88,
					(char)0x89,
					(char)0x8A,
					(char)0x8B,
					(char)0x8C,
					(char)0x8D,
					(char)0x8E,
					(char)0x8F,
					(char)0x90,
					(char)0x91,
					(char)0x92,
					(char)0x93,
					(char)0x94,
					(char)0x95,
					(char)0x96,
					(char)0x97,
					(char)0x98,
					(char)0x99,
					(char)0x9A,
					(char)0x9B,
					(char)0x9C,
					(char)0x9D,
					(char)0x9E,
					(char)0x9F
				};

				foreach(char c in invalidChars)
					xmlData = xmlData.Replace (c, ' ');
			}

			doc = XDocument.Parse (xmlData);

			channel.parseXML(doc);

			var allItems = doc.Descendants("item");

			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.BeginTransaction();
			foreach (XElement current in allItems) {
				RSSItem item = new RSSItem();

				item.parseXML(current);
				item.type = "post";

				bool inItems = false;
				foreach(RSSItem i in items) {
					if (i.link == item.link)
						inItems = true;
				}

				int index = 0;
				if (!inItems) {
					items.Insert(index++, item);
					db.Insert(item);
					if (db.Table<RSSItem>().Count() > 100) {
						db.Query<RSSItem>("DELETE FROM RSSItems WHERE rowid IN (SELECT rowid FROM RSSItems ORDER BY rowid ASC LIMIT 1)");
					}
					Console.WriteLine("Items in table: {0} ItemID: {1}", db.Table<RSSItem>().Count(), item.ID);
				}
			}
			db.Commit();
			db.Close();
			db = null;

			completionBlock("success");
		}

		// Get Apple JSON rss feed
		public static async void FetchRSSFeedTopSongs(int count, Block completionBlock) // UITableViewController tvc)
		{
			using (var wc = new WebClient()) {
				string url = String.Format("http://itunes.apple.com/us/rss/topsongs/limit={0}/json", count);
				channel = new RSSChannel();
				channel.type = "songs";
				items.Clear();

				// Top Songs Cache
//				string dbPath = GetDBPath();
//				SQLiteConnection db;
//				if (!File.Exists(dbPath)) {
//					db = new SQLiteConnection(dbPath);
//					db.CreateTable<RSSItem>();
//					db.Close();
//					db = null;
//				}
//				//db = new SQLiteConnection(dbPath);
//				//items = db.Query<RSSItem>("SELECT * FROM RSSItems WHERE type='song'");
//
//				NSDate tscDate = topSongsCacheDate;
//				if (tscDate != null) {
//					NSTimeInterval cacheAge = tscDate.SecondsSinceReferenceDate;
//				}
//
				// End Top Songs Cache

				try {
					string JSONData = await wc.DownloadStringTaskAsync(new Uri(url));
					JObject parsedJSONData = JObject.Parse (JSONData);

					channel.parseJSON(parsedJSONData);

					var entries = parsedJSONData["feed"]["entry"];

					foreach (var entry in entries) {
						RSSItem item = new RSSItem();

						item.parseJSON(entry);
						item.type = "song";

						items.Add(item);
					}

					completionBlock("success");
				}
				catch (WebException ex) {
					completionBlock(ex.Message);
				}
			}
		}

		public static string GetDBPath()
		{
			string[] cachesDirectory = NSSearchPath.GetDirectories(NSSearchPathDirectory.CachesDirectory, NSSearchPathDomain.User, true);

			// Get one and only caches directory from that list
			string directory = cachesDirectory[0];
			return Path.Combine(directory, "itemCache.db");
		}

		public static void updateItem(RSSItem item)
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Update(item);
			db.Close();
			db = null;
		}

		public static void markItemAsFavorite(RSSItem item)
		{
			if (!item.isFavorite)
				item.isFavorite = true;
			else
				item.isFavorite = false;

			updateItem(item);
		}
	}
}

		// Get Apple xml rss feed
//		public static async void FetchRSSFeedTopSongs(int count, Block completionBlock, UITableViewController tvc)
//		{
//			using (var wc = new WebClient()) {
//				webClients.Add(wc);
//				string url = String.Format("http://itunes.apple.com/us/rss/topsongs/limit={0}/xml", count);
//				channel = new RSSChannel();
//				items.Clear();
//				try {
//					string xmlData = await wc.DownloadStringTaskAsync(new Uri(url));
//					//Console.WriteLine(xmlData);
//
//					XDocument doc = XDocument.Parse(xmlData);
//
//					var xFeed = doc.Descendants();
//
//					channel.title = xFeed.ElementAt(0).Element("{http://www.w3.org/2005/Atom}title").Value;
//					channel.description = xFeed.ElementAt(0).Element("{http://www.w3.org/2005/Atom}rights").Value;
//
//					foreach (XElement element in xFeed) {
//						if (element.Name == "{http://www.w3.org/2005/Atom}entry") {
//							RSSItem item = new RSSItem();
//							var titleArtist = element.Element("{http://www.w3.org/2005/Atom}title").Value.Split('-');
//							item.title = titleArtist[0].Trim();
//							item.subForum = titleArtist[1].Trim();
//
//							var links = element.Descendants();
//							foreach (XElement li in links) {
//								if (li.Name == "{http://www.w3.org/2005/Atom}link" && li.FirstAttribute.Value == "Preview") {
//									item.link = li.Attribute("href").Value;
//								}
//							}
//
//							items.Add(item);
//						}
//					}
//
//					completionBlock();
//				}
//				catch (WebException ex) {
//					Console.WriteLine("Exception: {0}", ex.Message);
//					UIAlertView av = new UIAlertView("Error", ex.Message, null, "OK", null);
//					av.WeakDelegate = tvc;
//					av.Show();
//				}
//				webClients.Remove(wc);
//			}
//		}

// Version 1 of parsing XML document - can't seem to get array of nodes
//					XmlReaderSettings set = new XmlReaderSettings();
//					set.ConformanceLevel = ConformanceLevel.Fragment;
//
//					XPathDocument doc = new XPathDocument(XmlReader.Create(new StringReader(xmlData), set));
//					XPathNavigator nav = doc.CreateNavigator();
//
//					channel.title = nav.SelectSingleNode("/rss/channel/title");
//					channel.infoString = nav.SelectSingleNode("/rss/channel/description");

// Alternate method - try/catch does not work
//			string url = "http://forums.bignerdranch.com/smartfeed.php?limit=1_DAY&sort_by=standard&feed_type=RSS2.0&feed_style=COMPACT";
//			try {
//				client = new WebClient();
//				client.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) => {
//					xmlData = e.Result;
//					Console.WriteLine("Downloaded data: {0}", e.Result);
//				};
//				client.DownloadStringAsync(new Uri(url));
//			}
//			catch (WebException ex) {
//				Console.WriteLine("Error: {0}", ex.Message);
//			}
