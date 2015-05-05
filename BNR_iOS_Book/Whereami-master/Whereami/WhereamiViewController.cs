using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using Xamarin.Geolocation;
using System.Threading.Tasks;
using MonoTouch.MapKit;
using System.IO;

namespace Whereami
{
	public partial class WhereamiViewController : UIViewController, IMKMapViewDelegate
	{
		CLLocationCoordinate2D currLocation {get; set;} 
		bool firstLaunch {get; set;}
//		WhereAmIMapDelegate mapDelegate;
		string WhereamiMapTypePrefKey = "WhereamiMapTypePrefKey";
		string WhereamiLastLocLatPrefKey = "WhereamiLastLocLatPrefKey";
		string WhereamiLastLocLongPrefKey = "WhereamiLastLocLongPrefKey";

		public WhereamiViewController() : base("WhereamiViewController", null)
		{
			firstLaunch = true;

			NSMutableDictionary defaults = NSMutableDictionary.FromObjectAndKey(new NSNumber(2), new NSString(WhereamiMapTypePrefKey));
			//defaults.Add(new NSNumber(2), new NSString(WhereamiMapTypePrefKey));
			defaults.Add(new NSString(WhereamiLastLocLatPrefKey), new NSNumber(21.3000d));
			defaults.Add(new NSString(WhereamiLastLocLongPrefKey), new NSNumber(-157.8167d));

			Console.WriteLine(defaults.ToString());

			NSUserDefaults.StandardUserDefaults.RegisterDefaults(defaults);
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);
			string documentDirectory = documentDirectories[0];
			string path = Path.Combine(documentDirectory, "annotations.archive");
			Console.WriteLine("Path: {0}", path);

			var annotations = (NSMutableArray)NSKeyedUnarchiver.UnarchiveFile(path);
			if (annotations != null) {
				for (int i = 0; i < annotations.Count; i++) {
					mapView.AddAnnotation(annotations.GetItem<BNRMapPoint>(i));
				}
			}
			
			// Perform any additional setup after loading the view, typically from a nib.
//			locator = new Geolocator{ DesiredAccuracy = 50 };
//
//			locator.StartListening(5000, 1, false);
//			locator.PositionChanged += (object sender, PositionEventArgs e) => {
//				Console.WriteLine ("Position Status: {0}", e.Position.Accuracy);
//				Console.WriteLine ("Position Latitude: {0}", e.Position.Latitude);
//				Console.WriteLine ("Position Longitude: {0}", e.Position.Longitude);
//			};
//			locator.PositionError += (object sender, PositionErrorEventArgs e) => {
//				Console.WriteLine("Could not find position: {0}, {1}", e.Error, e.ToString() );
//			};

			var clm = new CLLocationManager();
			clm.RequestAlwaysAuthorization();

			actIndicator.StartAnimating();
			gettingLocLabel.Hidden = false;
			textField.Enabled = false;

			int mapTypeValue = NSUserDefaults.StandardUserDefaults.IntForKey(WhereamiMapTypePrefKey);

			segControl.SelectedSegment = mapTypeValue;


			mapView.MapType = (MKMapType)mapTypeValue;
			mapView.ShowsUserLocation = true;
			mapView.ZoomEnabled = true;

			CLLocationCoordinate2D  lastLoc = new CLLocationCoordinate2D(NSUserDefaults.StandardUserDefaults.DoubleForKey(WhereamiLastLocLatPrefKey),NSUserDefaults.StandardUserDefaults.DoubleForKey(WhereamiLastLocLongPrefKey));
			MKCoordinateRegion lastRegion = new MKCoordinateRegion(lastLoc, new MKCoordinateSpan(0.0025, 0.0025));
			mapView.SetRegion(lastRegion, true);

			//currLocation = new CLLocationCoordinate2D(20.7592, -156.4572);

			// C# style event handler - can access class instance variables
			mapView.DidUpdateUserLocation += (object sender, MKUserLocationEventArgs e) => 
			{
				actIndicator.StopAnimating();
				gettingLocLabel.Hidden = true;
				textField.Enabled = true;
				Console.WriteLine(".NET Lat: {0}, Long: {1}, Alt: {2}", e.UserLocation.Coordinate.Latitude, e.UserLocation.Coordinate.Longitude, e.UserLocation.Location.Altitude);
				currLocation = e.UserLocation.Coordinate;
				if (firstLaunch) {
					mapView.SetRegion(MKCoordinateRegion.FromDistance(currLocation, 250, 250), true);
					firstLaunch = false;
				}
				else
					mapView.SetCenterCoordinate(currLocation, true);
			};

			mapView.DidFailToLocateUser += (object sender, NSErrorEventArgs e) => {
				Console.WriteLine("Could not find location: {0}", e.ToString());
				actIndicator.StartAnimating();
				gettingLocLabel.Hidden = false;
				textField.Enabled = false;
			};

