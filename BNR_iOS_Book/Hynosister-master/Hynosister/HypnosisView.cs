using System;
using CoreGraphics;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Hynosister
{
	public class HypnosisView : UIView
	{
		UIColor circleColor;
		UIColor crossHairColor;

		public UIColor CircleColor
		{
			get {return circleColor;}
			set {circleColor = value; SetNeedsDisplay();}
		}

		public HypnosisView() : this(new CGRect(UIScreen.MainScreen.Bounds.Location.X,UIScreen.MainScreen.Bounds.Location.Y, UIScreen.MainScreen.Bounds.Size.Width, UIScreen.MainScreen.Bounds.Height))
		{

		}

		public HypnosisView(CGRect frame)
		{
			Frame = frame;
			BackgroundColor = UIColor.Clear;
			circleColor = UIColor.LightGray;
		}

		public override void Draw(CGRect rect)
		{
			base.Draw(rect);
	
			// Get current drawing context
			CGContext ctx = UIGraphics.GetCurrentContext(); 
			// Get bounds of view
			CGRect bounds = this.Bounds;

			// Figure out the center of the bounds rectangle
			CGPoint center = new CGPoint();
			center.X = (float)(bounds.Location.X + bounds.Size.Width / 2.0);
			center.Y = (float)(bounds.Location.Y + bounds.Size.Height / 2.0);

			// The radius of the circle shiuld be nearly as big as the View.
			float maxRadius = (float)Math.Sqrt(Math.Pow(bounds.Size.Width,2) + Math.Pow(bounds.Size.Height,2)) / 2.0f;

			// The thickness of the line should be 10 points wide
			ctx.SetLineWidth(10);

			// The color of the line should be grey
			//ctx.SetRGBStrokeColor(0.6f, 0.6f, 0.6f, 1.0f);
			//UIColor.FromRGB(0.6f, 0.6f, 0.6f).SetStroke();
			//UIColor.FromRGBA(0.6f, 0.6f, 0.6f, 1.0f).SetStroke();
			circleColor.SetStroke();

			// Add a shape to the context
			//ctx.AddArc(center.X, center.Y, maxRadius, 0, (float)(Math.PI * 2), true);

			// Perform the drawing operation - draw current shape with current state
			//ctx.DrawPath(CGPathDrawingMode.Stroke);

			float r = 1;
			float g = 0;
			float b = 0;


			// Draw concentric circles from the outside in
			for (float currentRadius = maxRadius; currentRadius > 0; currentRadius -= 20) {
				ctx.AddArc(center.X, center.Y, currentRadius, 0, (float)(Math.PI * 2), true);
				ctx.SetStrokeColor(r ,g, b, 1);
				if (r > 0) {
					r -= 0.15f;
					g += 0.15f;
				}
				else if (g > 0) {
					g -= 0.15f;
					b += 0.15f;
				}
				ctx.DrawPath(CGPathDrawingMode.Stroke);
			}

			// Create a string
			NSString text = new NSString("You are getting sleepy");

			// Get a font to draw it in
			UIFont font = UIFont.BoldSystemFontOfSize(28);

			CGRect textRect = new CGRect();

			// How big is the string when drawn in this font?
			//textRect.Size = text.StringSize(font);
			UIStringAttributes attribs = new UIStringAttributes {Font = font};
			textRect.Size = text.GetSizeUsingAttributes(attribs);

			// Put the string in the center
			textRect.X = (float)(center.X - textRect.Size.Width / 2.0);
			textRect.Y = (float)(center.Y - textRect.Size.Height / 2.0);

			// Set the fill color of the current context to black
			UIColor.Black.SetFill();

			// Shadow
			CGSize offset = new CGSize(4, 3);
			CGColor color = new CGColor(0.2f, 0.2f, 0.2f, 1f);

			ctx.SetShadow(offset, 2.0f, color);

			// Draw the string
			text.DrawString(textRect, font); 

			// Crosshair
			ctx.SaveState();
			CGSize offset2 = new CGSize(0, 0);
			CGColor color2 = new CGColor(UIColor.Clear.CGColor.Handle);
			crossHairColor = UIColor.Green;
			crossHairColor.SetStroke();

			ctx.SetShadow(offset2, 0, color2);
			ctx.SetLineWidth(7);
			ctx.MoveTo(center.X -20, center.Y);
			ctx.AddLineToPoint(center.X + 20, center.Y);
			ctx.DrawPath(CGPathDrawingMode.Stroke);
			ctx.MoveTo(center.X, center.Y-20);
			ctx.AddLineToPoint(center.X, center.Y + 20);
			ctx.DrawPath(CGPathDrawingMode.Stroke);
			ctx.RestoreState(); 



		}

		public override bool CanBecomeFirstResponder{ get {return true;}}

		public override void MotionBegan(UIEventSubtype motion, UIEvent evt)
		{
			if (motion == UIEventSubtype.MotionShake) {
				Console.WriteLine("Device started shaking");
				if (CircleColor != UIColor.Red)
					CircleColor = UIColor.Red;
				else
					CircleColor = UIColor.LightGray;
			}
		}
	}
}












































