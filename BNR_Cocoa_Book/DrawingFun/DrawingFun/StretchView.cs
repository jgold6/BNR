using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CoreGraphics;
// Let the fun begin
namespace DrawingFun
{
    public partial class StretchView : AppKit.NSView
    {
		#region - Member Variables and Properties
		Random mRandom;
		NSBezierPath mPath;

		StretchImage mCurrentImage;
		List<StretchImage> mImages;
		nfloat mOpacity;

		public StretchImage Image {
			get {
				return mCurrentImage;
			}
			set {
				mCurrentImage = value;
				CGSize imageSize = mCurrentImage.Size;
				mCurrentImage.StartPoint = new CGPoint(0,0);
				CGPoint endPoint = new CGPoint(mCurrentImage.StartPoint.X + imageSize.Width, mCurrentImage.StartPoint.Y + imageSize.Height);
				mCurrentImage.EndPoint = endPoint;
				this.SetValueForKey(new NSNumber(1.0f), new NSString("Opacity"));
				mImages.Add(mCurrentImage);
				NeedsDisplay = true;
			}
		}

		[Export("opacity")]
		public nfloat Opacity {
			get {
				return mOpacity;
			}
			set {
				mOpacity = value;
				if (mCurrentImage != null)
					mCurrentImage.Opacity = value;
				NeedsDisplay = true;
			}
		}
		#endregion

        #region Constructors

        // Called when created from unmanaged code
        public StretchView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public StretchView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			mRandom = new Random();
			mImages = new List<StretchImage>();
        }

        #endregion

		#region - Overrides
		public override bool IsFlipped
		{
			get
			{
				return true;
			}
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			this.SetValueForKey(new NSNumber(1.0f), new NSString("Opacity"));

			mPath = new NSBezierPath();
			mPath.LineWidth = 3.0f;
//			CreateRandomPath();
//			CreateRandomOvals();
			CreateRandomCurves();
			Image = new StretchImage("LittleBeach.jpg");
		}

		public override void DrawRect(CoreGraphics.CGRect dirtyRect)
		{
			CGRect bounds = this.Bounds;
			// Fill view with green
			NSColor.Green.Set();
			NSBezierPath.FillRect(bounds);
			// Draw the path in white
			NSColor.Red.Set();
			mPath.Stroke();
			if (mImages.Count > 0) {
				foreach (StretchImage image in mImages) {
					StretchImage drawImage = image.GetFlippedImage();
					CGRect imageRect = new CGRect(0, 0, drawImage.Size.Width, drawImage.Size.Height);
					drawImage.DrawInRect(image.DrawingRect(), imageRect, NSCompositingOperation.SourceOver , image.Opacity);
				}
			}
		}

		#region - Mouse event handlers
		public override void MouseDown(NSEvent theEvent)
		{
//			Console.WriteLine("Mouse Down: {0}", theEvent.ClickCount);
			CGPoint p = theEvent.LocationInWindow;
			mCurrentImage.StartPoint = this.ConvertPointFromView(p, null);
			mCurrentImage.EndPoint = mCurrentImage.StartPoint;
			NeedsDisplay = true;
		}

		public override void MouseDragged(NSEvent theEvent)
		{
			CGPoint p = theEvent.LocationInWindow;
//			Console.WriteLine("Mouse Dragged: {0}", p.ToString());
			mCurrentImage.EndPoint = this.ConvertPointFromView(p, null);
			Autoscroll(theEvent);
			NeedsDisplay = true;
		}

		public override void MouseUp(NSEvent theEvent)
		{
//			Console.WriteLine("Mouse Up");
			CGPoint p = theEvent.LocationInWindow;
			mCurrentImage.EndPoint = this.ConvertPointFromView(p, null);
			NeedsDisplay = true;
		}
		#endregion // Mouse events
		#endregion // Overrides

		#region - Methods
		public void CreateRandomPath()
		{
			CGPoint p = RandomPoint();
			mPath.MoveTo(p);

			for (nint i = 0; i < 25; i++) {
				p = RandomPoint();
				mPath.LineTo(p);
			}
			mPath.ClosePath();
		}

		public void CreateRandomCurves()
		{
			CGPoint point1 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
			mPath.MoveTo(point1);
			for (nint i = 0; i < 25; i++) {
				point1 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
				CGPoint cp1 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
				CGPoint cp2 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
				mPath.CurveTo(point1, cp1, cp2);
			}
		}

		public void CreateRandomOvals()
		{
			for (nint i = 0; i < 25; i++) {

				CGRect rect = new CGRect(mRandom.Next((int)this.Bounds.Width),mRandom.Next((int)this.Bounds.Height), mRandom.Next(200), mRandom.Next(200));
				mPath.AppendPathWithOvalInRect(rect);
			}
		}

		private CGPoint RandomPoint()
		{
			CGPoint result = new CGPoint();
			CGRect r = this.Bounds;
			result.X = r.Location.X + mRandom.Next((int)r.Size.Width);
			result.Y = r.Location.Y + mRandom.Next((int)r.Size.Height);
			return result;
		}
		#endregion
    }
}
