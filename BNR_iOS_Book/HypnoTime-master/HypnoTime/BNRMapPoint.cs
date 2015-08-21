using System;
using CoreGraphics;
using Foundation;
using UIKit;
using CoreLocation;
using System.Threading.Tasks;
using MapKit;

namespace HypnoTime
{
	public class BNRMapPoint : MKAnnotation
	{
		string _title;
		string _subtitle;
		CLLocationCoordinate2D coord;

		#region implemented abstract members of MKAnnotation

		public override CLLocationCoordinate2D Coordinate {
			get {
				return coord;
			}
		}

		#endregion

		public BNRMapPoint(string title, CLLocationCoordinate2D coord)
		{
			_title = title;
			this.coord = coord;
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



	}
}

