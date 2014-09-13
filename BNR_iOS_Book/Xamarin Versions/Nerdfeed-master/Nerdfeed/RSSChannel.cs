using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using MonoTouch.UIKit;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Nerdfeed
{
	//[Table ("RSSChannels")]
	public class RSSChannel
	{
		//[PrimaryKey, AutoIncrement, MaxLength(8)]
		//public int ID {get; set;}
		public string title {get; set;}
		public string description {get; set;}
		public string link {get; set;}
		public string lastBuildDate {get; set;}
		public string generator {get; set;}
		public string type {get; set;}

		public void parseXML(XDocument doc)
		{
			var xChannel = doc.Descendants("channel");
			this.title = xChannel.ElementAt(0).Element("title").Value;
			this.description = xChannel.ElementAt(0).Element("description").Value;
			this.link = xChannel.ElementAt(0).Element("link").Value;
			this.lastBuildDate = xChannel.ElementAt(0).Element("lastBuildDate").Value;
			this.generator = xChannel.ElementAt(0).Element("generator").Value;
		}

		public void parseJSON(JObject parsedJSONData)
		{
			this.title = (string)parsedJSONData["feed"]["author"]["name"]["label"];
			this.description = (string)parsedJSONData["feed"]["rights"]["label"];
		}

//		public RSSChannel copy()
//		{
//			RSSChannel dupChannel = new RSSChannel();
//			dupChannel.ID = this.ID;
//			dupChannel.title = this.title;
//			dupChannel.description = this.description;
//			dupChannel.link = this.link;
//			dupChannel.lastBuildDate = this.lastBuildDate;
//			dupChannel.generator = this.generator;
//			dupChannel.type = this.type;
//			return dupChannel;
//		}
	}
}

