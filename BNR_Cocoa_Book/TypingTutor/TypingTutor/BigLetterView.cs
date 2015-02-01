using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CoreGraphics;

namespace TypingTutor
{
    public partial class BigLetterView : AppKit.NSView
    {
		#region - Member variables and Properties
		NSColor mBgColor;
		public NSColor BgColor {
			get {
				return mBgColor;
			}
			set {
				mBgColor = value;
				NeedsDisplay = true;
			}
		}

		string mLetter;
		public string Letter {
			get {
				return mLetter;
			}
			set {
				mLetter = value;
				NeedsDisplay = true;
				Console.WriteLine("The letter is now {0}", mLetter);
			}
		}
		#endregion

        #region Constructors

        // Called when created from unmanaged code
        public BigLetterView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
		public BigLetterView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			Console.WriteLine("Initializing BigLetterView");
			mBgColor = NSColor.Yellow;
			mLetter = " ";
        }

        #endregion

		#region - Overrides
		public override bool IsOpaque
		{
			get
			{
				return true;
			}
		}

		public override bool AcceptsFirstResponder()
		{
			Console.WriteLine("Accepting First Repsonder");
			return true;
		}

		public override bool BecomeFirstResponder()
		{
			Console.WriteLine("Becoming First Repsonder");
			NeedsDisplay = true;
			return true;
		}

		public override bool ResignFirstResponder()
		{
			Console.WriteLine("Resigning First Repsonder");
			NeedsDisplay = true;
			return true;
		}

		public override void KeyDown(NSEvent theEvent)
		{
			this.InterpretKeyEvents(new NSEvent[]{theEvent});
		}

		[Export("insertText:")]
		public void InsertText(NSString input)
		{
			this.Letter = input.ToString();
		}

		[Export("insertTab:")]
		public void InsertTab(NSObject sender)
		{
			this.Window.SelectKeyViewFollowingView(this);
		}

		[Export("insertBacktab:")]
		public void InsertBacktab(NSObject sender)
		{
			this.Window.SelectKeyViewPrecedingView(this);
		}

		[Export("deleteBackward:")]
		public void DeleteBackward(NSObject sender)
		{
			this.Letter = " ";
		}

		public override void DrawRect(CoreGraphics.CGRect dirtyRect)
		{
			CGRect bounds = this.Bounds;
			// Fill view with green
			mBgColor.Set();
			NSBezierPath.FillRect(bounds);

			// Am I the window's first responder?
			if (this.Window.FirstResponder == this) {
				Console.WriteLine("BigLetterView is first responder");
				NSColor.KeyboardFocusIndicator.Set();
				NSBezierPath.DefaultLineWidth = 4.0f;
				NSBezierPath.StrokeRect(bounds);	

				NSString drawLetter = new NSString(mLetter);
				NSMutableDictionary attributes = new NSMutableDictionary();
				attributes.Add(NSAttributedString.FontAttributeName, NSFont.FromFontName("Helvetica", 228.0f));
				var textSize = drawLetter.StringSize(attributes);

				drawLetter.DrawString(new CGPoint(bounds.Width/2-textSize.Width/2, bounds.Height/2-textSize.Height/2), attributes);
			}
		}
		#endregion
    }
}
