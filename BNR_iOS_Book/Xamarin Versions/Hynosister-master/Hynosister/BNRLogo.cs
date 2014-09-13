using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;

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

		public BNRLogo() : this(new RectangleF(UIScreen.MainScreen.Bounds.Location.X,UIScreen.MainScreen.Bounds.Location.Y, UIScreen.MainScreen.Bounds.Size.Width, UIScreen.MainScreen.Bounds.Height))
		{

		}

		public BNRLogo(RectangleF frame)
		{
			Frame = frame;
			BackgroundColor = UIColor.Clear;
		}

		public override void Draw(RectangleF rect)
		{
			// Load image
			UIImage image = new UIImage("logo.png");
			// Get drawing context
			CGContext ctx = UIGraphics.GetCurrentContext();
			// get view bounds
			RectangleF bounds = this.Bounds;
			// Find the center of view
			PointF center = new PointF();
			center.X = bounds.X + bounds.Width / 2;
			center.Y = bounds.Y + bounds.Height / 2;
			// Compute the max radius of the circle
			float maxRadius = (float)Math.Sqrt(Math.Pow(bounds.Size.Width,2) + Math.Pow(bounds.Size.Height,2)) / 3.0f; 

			ctx.SaveState();
			// draw outline circle with 1 pt black shadow
			ctx.AddArc(center.X, center.Y, maxRadius, 0, (float)(Math.PI * 2), true);
			SizeF offset = new SizeF(0, 1);
			CGColor shadowColor = UIColor.Black.CGColor;
			ctx.SetShadowWithColor(offset, 2, shadowColor);
			ctx.DrawPath(CGPathDrawingMode.Stroke);
			// clear shadow
			ctx.RestoreState();
			// set clipping circle
			ctx.AddArc(center.X, center.Y, maxRadius, 0, (float)(Math.PI * 2), true);
			ctx.Clip();
			// Draw the image in the circle
			image.Draw(bounds);

			CGColorSpace colorSpace = CGColorSpace.CreateDeviceRGB();
			float[] components = new float[8]{0.8f, 0.8f, 1, 1, 0.8f, 0.8f, 1, 0};
			float[] locations = new float[2]{0.0f, 1};

			CGGradient gradient = new CGGradient(colorSpace, components, locations);
			ctx.DrawLinearGradient(gradient, new PointF(bounds.Width / 2, 0), new PointF(bounds.Width / 2, bounds.Height / 2), 0); 


		}
	}
}

