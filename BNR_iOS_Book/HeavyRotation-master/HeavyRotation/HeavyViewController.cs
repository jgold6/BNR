using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HeavyRotation
{
	public partial class HeavyViewController : UIViewController
	{
		RectangleF imageSize;
		UIDevice device;
		int b1count;
		int b2count;
		int b3count;


		public HeavyViewController() : base("HeavyViewController", null)
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

			device = UIDevice.CurrentDevice;

			b1count = 0;
			b2count = 0;
			b3count = 0;


			// Perform any additional setup after loading the view, typically from a nib.
			slider.AutoresizingMask = (UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleWidth);
			image.AutoresizingMask = (UIViewAutoresizing.FlexibleDimensions | UIViewAutoresizing.FlexibleMargins);
			btn1.AutoresizingMask = (UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleTopMargin);
			btn2.AutoresizingMask = (UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleTopMargin);
			btn3.AutoresizingMask = (UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleBottomMargin | UIViewAutoresizing.FlexibleRightMargin);

			btn1.TouchUpInside += (sender, e) => {
				Console.WriteLine("Button btn1 clicked");
				btn1.SetTitle("btn " + ++b1count + " clicks", UIControlState.Normal);
			};

			btn2.TouchUpInside += (sender, e) => {
				Console.WriteLine("Button btn2 clicked");
				btn2.SetTitle("btn " + ++b2count + " clicks", UIControlState.Normal);
			};

			btn3.TouchUpInside += (sender, e) => {
				Console.WriteLine("Button btn3 clicked");
				btn3.SetTitle("btn " + ++b3count + " clicks", UIControlState.Normal);
			};


			imageSize = image.Bounds;
			slider.Value = 1;	
			slider.ValueChanged += (sender, e) => {
				Console.WriteLine("slider value: {0}", slider.Value);
				if (device.Orientation == UIDeviceOrientation.LandscapeLeft || device.Orientation == UIDeviceOrientation.LandscapeRight)
					image.Bounds = new RectangleF(imageSize.X, imageSize.Y, imageSize.Width * 0.66f * slider.Value, imageSize.Height * 0.66f * slider.Value);
				else
					image.Bounds = new RectangleF(imageSize.X, imageSize.Y, imageSize.Width * slider.Value, imageSize.Height * slider.Value);
			};
		}

		public override void WillRotate(UIInterfaceOrientation orientation, double duration)
		{
			base.WillRotate(orientation, duration);
			if (orientation == UIInterfaceOrientation.LandscapeLeft || orientation == UIInterfaceOrientation.LandscapeRight) {
				image.Bounds = new RectangleF(imageSize.X, imageSize.Y, imageSize.Width * 0.66f * slider.Value, imageSize.Height * 0.66f * slider.Value);
			}
			else {
				image.Bounds = new RectangleF(imageSize.X, imageSize.Y, imageSize.Width * slider.Value, imageSize.Height * slider.Value);
			}
		}

		public override void DidRotate(UIInterfaceOrientation orientation)
		{
			base.DidRotate(orientation);
			if (orientation == UIInterfaceOrientation.LandscapeLeft || orientation == UIInterfaceOrientation.LandscapeRight) {
				image.Bounds = new RectangleF(imageSize.X, imageSize.Y, imageSize.Width * slider.Value, imageSize.Height * slider.Value);
				btn3.Center = new PointF(70, 66);
			}
			else {
				image.Bounds = new RectangleF(imageSize.X, imageSize.Y, imageSize.Width * 0.66f * slider.Value, imageSize.Height * 0.66f * slider.Value);
				btn3.Center = new PointF(View.Bounds.Size.Width-70, 66);
			}

		}

		public override bool ShouldAutorotate()
		{
			return true;
		}

		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
		{
			return UIInterfaceOrientationMask.All;
		}

	}
}

