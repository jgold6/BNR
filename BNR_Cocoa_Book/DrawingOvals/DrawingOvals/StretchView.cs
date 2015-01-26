using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CoreGraphics;
// Let the fun begin
namespace DrawingOvals
{
	public delegate void UndoDelegate(Oval oval);

    public partial class StretchView : AppKit.NSView
    {
		#region - Member Variables and Properties
		NSBezierPath mPath;
		Oval mCurrentOval;
		public List<Oval> Ovals {get; set;}
		public UndoDelegate AddToUndo {get; set;}
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

			mPath = new NSBezierPath();
			mPath.LineWidth = 3.0f;
		}

		public override void DrawRect(CoreGraphics.CGRect dirtyRect)
		{
			mPath.RemoveAllPoints();
			CGRect bounds = this.Bounds;
			// Fill view with green
			NSColor.Green.Set();
			NSBezierPath.FillRect(bounds);
			NSColor.White.Set();
			foreach (Oval oval in Ovals) {
				mPath.AppendPathWithOvalInRect(oval.Rect);
			}
			mPath.Stroke();
		}

		#region - Mouse event handlers
		public override void MouseDown(NSEvent theEvent)
		{
//			Console.WriteLine("Mouse Down: {0}", theEvent.ClickCount);
			CGPoint p = theEvent.LocationInWindow;
			mCurrentOval = new Oval();
			mCurrentOval.StartPoint = this.ConvertPointFromView(p, null);
			mCurrentOval.Endpoint = mCurrentOval.StartPoint;
			Ovals.Add(mCurrentOval);
			NeedsDisplay = true;
		}

		public override void MouseDragged(NSEvent theEvent)
		{
			CGPoint p = theEvent.LocationInWindow;
//			Console.WriteLine("Mouse Dragged: {0}", p.ToString());
			mCurrentOval.Endpoint = this.ConvertPointFromView(p, null);
			NeedsDisplay = true;
		}

		public override void MouseUp(NSEvent theEvent)
		{
//			Console.WriteLine("Mouse Up");
			CGPoint p = theEvent.LocationInWindow;
			mCurrentOval.Endpoint = this.ConvertPointFromView(p, null);
			NeedsDisplay = true;

			AddToUndo(mCurrentOval);
		}
		#endregion // Mouse events
		#endregion // Overrides

		#region - Methods
		#endregion
    }
}
