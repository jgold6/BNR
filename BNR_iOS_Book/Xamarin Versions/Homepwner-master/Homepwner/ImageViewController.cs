using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Homepwner
{
	public partial class ImageViewController : UIViewController
	{
		public UIImage Image {get; set;}
		public CGSize PopoverSize {get; set;}

		public ImageViewController() : base("ImageViewController", null)
		{
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
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			CGSize sz = Image.Size;
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone) {
				if (UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.Portrait || UIDevice.CurrentDevice.Orientation == UIDeviceOrientation.PortraitUpsideDown) {
					sz = new CGSize(UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Width * (sz.Height/sz.Width));
				}
				else {
					sz = new CGSize((UIScreen.MainScreen.Bounds.Height-NavigationController.NavigationBar.Bounds.Height)  * (sz.Width/sz.Height), UIScreen.MainScreen.Bounds.Height-NavigationController.NavigationBar.Bounds.Height);
				}
			}
			else {
				if (sz.Width > sz.Height) {
					sz = new CGSize(PopoverSize.Height * (sz.Width/sz.Height), PopoverSize.Height);
				}
				else {
					sz = new CGSize(PopoverSize.Width, PopoverSize.Width * (sz.Height/sz.Width));
				}
			}

			imageView.Frame = new CGRect(0, 0, sz.Width, sz.Height);
			imageView.Image = Image;

			scrollView.ContentSize = sz;
			scrollView.MinimumZoomScale = 0.25f;
			scrollView.MaximumZoomScale = 5f;

			scrollView.ViewForZoomingInScrollView += (UIScrollView sv) => {return imageView;};

			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				scrollView.ScrollRectToVisible(new CGRect(Image.Size.Width/2 - 300, Image.Size.Height/2 - 300, 600,  600), true);
			}

		}
	}
}

