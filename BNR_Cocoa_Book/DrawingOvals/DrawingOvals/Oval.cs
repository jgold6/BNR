using System;
using CoreGraphics;
using Foundation;

namespace DrawingOvals
{
    public class Oval : NSObject
    {
		[Export("startPoint")]
		public CGPoint StartPoint {get; set;}
		[Export("endPoint")]
		public CGPoint Endpoint {get; set;}

		public CGRect Rect {
			get {
				return new CGRect(StartPoint.X, StartPoint.Y, Endpoint.X - StartPoint.X, Endpoint.Y - StartPoint.Y);
			}
		}

		public Oval() : base()
		{

		}

		[Export("initWithCoder:")]
		public Oval(NSCoder decoder)
		{
			StartPoint = new CGPoint(decoder.DecodeFloat("startPointX"), decoder.DecodeFloat("startPointY"));

			Endpoint = new CGPoint(decoder.DecodeFloat("endPointX"), decoder.DecodeFloat("endPointY"));
		}

		[Export("encodeWithCoder:")]
		public void EncodeTo(NSCoder coder)
		{
			coder.Encode(StartPoint.X, "startPointX");
			coder.Encode(StartPoint.Y, "startPointY");
			coder.Encode(Endpoint.X, "endPointX");
			coder.Encode(Endpoint.Y, "endPointY");
		}
    }
}

