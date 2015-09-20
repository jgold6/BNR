using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreGraphics;
using ObjCRuntime;

namespace TouchTracker
{
	public class TouchDrawView : UIView
	{
		Dictionary<string, Line> linesInProcess;
		Line selectedLine {get; set;}
		UIPanGestureRecognizer moveRecognizer;
		UIColor selectedColor;

		public override bool CanBecomeFirstResponder { get { return true;}}

		public TouchDrawView(CGRect rect) : base(rect)
		{
			linesInProcess = new Dictionary<string, Line>();
			this.BackgroundColor = UIColor.White;
			this.MultipleTouchEnabled = true;

			UITapGestureRecognizer tapRecognizer = new UITapGestureRecognizer(tap); 
			this.AddGestureRecognizer(tapRecognizer);

			UITapGestureRecognizer dbltapRecognizer = new UITapGestureRecognizer(dblTap);
			dbltapRecognizer.NumberOfTapsRequired = 2;
			this.AddGestureRecognizer(dbltapRecognizer);

			UILongPressGestureRecognizer pressRecognizer = new UILongPressGestureRecognizer(longPress);
			this.AddGestureRecognizer(pressRecognizer);

			moveRecognizer = new UIPanGestureRecognizer(moveLine);
			moveRecognizer.WeakDelegate = this;
			moveRecognizer.CancelsTouchesInView = false;
			this.AddGestureRecognizer(moveRecognizer);

			UISwipeGestureRecognizer swipeRecognizer = new UISwipeGestureRecognizer(swipe);
			swipeRecognizer.Direction = UISwipeGestureRecognizerDirection.Up;
			swipeRecognizer.NumberOfTouchesRequired = 3;
			this.AddGestureRecognizer(swipeRecognizer);

			selectedColor = UIColor.Red;
		}

		[Export ("gestureRecognizer:shouldRecognizeSimultaneouslyWithGestureRecognizer:")]
		public bool GestureRecognizerShouldBegin(UIGestureRecognizer gr1, UIGestureRecognizer gr2)
		{
			if (gr1 == moveRecognizer)
				return true;
			return false;
		}

		void tap(UITapGestureRecognizer gr)
		{
			CGPoint point = gr.LocationInView(this);
			this.selectedLine = lineAtPoint(point);

			// If we just tapped, remove all lines in process
			// so that a tap does not result in a new line
			linesInProcess.Clear();

			if (selectedLine != null) {
				this.BecomeFirstResponder();

				// Grab the menu controller
				UIMenuController menu = UIMenuController.SharedMenuController;

				// Create a new "Delete" UIMenuItem
				UIMenuItem deleteItem = new UIMenuItem("Delete", new Selector("deleteLine:"));
				menu.MenuItems = new UIMenuItem[] {deleteItem};

				// Tell the menu item where it should come from and show it
				menu.SetTargetRect(new CGRect(point.X, point.Y, 2, 2), this);
				menu.SetMenuVisible(true, true);

				UIGestureRecognizer[] grs = this.GestureRecognizers;
				foreach (UIGestureRecognizer gestRec in grs) {
					if (gestRec.GetType() != new UITapGestureRecognizer().GetType()) {
						gestRec.Enabled = false;
					}
				}
			} else {
				// Hide the menu if no line is selected
				UIMenuController menu = UIMenuController.SharedMenuController;
				menu.SetMenuVisible(false, true);

				UIGestureRecognizer[] grs = this.GestureRecognizers;
				foreach (UIGestureRecognizer gestRec in grs) {
					if (gestRec.GetType() != new UITapGestureRecognizer().GetType()) {
						gestRec.Enabled = true;
					}
				}
			}
			this.SetNeedsDisplay();
		}

		void dblTap(UITapGestureRecognizer gr)
		{
			clearAll();
			// Hide the menu
			UIMenuController.SharedMenuController.SetMenuVisible(false, true);
		}