			mapView.DidSelectAnnotationView += (object sender, MKAnnotationViewEventArgs e) => 
			{
				var annotation = e.View.Annotation as BNRMapPoint;

				if (annotation != null) {
					Console.WriteLine(".NET DidSelectAnnotationView: {0}", annotation.Title);
				}

			};

			// Strong Delegate method. Create delegate class as nested class of ViewCOntroller
			// Override need methods in that nested delegate class
//			mapDelegate = new WhereAmIMapDelegate();
//			mapView.Delegate = mapDelegate;

			// Weak delegate method. use Export attribute with selector to override then implement method.
			// Whichever is assigned last wins and kills the other. 
//			mapView.WeakDelegate =  this;

//			textField.Delegate = new TextFieldDelegate();

			textField.EditingDidEndOnExit += (object sender, EventArgs e) => 
			{
				actIndicator.Hidden = false;
				if (!firstLaunch) {
					BNRMapPoint mp = new BNRMapPoint(textField.Text, currLocation);

					NSUserDefaults.StandardUserDefaults.SetDouble(currLocation.Latitude, WhereamiLastLocLatPrefKey);
					NSUserDefaults.StandardUserDefaults.SetDouble(currLocation.Longitude, WhereamiLastLocLongPrefKey);

					mapView.AddAnnotation(mp);
					textField.ResignFirstResponder();
					textField.Text = "";
					actIndicator.Hidden = true;
				}
				else {
					var locator = new Geolocator{ DesiredAccuracy = 50 };
					locator.GetPositionAsync (timeout: 10000).ContinueWith (t => {
						CLLocationCoordinate2D coord = new CLLocationCoordinate2D(t.Result.Latitude, t.Result.Longitude);
						currLocation = coord;
						MKCoordinateRegion region = MKCoordinateRegion.FromDistance(currLocation, 250, 250);
						mapView.SetRegion(region, true);
						BNRMapPoint mp = new BNRMapPoint(textField.Text, currLocation);

						NSUserDefaults.StandardUserDefaults.SetDouble(currLocation.Latitude, WhereamiLastLocLatPrefKey);
						NSUserDefaults.StandardUserDefaults.SetDouble(currLocation.Longitude, WhereamiLastLocLongPrefKey);

						mapView.AddAnnotation(mp);
						textField.ResignFirstResponder();
						textField.Text = "";
						actIndicator.Hidden = true;
					}, TaskScheduler.FromCurrentSynchronizationContext());
				}

			};

			segControl.BackgroundColor = UIColor.White;
			segControl.ValueChanged += (object sender, EventArgs e) => 
			{
				NSUserDefaults.StandardUserDefaults.SetInt(segControl.SelectedSegment, WhereamiMapTypePrefKey);

				switch (segControl.SelectedSegment)
				{
					case 0:
						mapView.MapType = MKMapType.Standard;
						break;
					case 1:
						mapView.MapType = MKMapType.Satellite;
						break;
					case 2:
						mapView.MapType = MKMapType.Hybrid;
						break;
					default:
						break;

				}
			};
		}

		// Weak delegates - can access class instance variables
		[Export("mapView:didSelectAnnotationView:")]
		public void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView annotationView)
		{
				var annotation = annotationView.Annotation as BNRMapPoint;
				
				if (annotation != null) {
					Console.WriteLine("Weak DidSelectAnnotationView: {0}", annotation.Title);
				}
		}

		[Export("mapView:didUpdateUserLocation:")]
		public void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
		{
			Console.WriteLine("Weak Lat: {0}, Long: {1}, Alt: {2}", userLocation.Coordinate.Latitude, userLocation.Coordinate.Longitude, userLocation.Location.Altitude);
			currLocation = userLocation.Coordinate;
			if (firstLaunch) {
				mapView.SetRegion(MKCoordinateRegion.FromDistance(currLocation, 250, 250), true);
				firstLaunch = false;
			}
			else
				mapView.SetCenterCoordinate(currLocation, true);
		}

		// Strong Delegate - Requires public static class variables for currLocation and firstLaunch
//		class WhereAmIMapDelegate : MKMapViewDelegate
//		{
//			public override void DidSelectAnnotationView(MKMapView mapView, MKAnnotationView annotationView)
//			{
//				var annotation = annotationView.Annotation as BNRMapPoint;
//
//				if (annotation != null) {
//					Console.WriteLine("Strong DidSelectAnnotationView: {0}", annotation.Title);
//				}
//			}
//
//			public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
//			{
//				Console.WriteLine("Strong Lat: {0}, Long: {1}, Alt: {2}", userLocation.Coordinate.Latitude, userLocation.Coordinate.Longitude, userLocation.Location.Altitude);
//				currLocation = userLocation.Coordinate;
//				if (firstLaunch) {
//					mapView.SetRegion(MKCoordinateRegion.FromDistance(currLocation, 250, 250), true);
//					firstLaunch = false;
//				}
//				else
//					mapView.SetCenterCoordinate(currLocation, true);
//			}
//		}
	}
}



























