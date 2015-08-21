using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace HypnoTime
{
	public partial class TabBarController : UITabBarController
	{
		public TabBarController() : base("TabBarController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Console.WriteLine("TabBar View Loaded - frame" + View.Frame.ToString());
			Console.WriteLine("TabBar View Loaded - bounds" + View.Bounds.ToString());

		}

		public override void DidRotate(UIInterfaceOrientation orientation)
		{
			base.DidRotate(orientation);
			Console.WriteLine("TabBar did rotate - frame" + View.Frame.ToString());
			Console.WriteLine("TabBar did rotate - bounds" + View.Bounds.ToString());

		}

		// No longer needed?
//		public override void ViewDidLayoutSubviews()
//		{
//			base.ViewDidLayoutSubviews();
//			// fix for iOS7 bug in UITabBarController
//			this.SelectedViewController.View.Superview.Frame = this.View.Bounds;
//		}
	}
}

