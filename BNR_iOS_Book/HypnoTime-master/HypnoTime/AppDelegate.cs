using System;
using CoreGraphics;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace HypnoTime
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
			#if DEBUG
			Xamarin.Calabash.Start();
			#endif

			// create a new window instance based on the screen size
			window = new UIWindow(UIScreen.MainScreen.Bounds);

			HypnosisViewController hvc = new HypnosisViewController();
			TimeViewController tvc = new TimeViewController();
			MapViewController mvc = new MapViewController();

			UITabBarController tabBarController = new TabBarController();

			UIViewController[] tbvcs;
			tbvcs = new UIViewController[3]{hvc, tvc, mvc};
			tabBarController.SetViewControllers(tbvcs, true);
			tabBarController.SelectedViewController = tvc;
			tabBarController.TabBar.ShadowImage = new UIImage();
			tabBarController.TabBar.BackgroundImage = new UIImage();
//			tabBarController.TabBar.BarTintColor = UIColor.Black;
			tabBarController.TabBar.TintColor = UIColor.Green;
//			tabBarController.TabBar.BackgroundColor = UIColor.White;


			// If you have defined a root view controller, set it here:
			window.RootViewController = tabBarController;

			// make the window visible
			window.BackgroundColor = UIColor.White;
			window.MakeKeyAndVisible();

			return true;
		}
	}
}

