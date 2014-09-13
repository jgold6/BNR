using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using Xamarin.Geolocation;
using System.Threading.Tasks;
using MonoTouch.MapKit;

namespace Whereami
{
	public class BNRMapPoint : MKAnnotation
	{
		string _title;
		string _subtitle;

		public BNRMapPoint(string title, CLLocationCoordinate2D coord)
		{
			_title = title;
			Coordinate = coord;

			NSDateFormatter dateFormatter = new NSDateFormatter();
			dateFormatter.DateStyle = NSDateFormatterStyle.Medium;
			dateFormatter.TimeStyle = NSDateFormatterStyle.Short;
			_subtitle = "Created: " + dateFormatter.StringFor(NSDate.Now);
		}

		public override string Title {
			get {
				return _title;
			} 
		}

		public override string Subtitle {
			get {
				return _subtitle;
			}
		}

		public override CLLocationCoordinate2D Coordinate { get; set;}

		[Export("initWithCoder:")]
		public BNRMapPoint(NSCoder decoder)
		{
			NSString str = (NSString)decoder.DecodeObject(@"Title");
			if (str != null)
				_title = str.ToString();
			str = (NSString)decoder.DecodeObject(@"Subtitle");
			if (str != null)
				_subtitle = str.ToString();
			Coordinate = new CLLocationCoordinate2D(decoder.DecodeDouble(@"Latitude"), decoder.DecodeDouble(@"Longitude"));
		}

		public override void EncodeTo (NSCoder coder)
		{
			if (this.Title != null)
				coder.Encode(new NSString(this.Title), "Title");
			if (this.Subtitle != null)
				coder.Encode(new NSString(this.Subtitle), "Subtitle");
			coder.Encode(this.Coordinate.Latitude, "Latitude");
			coder.Encode(this.Coordinate.Longitude, "Longitude");
		}
	}
}

