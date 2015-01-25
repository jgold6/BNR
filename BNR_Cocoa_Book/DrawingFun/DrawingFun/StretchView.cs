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
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
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
			mPath.Stroke();
		}
		#endregion

		#region - Methods

		public void CreateRandomPath()
		{
			CGPoint p = RandomPoint();
			mPath.MoveTo(p);

			for (int i = 0; i < 25; i++) {
				p = RandomPoint();
				mPath.LineTo(p);
			}
			mPath.ClosePath();
		}

		public void CreateRandomCurves()
		{
			CGPoint point1 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
			mPath.MoveTo(point1);
			for (int i = 0; i < 25; i++) {
				point1 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
				CGPoint cp1 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
				CGPoint cp2 = new CGPoint(mRandom.Next((int)this.Bounds.Width), mRandom.Next((int)this.Bounds.Height));
				mPath.CurveTo(point1, cp1, cp2);
			}
		}

		public void CreateRandomOvals()
		{
			for (int i = 0; i < 25; i++) {

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