		void longPress(UILongPressGestureRecognizer gr)
		{
			if (gr.State == UIGestureRecognizerState.Began) {
				CGPoint point = gr.LocationInView(this);
				selectedLine = lineAtPoint(point);

				if (selectedLine != null) {
					linesInProcess.Clear();
				}
			} else if (gr.State == UIGestureRecognizerState.Ended) {
				selectedLine = null;
			}
			this.SetNeedsDisplay();
		}

		void moveLine(UIPanGestureRecognizer gr)
		{
			// if no line selected, do nothing
			if (selectedLine == null)
				return;

			// When the pan gesture recognizer changes its position...
			if (gr.State == UIGestureRecognizerState.Changed) {
				// How far has the pan moved?
				CGPoint translation = gr.TranslationInView(this);

				// Add the translation to the current begin and end points of the line
				CGPoint begin = selectedLine.begin;
				CGPoint end = selectedLine.end;
				begin.X += translation.X;
				begin.Y += translation.Y;
				end.X += translation.X;
				end.Y += translation.Y;

				// Set the new beginning and end points of the line
				selectedLine.begin = begin;
				selectedLine.end = end;

				LineStore.updateCompletedLine(selectedLine);

				this.SetNeedsDisplay();

				gr.SetTranslation(new CGPoint(0,0),this);
			} else if (gr.State == UIGestureRecognizerState.Ended) {
				selectedLine = null;
			}
		}

		void swipe(UISwipeGestureRecognizer gr)
		{
			linesInProcess.Clear();
			this.BecomeFirstResponder();
			// Grab the menu controller
			UIMenuController menu = UIMenuController.SharedMenuController;

			// Create buttons
			UIMenuItem red = new UIMenuItem("Red", new Selector("red:"));
			UIMenuItem green = new UIMenuItem("Green", new Selector("green:"));
			UIMenuItem blue = new UIMenuItem("Blue", new Selector("blue:"));

			menu.MenuItems = new UIMenuItem[]{red, green, blue};

			// Tell the menu where it should come from and show it
			menu.SetTargetRect(new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height), this);
			menu.SetMenuVisible(true, true);
		}

		[Export ("red:")]
		public void red(IntPtr sender)
		{
			selectedColor = UIColor.Red;
		}

		[Export ("green:")]
		public void green(IntPtr sender)
		{
			selectedColor = UIColor.Green;
		}

		[Export ("blue:")]
		public void blue(IntPtr sender)
		{
			selectedColor = UIColor.Blue;
		}

		public Line lineAtPoint(CGPoint p)
		{
			// Find line close to p
			foreach (Line l in LineStore.completeLines) {
				CGPoint start = l.begin;
				CGPoint end = l.end;

				// Check a few points on the line
				for (float t = 0.0f; t <= 1.0f; t += 0.05f) {
					nfloat x = start.X + t * (end.X - start.X);
					nfloat y = start.Y + t * (end.Y - start.Y);

					// If the tapped point is within 20 points, let's return this line
					if (Math.Sqrt(Math.Pow(x - p.X, 2) + Math.Pow(y - p.Y, 2)) < 20.0f) {
						return l;
					}
				}
			}
			// If nothing is close enough, no line selected, return null
			return null;
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			foreach (UITouch t in touches) {
//				// Is this a double tap?
//				if (t.TapCount > 1) {
//					this.clearAll();
//					return;
//				}
				// Use the touch object (packed in an string, as the key)
				string key = NSValue.ValueFromNonretainedObject(t).ToString();

				// Create a line for the value
				CGPoint loc = t.LocationInView(this);
				Line newLine = new Line();
				newLine.begin = loc;
				newLine.end = loc;

				// Put pair in dictionary
				//newLine.setColor();
				newLine.setColor(selectedColor);
				newLine.lineWidth = 30.0f;
				newLine.fastest = 0.0f;
				linesInProcess.Add(key, newLine);
			}
			this.SetNeedsDisplay();
		}

