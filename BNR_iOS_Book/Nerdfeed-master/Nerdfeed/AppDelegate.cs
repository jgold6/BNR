using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Xml;
using System.Net;
using System.Drawing;

namespace Nerdfeed
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
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

			ListViewController lvc = new ListViewController(UITableViewStyle.Plain);

			UINavigationController masterNav = new UINavigationController(lvc);

			WebViewController wvc = new WebViewController();
			lvc.webViewController = wvc;

			// Check to make sure we're on an iPad
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				// WebViewController must be in navigaiton controller, you'll see why later
				UINavigationController detailNav = new UINavigationController(wvc);

				UIViewController[] vcs = new UIViewController[]{masterNav, detailNav};

				UISplitViewController svc = new MySplitViewController();

				// Set the delegate of the split view controller to the detail VC
				// We'll need this later - ignore warning for now
				svc.WeakDelegate = wvc;
				svc.ViewControllers = vcs;

				// Set the root view controller of the window to the split view controller
				window.RootViewController = svc;
			}
			else {
				// On noniPad devidces, go with the old version and just add the
				// single nav view controller
				window.RootViewController = masterNav;
			}

			// make the window visible
			window.MakeKeyAndVisible();
			
			return true;
		}
	}

	public class MySplitViewController : UISplitViewController
	{
		public override UIStatusBarStyle PreferredStatusBarStyle()
		{
			return UIStatusBarStyle.LightContent;
		}

	}
}

