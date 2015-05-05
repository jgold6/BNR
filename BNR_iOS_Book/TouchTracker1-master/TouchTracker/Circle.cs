using System;
using System.Drawing;
using MonoTouch.Foundation;
using SQLite;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;


namespace TouchTracker
{
	[Table ("Circles")]
	public class Circle // : NSObject // Archive method of saving
	{
		[PrimaryKey, AutoIncrement, MaxLength(8)]
		public int ID {get; set;}

		public float centerx {get; set;}
		public float centery {get; set;}
		public float point2x {get; set;}
		public float point2y {get; set;}

		UIColor _color;

		[Ignore]
		public UIColor color {
			get {
				return _color;
			}
		}

		public void setColor()
		{
			double xDiff = this.point2.X - this.center.X;
			double yDiff = this.point2.Y - this.center.Y;
			double angle = Math.Atan2(yDiff, xDiff) * (180.0d / Math.PI);
			Console.WriteLine("Angle = {0}", angle);
			double red = Math.Abs(angle)/180.0d;
			double green = 1.0d - Math.Abs(angle)/180.0d;
			double blue = 0.0d;
			if (Math.Abs(angle) > 90.0d)
				blue = (Math.Abs(angle)-180.0d)/-90.0d;
			else
				blue = Math.Abs(angle)/90.0d;
			_color = new UIColor((float)red, (float)green, (float)blue, 1.0f);
		}

		public void setColor(UIColor clr)
		{
			_color = clr;
		}

		[Ignore]
		public PointF center {
			get {
				return new PointF(centerx, centery);
			}
			set {
				centerx = value.X;
				centery = value.Y;
			}
		}

		[Ignore]
		public PointF point2 {
			get {
				return new PointF(point2x, point2y);
			}
			set {
				point2x = value.X;
				point2y = value.Y;
			}
		} 

		public Circle()
		{
		}

		public void draw(CGContext context)
		{
			double radius = Math.Sqrt(Math.Pow((this.center.X - this.point2.X)/2, 2) + Math.Pow((this.center.Y - this.point2.Y)/2, 2));

			context.AddArc(this.center.X, this.center.Y, (float)radius, 0.0f, (float)Math.PI * 2, true);

			_color.SetStroke();

			context.StrokePath();
		}

		// Archive method of saving
		//		[Export("initWithCoder:")]
		//		public Line(NSCoder decoder)
		//		{
		//			this.begin.X = decoder.DecodeFloat("beginx");
		//			this.begin.Y = decoder.DecodeFloat("beginy");
		//			this.end.X = decoder.DecodeFloat("endx");
		//			this.end.Y =  decoder.DecodeFloat("endy");
		//		}
		//
		//		public override void EncodeTo (NSCoder coder)
		//		{
		//			coder.Encode(this.begin.X, "beginx");
		//			coder.Encode(this.begin.Y, "beginy");
		//			coder.Encode(this.end.X, "endx");
		//			coder.Encode(this.end.Y, "endy");
		//		}
	}
}

