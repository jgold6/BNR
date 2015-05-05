using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace HeavyRotation
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		HeavyViewController hvc;
		UIDevice device;
		//
		// This method is invoked when the application has loaded and is ready to run. In this
		// method you should instantiate the window, load the UI into it and then make the window
		// visible.
		//
		// You have 17 seconds to return from this method, or iOS will terminate your application.
		//
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			// create a new window instance based on the screen size
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			// Get the device object
			device = UIDevice.CurrentDevice;

			// Tell it to start monitoring the accelerometer for orientation
			device.BeginGeneratingDeviceOrientationNotifications();
			device.ProximityMonitoringEnabled = true;

			// Get the notification center for the app
			NSNotificationCenter nc = NSNotificationCenter.DefaultCenter;

			// Add this as an observer
			nc.AddObserver(this, new Selector("orientationChanged:"), null, device);
			nc.AddObserver(this, new Selector("proximity:"), null, device);

			// If you have defined a root view controller, set it here:
			hvc = new HeavyViewController();
			hvc.View.BackgroundColor = UIColor.White;
			window.RootViewController = hvc;
			
			// make the window visible
			window.MakeKeyAndVisible();
			
			return true;
		}

		[Export ("orientationChanged:")]
		public void orientationChanged(NSNotification note)
		{
			// Log the constant that represents the current orientation
			Console.WriteLine("Orientation: " + device.Orientation.ToString());
		}

		[Export ("proximity:")]
		public void proximity(NSNotification note)
		{
			if (device.ProximityState)
			{
				if (hvc.View.BackgroundColor != UIColor.Purple)
					hvc.View.BackgroundColor = UIColor.Purple;
				else
					hvc.View.BackgroundColor = UIColor.White;
			}

		}
	}
}







































