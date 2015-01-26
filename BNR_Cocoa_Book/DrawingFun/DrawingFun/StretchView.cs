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
		#region - Member Variables
		Random mRandom;
		NSBezierPath mPath;

		CGPoint mDownPoint;
		CGPoint mCurrentPoint;

		NSImage mImage;
		nfloat mOpacity;

		public NSImage Image {
			get {
				return mImage;
			}
			set {
				mImage = value;
				CGSize imageSize = mImage.Size;
				mDownPoint = new CGPoint(0,0);
				mCurrentPoint.X = mDownPoint.X + imageSize.Width;
				mCurrentPoint.Y = mDownPoint.Y + imageSize.Height;
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
        }

        #endregion

		#region - Overrides
//		public override bool IsFlipped
//		{
//			get
//			{
//				return true;
//			}
//		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			this.SetValueForKey(new NSNumber(1.0f), new NSString("Opacity"));

			mPath = new NSBezierPath();
			mPath.LineWidth = 3.0f;
//			CreateRandomPath();
//			CreateRandomOvals();
			CreateRandomCurves();
		}

		public override void DrawRect(CoreGraphics.CGRect dirtyRect)
		{
			CGRect bounds = this.Bounds;
			// Fill view with green
			NSColor.Green.Set();
			NSBezierPath.FillRect(bounds);
			// Draw the path in white
			NSColor.Red.Set();
			mPath.Fill();
			if (mImage != null) {
				CGRect imageRect = new CGRect(0, 0, mImage.Size.Width, mImage.Size.Height);
				CGRect drawingRect = CurrentRect();
				mImage.DrawInRect(drawingRect, imageRect, NSCompositingOperation.SourceOver , mOpacity);
			}
		}

		#region - Mouse event handlers
		public override void MouseDown(NSEvent theEvent)
		{
//			Console.WriteLine("Mouse Down: {0}", theEvent.ClickCount);
			CGPoint p = theEvent.LocationInWindow;
			mDownPoint = this.ConvertPointFromView(p, null);
			mCurrentPoint = mDownPoint;
			NeedsDisplay = true;
		}

		public override void MouseDragged(NSEvent theEvent)
		{
			CGPoint p = theEvent.LocationInWindow;
//			Console.WriteLine("Mouse Dragged: {0}", p.ToString());
			mCurrentPoint = this.ConvertPointFromView(p, null);
			Autoscroll(theEvent);
			NeedsDisplay = true;
		}

		public override void MouseUp(NSEvent theEvent)
		{
//			Console.WriteLine("Mouse Up");
			CGPoint p = theEvent.LocationInWindow;
			mCurrentPoint = this.ConvertPointFromView(p, null);
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

		private CGRect CurrentRect()
		{
			nfloat minX = (nfloat)Math.Min(mDownPoint.X, mCurrentPoint.X);
			nfloat maxX = (nfloat)Math.Max(mDownPoint.X, mCurrentPoint.X);
			nfloat minY = (nfloat)Math.Min(mDownPoint.Y, mCurrentPoint.Y);
			nfloat maxY = (nfloat)Math.Max(mDownPoint.Y, mCurrentPoint.Y);

			return new CGRect(minX, minY, maxX-minX, maxY-minY);
		}
		#endregion
    }
}
