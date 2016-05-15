using System;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using SQLite;

namespace Nerdfeed
{
	[Table("RSSItems")]
	public class RSSItem
	{
		[PrimaryKey, AutoIncrement, MaxLength(8)]
		public int ID {get; set;}
		public string title {get; set;}
		public string link {get; set;}
		public string description {get; set;}
		public string author {get; set;}
		public string category {get; set;}
		public string comments {get; set;}
		public string pubDate {get; set;}
		public string subForum {get; set;}
		public bool isFavorite {get; set;}
		public bool isRead {get; set;}
		public string type {get; set;}

		public void parseXML(XElement current)
		{
			this.title = current.Element ("title").Value;
			this.link = current.Element("link").Value;
			this.description = current.Element("description").Value;
			//this.author = current.Element("author").Value;
			//this.category = current.Element("category").Value;
			this.comments = current.Element("comments").Value;
			this.pubDate = current.Element("pubDate").Value;
		}

		public void parseJSON(JToken entry)
		{
			this.title = (string)entry["im:name"]["label"];
			this.subForum = (string)entry["im:artist"]["label"];
			this.link = (string)entry["link"][1]["attributes"]["href"];
			this.pubDate = (string)entry["im:releaseDate"]["attributes"]["label"];
		}

		public RSSItem copy()
		{
			RSSItem dupItem = new RSSItem();
			dupItem.ID = this.ID;
			dupItem.title = this.title;
			dupItem.link = this.link;
			dupItem.description = this.description;
			dupItem.author = this.author;
			dupItem.category = this.category;
			dupItem.comments = this.comments;
			dupItem.pubDate = this.pubDate;
			dupItem.subForum = this.subForum;
			dupItem.isFavorite = this.isFavorite;
			dupItem.isRead = this.isRead;
			dupItem.type = this.type;
			return dupItem;
		}
	}
}

