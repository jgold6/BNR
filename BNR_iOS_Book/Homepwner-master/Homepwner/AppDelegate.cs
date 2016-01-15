using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using System.IO;
using System.Threading;

namespace Homepwner
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

			// Create ItemsViewController
			ItemsViewController itemsViewController = new ItemsViewController();

			// Create an instance UINavigationController
			// its stack contains only itemsViewController
			UINavigationController navController = new UINavigationController(itemsViewController);

			// If you have defined a root view controller, set it here:
			window.RootViewController = navController;

//			System.Globalization.CultureInfo newLang = new System.Globalization.CultureInfo ("ru-RU");
//			Thread.CurrentThread.CurrentCulture = newLang;
//			Thread.CurrentThread.CurrentUICulture = newLang;

//			NSUserDefaults.StandardUserDefaults.SetValueForKey(NSArray.FromNSObjects(new NSObject[]{new NSString("es")}), new NSString("AppleLanguages"));

			// make the window visible
			window.MakeKeyAndVisible();
			
			return true;
		}

		public override void DidEnterBackground(UIApplication application)
		{
//			bool success = BNRItemStore.saveChanges(); // Archive method of saving
//			if (success) { // Archive method of saving
//				Console.WriteLine("Saved all of the BNRItems"); // Archive method of saving
//			} else { // Archive method of saving
//				Console.WriteLine("Could not save any of the BNRItems"); // Archive method of saving
//			}
		}
	}
}






















