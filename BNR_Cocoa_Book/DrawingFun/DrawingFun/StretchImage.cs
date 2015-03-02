using System;
using AppKit;
using Foundation;
using CoreGraphics;
using ObjCRuntime;


namespace DrawingFun
{
    public class StretchImage : NSImage
    {
		#region - Member Variables and Properties

		public nfloat Opacity {get; set;}
		public CGPoint StartPoint {get; set;}
		public CGPoint EndPoint {get; set;}

		#endregion

        #region - Constructors
		public StretchImage()
		{
			Initialize();
		}

		public StretchImage(NSUrl url) : base(url)
		{
			Initialize();
		}

		public StretchImage(string file) : base(file)
		{
			Initialize();
		}

		public StretchImage(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		public StretchImage(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		public StretchImage(NSObjectFlag flag) : base(flag)
		{
			Initialize();
		}

		void Initialize()
		{
			Opacity = 1.0f;
		}

		#endregion

		#region - Methods
		public StretchImage GetFlippedImage()
		{
			NSAffineTransform t = new NSAffineTransform();
			StretchImage image = (StretchImage)this.Copy();
			CGSize dimensions = image.Size;

			nint scaleX = 1;
			nint scaleY = 1;
			nfloat drawPointX = 0;
			nfloat drawPointY = 0;
			if (EndPoint.X < StartPoint.X)
			{
				scaleX = -1;
				drawPointX = scaleX * dimensions.Width;
			}
			if (EndPoint.Y > StartPoint.Y)
			{
				scaleY = -1;
				drawPointY = scaleY * dimensions.Height;
			}

			image.LockFocus();
			t.Scale(scaleX, scaleY);
			t.Concat(); 

			image.Draw(new CGPoint(drawPointX, drawPointY), new CGRect(0, 0, dimensions.Width, dimensions.Height), NSCompositingOperation.SourceOver, 1);
			image.UnlockFocus();
			return image;
		}

		public CGRect DrawingRect()
		{
			nfloat minX = (nfloat)Math.Min(StartPoint.X, EndPoint.X);
			nfloat maxX = (nfloat)Math.Max(StartPoint.X, EndPoint.X);
			nfloat minY = (nfloat)Math.Min(StartPoint.Y, EndPoint.Y);
			nfloat maxY = (nfloat)Math.Max(StartPoint.Y, EndPoint.Y);

			return new CGRect(minX, minY, maxX-minX, maxY-minY);
		}

		#endregion


		public override NSObject Copy(NSZone zone)
		{
			StretchImage image = (StretchImage)base.Copy(zone);
			image.StartPoint = this.StartPoint;
			image.EndPoint = this.EndPoint;
			image.Opacity = this.Opacity;
			image.PerformSelector(new Selector("retain"));
			return image;
		}
    }
}

