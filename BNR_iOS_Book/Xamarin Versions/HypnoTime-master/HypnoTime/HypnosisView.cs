using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.CoreAnimation;

namespace HypnoTime
{
	public class HypnosisView : UIView
	{
		public UIColor circleColor;
		CALayer boxLayer;

		public UIColor CircleColor
		{
			get {return circleColor;}
			set {circleColor = value; SetNeedsDisplay();}
		}

		public HypnosisView() : this(new RectangleF(UIScreen.MainScreen.Bounds.Location.X,UIScreen.MainScreen.Bounds.Location.Y, UIScreen.MainScreen.Bounds.Size.Width, UIScreen.MainScreen.Bounds.Height))
		{

		}

		public HypnosisView(RectangleF frame)
		{
			Frame = frame;
			BackgroundColor = UIColor.Clear;
			circleColor = UIColor.LightGray;

			// Create the new layer object
			boxLayer = new CALayer();

			// Give it a size
			boxLayer.Bounds = new RectangleF(0.0f, 0.0f, 85.0f, 85.0f);

			// Give it a location
			boxLayer.Position = new PointF(160.0f, 100.0f);

			// Round the corners
			boxLayer.CornerRadius = 20.0f;

			// Set a shadow
			UIColor shadowColor = UIColor.Blue;
			boxLayer.ShadowColor = shadowColor.CGColor;
			boxLayer.ShadowOffset = new SizeF(5.0f, 5.0f);
			boxLayer.ShadowOpacity = 1.0f;

			// Make half transparent red the background color for the layer
			UIColor reddish = new UIColor(1.0f, 0.0f, 0.0f, 1.0f);

			// Get a CGColor object with the same color values
			CGColor cgReddish = reddish.CGColor;
			boxLayer.BackgroundColor = cgReddish;
			boxLayer.Opacity = 0.5f;

			// Create a UIImage
			UIImage layerImage = new UIImage("Hypno.png");

			// Get the underlying CGimage
			CGImage image = layerImage.CGImage;

			// Put the CGImage on the layer
			boxLayer.Contents = image;

			// Inset the image a but on each side
			boxLayer.ContentsRect = new RectangleF(-0.1f, -0.1f, 1.2f, 1.2f);

			// Let the image resize (without changing aspect ratio
			// to fill the contentRct
			boxLayer.ContentsGravity = CALayer.GravityResizeAspect;

			//
			// Boxlayers sublayer
			// Create the new layer object
			CALayer boxSublayer = new CALayer();

			// Give it a size
			boxSublayer.Bounds = new RectangleF(0.0f, 0.0f, boxLayer.Bounds.Size.Width/2, boxLayer.Bounds.Size.Height/2);

			// Give it a location
			boxSublayer.Position = new PointF(boxLayer.Bounds.Size.Width/2, boxLayer.Bounds.Size.Height/2);

			// Round the corners
			boxSublayer.CornerRadius = 10.0f;

			// Make half transparent red the background color for the layer
			UIColor greenish = new UIColor(0.0f, 1.0f, 0.0f, 0.5f);

			// Get a CGColor object with the same color values
			CGColor cgGreenish = greenish.CGColor;
			boxSublayer.BackgroundColor = cgGreenish;

			// Create a UIImage
			UIImage subLayerImage = new UIImage("Map.png");

			// Get the underlying CGimage
			CGImage subImage = subLayerImage.CGImage;

			// Put the CGImage on the layer
			boxSublayer.Contents = subImage;

			// Let the image resize (without changing aspect ratio
			// to fill the contentRct
			boxSublayer.ContentsGravity = CALayer.GravityResizeAspect;
			// end boxlayers sublayer
			//

			// Make it a sublayer of the view's layer
			boxLayer.AddSublayer(boxSublayer);
			this.Layer.AddSublayer(boxLayer);
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			UITouch t = touches.AnyObject as UITouch;
			PointF p = t.LocationInView(this);
			boxLayer.Position = p;

		}

		public override void TouchesMoved(NSSet touches, UIEvent evt)
		{
			UITouch t = touches.AnyObject as UITouch;
			PointF p = t.LocationInView(this);
			CATransaction.Begin();
			CATransaction.DisableActions = true;
			boxLayer.Position = p;
			CATransaction.Commit();
		}


		public override void Draw(RectangleF rect)
		{
			base.Draw(rect);
	
			// Get current drawing context
			CGContext ctx = UIGraphics.GetCurrentContext(); 
			// Get bounds of view
			RectangleF bounds = this.Bounds;

			// Figure out the center of the bounds rectangle
			PointF center = new Point();
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

			// Draw concentric circles from the outside in
			for (float currentRadius = maxRadius; currentRadius > 0; currentRadius -= 20) {
				ctx.AddArc(center.X, center.Y, currentRadius, 0, (float)(Math.PI * 2), true);
				ctx.DrawPath(CGPathDrawingMode.Stroke);
			}

			// Create a string
			NSString text = new NSString("You are getting sleepy");

			// Get a font to draw it in
			UIFont font = UIFont.BoldSystemFontOfSize(28);

			RectangleF textRect = new RectangleF();

			// How big is the string when drawn in this font?
			textRect.Size = text.StringSize(font);
			//UIStringAttributes attribs = new UIStringAttributes {Font = font};
			//textRect.Size = text.GetSizeUsingAttributes(attribs);

			// Put the string in the center
			textRect.X = (float)(center.X - textRect.Size.Width / 2.0);
			textRect.Y = (float)(center.Y - textRect.Size.Height / 2.0);

			// Set the fill color of the current context to black
			UIColor.Black.SetFill();

			// Shadow
			SizeF offset = new SizeF(4, 3);
			CGColor color = new CGColor(0.2f, 0.2f, 0.2f, 1f);

			ctx.SetShadowWithColor(offset, 2.0f, color);

			// Draw the string
			text.DrawString(textRect, font); 
		}
	}
}












































