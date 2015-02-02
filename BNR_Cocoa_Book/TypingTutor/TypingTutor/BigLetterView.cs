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
		NSMutableDictionary mAttributes;

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
			PrepareAttributes();
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

		public override CGRect FocusRingMaskBounds
		{
			get
			{
				return this.Bounds;
			}
		}

		public override void DrawFocusRingMask()
		{
			NSBezierPath.FillRect(this.Bounds);
		}

		public override void DrawRect(CoreGraphics.CGRect dirtyRect)
		{
			CGRect bounds = this.Bounds;
			// Fill view with green
			mBgColor.Set();
			NSBezierPath.FillRect(bounds);


			// Using the system focus ring instead. Achieved by overriding DrawFocusRingMask and FocusRingMaskBounds
//			// Am I the window's first responder? 
//			if (this.Window.FirstResponder == this) {
//				Console.WriteLine("BigLetterView is first responder");
//
//				NSColor.KeyboardFocusIndicator.Set();
//				NSBezierPath.DefaultLineWidth = 4.0f;
//				NSBezierPath.StrokeRect(bounds);	
//			}

			DrawStringCenteredInRectangle(mLetter, bounds);
		}
		#endregion

		#region - Actions
		[Action ("savePDF:")]
		public void SavePDF (Foundation.NSObject sender)
		{
			NSSavePanel panel = NSSavePanel.SavePanel;
			panel.AllowedFileTypes = new string[]{"pdf"};
			panel.BeginSheet(this.Window, (result) =>  {
				if (result == 1) {
					CGRect r = this.Bounds;
					NSData data = this.DataWithPdfInsideRect(r);
					NSError error = null;
					bool successful = data.Save(panel.Url, false, out error);
					if (!successful) {
						NSAlert a = NSAlert.WithError(error);
						a.RunModal();
					}
				}
				panel = null;
			});
		}
		#endregion

		#region - Methods
		void PrepareAttributes()
		{
			mAttributes = new NSMutableDictionary();
			mAttributes.Add(NSAttributedString.FontAttributeName, NSFont.UserFontOfSize(75.0f));
			mAttributes.Add(NSAttributedString.ForegroundColorAttributeName, NSColor.Red);
		}

		void DrawStringCenteredInRectangle(string str, CGRect rect)
		{
			NSString drawLetter = new NSString(str);
			CGSize strSize = drawLetter.StringSize(mAttributes);
			CGPoint strOrigin = new CGPoint();
			strOrigin.X = rect.Location.X + (rect.Size.Width - strSize.Width)/2;
			strOrigin.Y = rect.Location.Y + (rect.Size.Height - strSize.Height)/2;
			drawLetter.DrawString(strOrigin, mAttributes);
		}
		#endregion
    }
}
