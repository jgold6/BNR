using System;
using Foundation;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Threading;

namespace RanchForecast
{
    public class ScheduleFetcher
    {
		public List<ScheduledClass> ScheduledClasses {get; private set;}

		public ScheduleFetcher() : base()
		{
        }

		public async Task<List<ScheduledClass>> FetchClassesAsync()
		{
			XmlDocument xmlDoc;
			try {
				ScheduledClasses = new List<ScheduledClass>();
				HttpWebRequest request = WebRequest.Create("http://bookapi.bignerdranch.com/courses.xml") as HttpWebRequest;
				HttpWebResponse response = await request.GetResponseAsync().ConfigureAwait(false) as HttpWebResponse;
				xmlDoc = new XmlDocument();
				xmlDoc.Load(response.GetResponseStream());
				if (xmlDoc == null) {
					throw new Exception("XmlDoc is null");
				}
				Console.WriteLine("Received {0} bytes", xmlDoc.InnerXml);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error getting XML: {0}\n{1}", ex.Message, ex.StackTrace);
				return null;
			}
			//Create namespace manager - MSDN said this needed to be done. Seems to work without it. 
			// Perhaps needed when you don't know what you are getting.
//			XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
//			nsmgr.AddNamespace("rest","http://schemas.microsoft.com/search/local/ws/rest/v1");

			XmlNode regionNode = xmlDoc.SelectSingleNode("/summary/region");
			XmlNodeList classNodes = regionNode.SelectNodes("class"); 

//			Console.WriteLine("Show all formatted class names"); 
			foreach (XmlNode scheduledClass in classNodes)
			{
				
				ScheduledClass sc = new ScheduledClass();
				sc.Name = scheduledClass.SelectSingleNode("offering").InnerText;
				sc.Location = scheduledClass.SelectSingleNode("location").InnerText;
				sc.Href = scheduledClass.SelectSingleNode("offering").Attributes.GetNamedItem("href").Value;
				sc.Begin = scheduledClass.SelectSingleNode("begin").InnerText;
//				sc.Begin = DateTime.Parse(scheduledClass.SelectSingleNode("begin").InnerText).ToUniversalTime();

//				Console.WriteLine(sc);
				ScheduledClasses.Add(sc);
			}
			return ScheduledClasses;
		}
    }
}

