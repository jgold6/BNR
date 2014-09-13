using System;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;

namespace Nerdfeed
{
	public class WebViewController : UIViewController, IListViewControllerDelegate, IUISplitViewControllerDelegate
	{
		public UIWebView webView {get {return this.View as UIWebView;}}
		public UIPopoverController popover {get; set;}

		public WebViewController()
		{
		}

		public override void LoadView()
		{
			// Create an instance of UIWebview as large as the screen
			RectangleF screenFrame = UIScreen.MainScreen.ApplicationFrame;
			UIWebView wv = new UIWebView(screenFrame);
			wv.ScalesPageToFit = true;

			this.View = wv;
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.View.BackgroundColor = UIColor.Black;
			if (this.NavigationController != null) {
				this.NavigationController.NavigationBar.TintColor = UIColor.LightGray;
				this.NavigationController.NavigationBar.Translucent = false;
				this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
				UIView statusBarBackground = new UIView(new RectangleF(0, 0, UIScreen.MainScreen.Bounds.Width, 20));
				statusBarBackground.BackgroundColor = UIColor.DarkGray;
				statusBarBackground.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin);
				this.NavigationController.View.Add(statusBarBackground);
			}
		}

		public override bool ShouldAutorotate()
		{
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				return true;
			return InterfaceOrientation == UIInterfaceOrientation.Portrait;
		}

		public void listViewControllerHandleObject(ListViewController lvc, object obj)
		{
			// Cast the passed object to RSSItem
			RSSItem entry = obj as RSSItem;

			// Make sure that we are really getting an RSSItem
			if (entry.GetType() != typeof(RSSItem))
				return;

			// Grab the info from the item and push it into the appropriate views
			this.webView.LoadRequest(new NSUrlRequest(new NSUrl(entry.link)));

			this.NavigationItem.Title = entry.title + " - " + entry.subForum;
		}

		public override void ViewDidDisappear(bool animated)
		{
			base.ViewDidDisappear(animated);
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				this.webView.LoadHtmlString("", null);
//			this.webView.Init();
//			this.webView.ScalesPageToFit = true;
		}

		[Export ("splitViewController:willHideViewController:withBarButtonItem:forPopoverController:")]
		public void willHideViewController(UISplitViewController svc, UIViewController vc, UIBarButtonItem bbi, UIPopoverController poc)
		{
			// If this bar button item doesn't have a title, it won't appear at all.
			bbi.Title = "List";

			// Take this bar button item and put it on the left side of our nav item
			this.NavigationItem.SetLeftBarButtonItem(bbi, true);

			popover = poc;
		}

		[Export ("splitViewController:willShowViewController:invalidatingBarButtonItem:")]
		public void willShowViewController(UISplitViewController svc, UIViewController vc, UIBarButtonItem bbi)
		{
			// Remove the bar button item from our navigation item
			// We'll double check that its the corect button, even though we know it is
			if (bbi == this.NavigationItem.LeftBarButtonItem) {
				this.NavigationItem.SetLeftBarButtonItem(null, true);
			}

			popover = null;
		}
	}
}