		public override void TouchesMoved(NSSet touches, UIEvent evt)
		{
			foreach (UITouch t in touches) {
				string key = NSValue.ValueFromNonretainedObject(t).ToString();

				// Find the line for this touch
				Line line;
				bool gotLine = linesInProcess.TryGetValue(key, out line);

				// Update the line
				CGPoint loc = t.LocationInView(this);
				if (gotLine) {
					// but before we do, see how much distance has changed since last update
					// and use to set the line width

					// Using velocity from moverecognizer
//					PointF drawVelocity = moveRecognizer.VelocityInView(this);
//					drawVelocity.X = Math.Abs(drawVelocity.X);
//					drawVelocity.Y = Math.Abs(drawVelocity.Y);
//			        
//					float drawSpeed = (float)Math.Sqrt(Math.Pow(drawVelocity.X, 2) + Math.Pow(drawVelocity.Y, 2)); 
//			        if (drawSpeed > line.fastest) {
//			            line.fastest = (drawSpeed + line.fastest)/2;
//			        }
//			        
//					line.lineWidth = Math.Min(1200/line.fastest, 30); 

					// Using the difference betseen the length of the line as an indicator of velocity - I like this better
					float oldLength = (float)Math.Sqrt(Math.Pow(line.beginx - line.endx, 2) + Math.Pow(line.beginy - line.endy, 2));
					float newLength = (float)Math.Sqrt(Math.Pow(line.beginx - loc.X, 2) + Math.Pow(line.beginy - loc.Y, 2));

					if (Math.Abs(newLength - oldLength) > line.fastest) {
						line.fastest = (Math.Abs(newLength - oldLength) + line.fastest)/2;
					}
					line.lineWidth = Math.Min(30/line.fastest, 20);
					// OK back to our regularly scheduled programming
					line.end = loc;
					//line.setColor(); // Set color based on the angle of the line
					//Console.WriteLine("beginx = {0}, beginy = {1}, endx = {2}, endy = {3}", line.begin.X, line.begin.Y, line.end.X, line.end.Y);
				}
			}
			this.SetNeedsDisplay();
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			this.endTouches(touches);
		}

		public override void TouchesCancelled(NSSet touches, UIEvent evt)
		{
			this.endTouches(touches);
		}

		public void endTouches(NSSet touches)
		{
			// Remove ending touches from Dictionary
			foreach (UITouch t in touches) {
				string key = NSValue.ValueFromNonretainedObject(t).ToString();

				// Find the line for this touch
				Line line = new Line();
				linesInProcess.TryGetValue(key, out line);

				// If this is a double tap, "line" will be nil
				// so make sure not to add it to the array
				if (line != null) {
					LineStore.addCompletedLine(line);
					linesInProcess.Remove(key);
				}
			}
			this.SetNeedsDisplay();
		}

		public override void Draw(CGRect rect)
		{
			CGContext context = UIGraphics.GetCurrentContext();
			context.SetLineWidth(10.0f);
			context.SetLineCap(CGLineCap.Round);

			foreach (Line line in LineStore.completeLines) {
				line.draw(context);
			}

			foreach (KeyValuePair<string, Line> entry in linesInProcess) {
				entry.Value.draw(context);
			}

			if (selectedLine != null) {
				selectedLine.drawWithColor(context, UIColor.Gray);
			}
		}

		[Export ("deleteLine:")]
		public void deleteLine(IntPtr sender)
		{
			LineStore.removeCompletedLine(selectedLine);
			selectedLine = null;
			UIGestureRecognizer[] grs = this.GestureRecognizers;
			foreach (UIGestureRecognizer gestRec in grs) {
				if (gestRec.GetType() != new UITapGestureRecognizer().GetType()) {
					gestRec.Enabled = true;
				}
			}
			this.SetNeedsDisplay();
		}

		public void clearAll()
		{
			linesInProcess.Clear();
			LineStore.clearLines();

			this.SetNeedsDisplay();
		}
	}
}







































