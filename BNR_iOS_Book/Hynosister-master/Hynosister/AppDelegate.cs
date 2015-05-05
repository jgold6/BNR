using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Hynosister
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		HypnosisView view;
		HypnosisViewController viewController;
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
			window.BackgroundColor = UIColor.White;

			// Create and add subviews
			RectangleF screenRect = new RectangleF(window.Bounds.Location.X, window.Bounds.Location.Y,window.Bounds.Size.Width,window.Bounds.Size.Height);
			UIScrollView scrollView = new UIScrollView(screenRect);

			view = new HypnosisView(scrollView.Bounds);
			//view.Frame = new RectangleF(window.Bounds.Location.X, window.Bounds.Location.Y+23,window.Bounds.Size.Width,window.Bounds.Size.Height-23);
			//view.Frame = new RectangleF(window.Bounds.Location, window.Bounds.Size);
			//view.Frame = new RectangleF(window.Frame.Location, window.Frame.Size);
			scrollView.Add(view);

			BNRLogo logoView = new BNRLogo(new RectangleF(0, 0, 100, 100));
			view.Add(logoView);

			SizeF svSize = scrollView.Bounds.Size;
			scrollView.ContentSize = svSize;
			scrollView.MinimumZoomScale = 1;
			scrollView.MaximumZoomScale = 5;
			//scrollView.PagingEnabled = true;

			scrollView.ViewForZoomingInScrollView += (UIScrollView sv) => {return view;};

			bool success = view.BecomeFirstResponder();
			if (success) {
				Console.WriteLine("HypnosisView became the first responder");
			} else {
				Console.WriteLine("HypnosisView could not become the first responder");
			}

			// If you have defined a root view controller, set it here:
			viewController = new HypnosisViewController();
			viewController.View = scrollView;
			window.RootViewController = viewController;

			// make the window visible
			window.MakeKeyAndVisible();

			return true;
		}
	}
}

