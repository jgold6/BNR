using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreLocation;
using System.IO;
using MonoTouch.MapKit;

namespace Whereami
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		WhereamiViewController mapViewController;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			window.BackgroundColor = UIColor.White;
			mapViewController = new WhereamiViewController();
			window.RootViewController = mapViewController;
			window.MakeKeyAndVisible();
			
			return true;
		}

		public override void DidEnterBackground(UIApplication application)
		{
			var subViews = mapViewController.View.Subviews;
			MKMapView mapView = subViews[0] as MKMapView;
			Console.WriteLine("mapView: {0}", mapView);
			var tempArray = mapView.Annotations;
			NSMutableArray annotations = new NSMutableArray();
			Console.WriteLine("tempArray: {0}", tempArray.ToString());
			for (int i = 0; i < tempArray.Length; i++) {
				if (tempArray[i].GetType() == typeof(MKUserLocation)) {
					Console.WriteLine("MKUserLocation: {0}", tempArray[i]);
				}
				else {
					Console.WriteLine("MKMapPoint added: {0}", tempArray[i]);
					annotations.Add(tempArray[i]);
				}
			}
			var documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);
			string documentDirectory = documentDirectories[0];
			string path = Path.Combine(documentDirectory, "annotations.archive");
			Console.WriteLine("Path: {0}", path);
			bool success = NSKeyedArchiver.ArchiveRootObjectToFile(annotations, path);
			if (success) {
				Console.WriteLine("Saved Annotations {0}", annotations.ToString());
			}

		}
	}
}

