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
		// Allowed pasteboard types: String and PDF images
		private string[] pboardTypes = new string[] {NSPasteboard.NSStringType.ToString(), NSPasteboard.NSPdfType.ToString()};

		// Attributes for the text
		NSMutableDictionary mTextAttributes;
		NSEvent mMouseDownEvent;

		// Bound to the colorwell and the textfield for the color (using ColorFormatter for text to color and color to text conversion)
		NSColor mBgColor;
		[Export("bgColor")]
		public NSColor BgColor {
			get {
				return mBgColor;
			}
			set {
				mBgColor = value;
				NeedsDisplay = true;
			}
		}

		// The leter displayed in the view
		string mLetter;
		public string Letter {
			get {
				return mLetter;
			}
			set {
				mLetter = value;
				NeedsDisplay = true;
//				Console.WriteLine("The letter is now {0}", mLetter == "" ? "<empty>": mLetter);
			}
		}
		public bool Bold {get; set;}
		public bool Italic {get; set;}
		public bool LetterShadow {get; set;}
		public bool Highlighted {get; set;}
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
			PrepareTextAttributes();
			BgColor = NSColor.Yellow;
			mLetter = "";
			Bold = false;
			Italic = false;
			LetterShadow = false;
			Highlighted = false;
			// Allow string pasteboard types to be dragged into this view
			RegisterForDraggedTypes(new string[]{pboardTypes[0]});
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
			return true;
		}

		public override bool BecomeFirstResponder()
		{
			// Enable the bold, italic and shadow buttons and set them according to whether bold, italic, and shadow are set for the view
			if (btnBold != null && btnItalic != null && btnShadow != null) {
				btnBold.Enabled = true;
				btnItalic.Enabled = true;
				btnShadow.Enabled = true;
				btnBold.State = Bold ? NSCellStateValue.On : NSCellStateValue.Off;
				btnItalic.State = Italic ? NSCellStateValue.On : NSCellStateValue.Off;
				btnShadow.State = LetterShadow ? NSCellStateValue.On : NSCellStateValue.Off;
			}

			NeedsDisplay = true;
			return true;
		}

		public override bool ResignFirstResponder()
		{
			// Enable the bold, italic and shadow buttons and set them according to whether bold, italic, and shadow are set for the view
			if (btnBold != null && btnItalic != null && btnShadow != null) {
				btnBold.State = NSCellStateValue.Off;
				btnItalic.State = NSCellStateValue.Off;
				btnShadow.State = NSCellStateValue.Off;
				btnBold.Enabled = false;
				btnItalic.Enabled = false;
				btnShadow.Enabled = false;
			}
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
			// Set the letter pressed on key down
			this.Letter = input.ToString();
			if (tutorController.outLetterView.Letter == this.Letter) {
				SetValueForKey(NSColor.Green, new NSString("BgColor"));
			}
			else {
				SetValueForKey(NSColor.Red, new NSString("BgColor"));
			}
		}

		[Export("insertTab:")]
		public void InsertTab(NSObject sender)
		{
			// Tab through first responder views
			this.Window.SelectKeyViewFollowingView(this);
		}

		[Export("insertBacktab:")]
		public void InsertBacktab(NSObject sender)
		{
			// Tab backwards through first responder views
			this.Window.SelectKeyViewPrecedingView(this);
		}

		[Export("deleteBackward:")]
		public void DeleteBackward(NSObject sender)
		{
			// Delete the letter
			this.Letter = "";
		}

		public override void MouseDown(NSEvent theEvent)
		{
			base.MouseDown(theEvent);
			mMouseDownEvent = theEvent;
		}

		public override void MouseDragged(NSEvent theEvent)
		{
			base.MouseDragged(theEvent);
			CGPoint down = mMouseDownEvent.LocationInWindow;
			CGPoint drag = theEvent.LocationInWindow;
			// Calculate the distance between this dragging position and the mouse down position
			double distance = Math.Sqrt( Math.Pow( down.X - drag.X ,2) + Math.Pow(down.Y - drag.Y, 2) );
			// Don't do too often
			if (distance < 3) {
				return;
			}

			// And not if there is no string to drag
			if (mLetter.Length == 0) {
				return;
			}

			// Get the size of the string
			CGSize size = mLetter.StringSize(mTextAttributes);

			// Create the image that will be dragged
			NSImage anImage = new NSImage(size);

			// Create a rect in which you will draw the letter
			// in the image
			CGRect imageBounds = CGRect.Empty;
			imageBounds.Location = new CGPoint(0.0f, 0.0f);
			imageBounds.Size = size;

			// Draw the letter on the image
			anImage.LockFocus();
			DrawStringCenteredInRectangle(mLetter, imageBounds);
			anImage.UnlockFocus();

			// Get the location of the mouse down event
			CGPoint p = this.ConvertPointFromView(down, null);

			// Drag from the center of theimage
			p = new CGPoint(p.X - size.Width/2, p.Y - size.Height/2);

			// Get the pasteboard
			NSPasteboard pb = NSPasteboard.FromName(NSPasteboard.NSDragPasteboardName);

			// Put the string and the pdf image in the pasteboard
			WriteToPasteBoard(pb);

			// Start the drag - deprecated, should use BeginDraggingSession, but need to wait for new Xam.Mac. Bug filed. #26941
			this.DragImage(anImage, p,CGSize.Empty, mMouseDownEvent, pb, this, true);
		}

		[Export("draggedImage:endedAt:operation:")]
		public void DraggedImageEndedAtOperation(NSImage image, CGPoint screenPoint, NSDragOperation operation)
		{
			if (operation == NSDragOperation.Delete) {
				Letter = "";
			}
		}

		public override NSDragOperation DraggingEntered(NSDraggingInfo sender)
		{
			if (sender.DraggingSource == this) {
				return NSDragOperation.None;
			}
			Highlighted = true;
			NeedsDisplay = true;

			return NSDragOperation.Copy;
		}

		public override NSDragOperation DraggingUpdated(NSDraggingInfo sender)
		{
			NSDragOperation op = sender.DraggingSourceOperationMask;
			if (sender.DraggingSource == this) {
				return NSDragOperation.None;
			}
			return NSDragOperation.Copy;
		}

		public override void DraggingExited(NSDraggingInfo sender)
		{
			Highlighted = false;
			NeedsDisplay = true;
		}

		public override bool PrepareForDragOperation(NSDraggingInfo sender)
		{
			return true;
		}

		public override bool PerformDragOperation(NSDraggingInfo sender)
		{
			NSPasteboard pb = sender.DraggingPasteboard;
			if (!ReadFromPasteboard(pb)) {
				Console.WriteLine("Error: could not read from dragging pasteboard");
				Highlighted = false;
				NeedsDisplay = true;
				return false;
			}
			return true;
		}

		public override void ConcludeDragOperation(NSDraggingInfo sender)
		{
			Highlighted = false;
			NeedsDisplay = true;
		}

		// To get standard focus ring
		public override CGRect FocusRingMaskBounds
		{
			get
			{
				return this.Bounds;
			}
		}
		// To get standard focus ring
		public override void DrawFocusRingMask()
		{
			NSBezierPath.FillRect(this.Bounds);
		}

		// Draw the view
		public override void DrawRect(CoreGraphics.CGRect dirtyRect)
		{
			CGRect bounds = this.Bounds;

			// Using the system focus ring instead. Achieved by overriding DrawFocusRingMask and FocusRingMaskBounds
//			// Am I the window's first responder? 
//			if (this.Window.FirstResponder == this) {
//				NSColor.KeyboardFocusIndicator.Set();
//				NSBezierPath.DefaultLineWidth = 4.0f;
//				NSBezierPath.StrokeRect(bounds);	
//			}

			if (Highlighted) {
				NSGradient gr = new NSGradient(NSColor.White, mBgColor);
				gr.DrawInRect(bounds, new CGPoint(0.0f, 0.0f));
			} else {
				mBgColor.Set();
				NSBezierPath.FillRect(bounds);
			}

			DrawStringCenteredInRectangle(mLetter, bounds);
		}

		[Export("draggingSourceOperationMaskForLocal:")]
		public NSDragOperation DraggingSourceOperationMaskForLocal(bool isLocal)
		{
			return NSDragOperation.Copy | NSDragOperation.Delete;
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

		partial void boldChecked (Foundation.NSObject sender)
		{
			Bold = !Bold;
			PrepareTextAttributes();
			NeedsDisplay = true;
//			Console.WriteLine("Bold: {0}", Bold);
		}

		partial void italicChecked (Foundation.NSObject sender)
		{
			Italic = !Italic;
			PrepareTextAttributes();
			NeedsDisplay = true;
//			Console.WriteLine("Italic: {0}",Italic);
		}

		partial void shadowChecked (Foundation.NSObject sender)
		{
			LetterShadow = !LetterShadow;
			NeedsDisplay = true;
//			Console.WriteLine("Italic: {0}",Italic);
		}

		partial void Cut (Foundation.NSObject sender)
		{
			Copy(sender);
			Letter = "";
		}

		partial void Copy (Foundation.NSObject sender)
		{
			NSPasteboard pb = NSPasteboard.GeneralPasteboard;
			WriteToPasteBoard(pb);
		}

		partial void Paste (Foundation.NSObject sender)
		{
			NSPasteboard pb = NSPasteboard.GeneralPasteboard;
			if (!ReadFromPasteboard(pb)) {
				AppKitFramework.NSBeep();
			}

		}
		#endregion

		#region - Methods
		void PrepareTextAttributes()
		{
			mTextAttributes = new NSMutableDictionary();
			NSFontManager fontManager = NSFontManager.SharedFontManager;
			NSFont font = NSFont.UserFontOfSize(75.0f);
			if (Bold) {
				font = fontManager.ConvertFont(font, NSFontTraitMask.Bold);
			}
			if (Italic) {
				font = fontManager.ConvertFont(font, NSFontTraitMask.Italic);
			}
			mTextAttributes.Add(NSAttributedString.FontAttributeName, font);
			mTextAttributes.Add(NSAttributedString.ForegroundColorAttributeName, NSColor.Black);
		}

		void DrawStringCenteredInRectangle(string str, CGRect rect)
		{
			NSString drawLetter = new NSString(str);
			CGSize strSize = drawLetter.StringSize(mTextAttributes);
			CGPoint strOrigin = new CGPoint();
			strOrigin.X = rect.Location.X + (rect.Size.Width - strSize.Width)/2;
			strOrigin.Y = rect.Location.Y + (rect.Size.Height - strSize.Height)/2;
			if (LetterShadow) {
				NSShadow shadow = new NSShadow();
				shadow.ShadowBlurRadius = 8.0f;
				shadow.ShadowOffset = new CGSize(5.0f, 5.0f);
				shadow.ShadowColor = NSColor.Gray;
				shadow.Set();
			}
			drawLetter.DrawString(strOrigin, mTextAttributes);
		}

		public void WriteToPasteBoard(NSPasteboard pb)
		{
			// Copy data to the pasteboard
			pb.ClearContents();
			pb.DeclareTypes(pboardTypes, null);
			pb.SetStringForType(mLetter, pboardTypes[0]);
			CGRect r = this.Bounds;
			NSData data = this.DataWithPdfInsideRect(r);
			pb.SetDataForType(data, pboardTypes[1]);
		}

		public bool ReadFromPasteboard(NSPasteboard pb)
		{
			string pbString = pb.GetStringForType(pboardTypes[0]);

			if (pbString != null) {
				// Read the string from the pasteboard
				// Our view can only handle one letter
				Letter = pbString.GetFirstLetter();
				return true;
			}
			return false;
		}
		#endregion
    }
}
