using System;
using CoreGraphics;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Hynosister
{
	public class BNRLogo : UIView
	{
		UIColor circleColor;

		public UIColor CircleColor
		{
			get {return circleColor;}
			set {circleColor = value; SetNeedsDisplay();}
		} 

		public BNRLogo() : this(new CGRect(UIScreen.MainScreen.Bounds.Location.X,UIScreen.MainScreen.Bounds.Location.Y, UIScreen.MainScreen.Bounds.Size.Width, UIScreen.MainScreen.Bounds.Height))
		{

		}

		public BNRLogo(CGRect frame)
		{
			Frame = frame;
			BackgroundColor = UIColor.Clear;
		}

		public override void Draw(CGRect rect)
		{
			// Load image
			UIImage image = new UIImage("logo.png");
			// Get drawing context
			CGContext ctx = UIGraphics.GetCurrentContext();
			// get view bounds
			CGRect bounds = this.Bounds;
			// Find the center of view
			CGPoint center = new CGPoint();
			center.X = bounds.X + bounds.Width / 2;
			center.Y = bounds.Y + bounds.Height / 2;
			// Compute the max radius of the circle
			float maxRadius = (float)Math.Sqrt(Math.Pow(bounds.Size.Width,2) + Math.Pow(bounds.Size.Height,2)) / 3.0f; 

			ctx.SaveState();
			// draw outline circle with 1 pt black shadow
			ctx.AddArc(center.X, center.Y, maxRadius, 0, (float)(Math.PI * 2), true);
			CGSize offset = new CGSize(0, 1);
			CGColor shadowColor = UIColor.Black.CGColor;
			ctx.SetShadow(offset, 2, shadowColor);
			ctx.DrawPath(CGPathDrawingMode.Stroke);
			// clear shadow
			ctx.RestoreState();
			// set clipping circle
			ctx.AddArc(center.X, center.Y, maxRadius, 0, (float)(Math.PI * 2), true);
			ctx.Clip();
			// Draw the image in the circle
			image.Draw(bounds);

			CGColorSpace colorSpace = CGColorSpace.CreateDeviceRGB();
			nfloat[] components = new nfloat[8]{0.8f, 0.8f, 1, 1, 0.8f, 0.8f, 1, 0};
			nfloat[] locations = new nfloat[2]{0.0f, 1};

			CGGradient gradient = new CGGradient(colorSpace, components, locations);
			ctx.DrawLinearGradient(gradient, new CGPoint(bounds.Width / 2, 0), new CGPoint(bounds.Width / 2, bounds.Height / 2), 0); 


		}
	}
}

