using System;
using Foundation;

namespace RanchForecast
{
    public class ScheduledClass : NSObject
    {
		[Export("Name")]
		public string Name {get; set;}
		[Export("Location")]
		public string Location {get; set;}
		[Export("Href")]
		public string Href {get; set;}
		[Export("Begin")]
		public string Begin {get; set;} 

        public ScheduledClass()
        {
        }

		public override string ToString()
		{
			return string.Format("[ScheduledClass: Name={0}, Location={1}, Href={2}, Begin={3}]", Name, Location, Href, Begin);
		}
    }
}

