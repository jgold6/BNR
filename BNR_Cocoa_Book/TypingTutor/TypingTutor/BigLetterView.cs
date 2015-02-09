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
		private string[] pboardTypes = new string[] {NSPasteboard.NSStringType.ToString(), NSPasteboard.NSPdfType.ToString()};

		NSMutableDictionary mAttributes;
		NSEvent mMouseDownEvent;

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
				Console.WriteLine("The letter is now {0}", mLetter == "" ? "<empty>": mLetter);
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
			Console.WriteLine("Initializing BigLetterView\n {0}", NSPasteboard.NSStringType);
			PrepareAttributes();
			mBgColor = NSColor.Yellow;
			mLetter = "";
			Bold = false;
			Italic = false;
			LetterShadow = false;
			Highlighted = false;
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
			Console.WriteLine("Accepting First Repsonder");
			return true;
		}

		public override bool BecomeFirstResponder()
		{
			Console.WriteLine("Becoming First Repsonder");

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
			Console.WriteLine("Resigning First Repsonder");
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
			double distance = Math.Sqrt( Math.Pow( down.X - drag.X ,2) + Math.Pow(down.Y - drag.Y, 2) );
			if (distance < 3) {
				return;
			}

			// Is the string zero length?
			if (mLetter.Length == 0) {
				return;
			}

			// Get the size of the string
			CGSize size = mLetter.StringSize(mAttributes);

			// Create the image that will be dragged
			NSImage anImage = new NSImage(size);

			// Create a rect in which you will draw the letter
			// in the image
			CGRect imageBounds = CGRect.Empty;
			imageBounds.Location = new CGPoint(0.0f, 0.0f);
			imageBounds.Size = size;

			// Draw the letter on the image
			anImage.LockFocus();
			this.DrawStringCenteredInRectangle(mLetter, imageBounds);
			anImage.UnlockFocus();

			// Get the location of the mouse down event
			CGPoint p = this.ConvertPointFromView(down, null);

			// Drag from the center of theimage
			p = new CGPoint(p.X - size.Width/2, p.Y - size.Height/2);

			// Get the pasteboard
			NSPasteboard pb = NSPasteboard.FromName(NSPasteboard.NSDragPasteboardName);

			// Put the string in the pasteboard
			WriteToPasteBoard(pb);

			// Start the drag
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
			Console.WriteLine("Dragging Entered");
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
			Console.WriteLine("Operation Mask: {0}", op);
			if (sender.DraggingSource == this) {
				return NSDragOperation.None;
			}
			return NSDragOperation.Copy;
		}

		public override void DraggingExited(NSDraggingInfo sender)
		{
			Console.WriteLine("Dragging Exited");
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
			Console.WriteLine("Dragging Concluded");
			Highlighted = false;
			NeedsDisplay = true;
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

			// Using the system focus ring instead. Achieved by overriding DrawFocusRingMask and FocusRingMaskBounds
//			// Am I the window's first responder? 
//			if (this.Window.FirstResponder == this) {
//				Console.WriteLine("BigLetterView is first responder");
//
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
			PrepareAttributes();
			NeedsDisplay = true;
			Console.WriteLine("Bold: {0}", Bold);
		}

		partial void italicChecked (Foundation.NSObject sender)
		{
			Italic = !Italic;
			PrepareAttributes();
			NeedsDisplay = true;
			Console.WriteLine("Italic: {0}",Italic);
		}

		partial void shadowChecked (Foundation.NSObject sender)
		{
			LetterShadow = !LetterShadow;
			NeedsDisplay = true;
			Console.WriteLine("Italic: {0}",Italic);
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
		void PrepareAttributes()
		{
			mAttributes = new NSMutableDictionary();
			NSFontManager fontManager = NSFontManager.SharedFontManager;
			NSFont font = NSFont.UserFontOfSize(75.0f);
			if (Bold) {
				font = fontManager.ConvertFont(font, NSFontTraitMask.Bold);
			}
			if (Italic) {
				font = fontManager.ConvertFont(font, NSFontTraitMask.Italic);
			}
			mAttributes.Add(NSAttributedString.FontAttributeName, font);
			mAttributes.Add(NSAttributedString.ForegroundColorAttributeName, NSColor.Red);
		}

		void DrawStringCenteredInRectangle(string str, CGRect rect)
		{
			NSString drawLetter = new NSString(str);
			CGSize strSize = drawLetter.StringSize(mAttributes);
			CGPoint strOrigin = new CGPoint();
			strOrigin.X = rect.Location.X + (rect.Size.Width - strSize.Width)/2;
			strOrigin.Y = rect.Location.Y + (rect.Size.Height - strSize.Height)/2;
			if (LetterShadow) {
				NSShadow shadow = new NSShadow();
				shadow.ShadowBlurRadius = 8.0f;
				shadow.ShadowOffset = new CGSize(5.0f, 5.0f);
				shadow.ShadowColor = NSColor.Black;
				shadow.Set();
			}
			drawLetter.DrawString(strOrigin, mAttributes);
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
