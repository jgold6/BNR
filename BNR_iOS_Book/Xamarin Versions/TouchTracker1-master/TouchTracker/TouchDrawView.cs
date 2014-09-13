using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;

namespace TouchTracker
{
	public class TouchDrawView : UIView
	{
		Dictionary<string, Line> linesInProcess;
		Dictionary<string, Circle> circlesInProcess;

		public TouchDrawView(RectangleF rect) : base(rect)
		{
			linesInProcess = new Dictionary<string, Line>();
			circlesInProcess = new Dictionary<string, Circle>();
			this.BackgroundColor = UIColor.White;
			this.MultipleTouchEnabled = true;
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			if (evt.TouchesForView(this).Count == 2 && linesInProcess.Count < 1) {
				bool firstTouch = true;
				Circle newCircle = new Circle();
				string key = "";
				foreach (UITouch t in touches) {
					// Is this a double tap?
					if (t.TapCount > 1) {
						this.clearAll();
						return;
					}

					// Create a circle for the value
					PointF loc = t.LocationInView(this);

					if (firstTouch) {
						// Use the touch object (packed in an string, as the key)
						key = NSValue.ValueFromNonretainedObject(t).ToString();
						newCircle.center = loc;
						firstTouch = false;
					} else {
						newCircle.point2 = loc;
					}
				}
				newCircle.setColor();
				circlesInProcess.Add(key, newCircle);
			} else {
				foreach (UITouch t in touches) {
					// Is this a double tap?
					if (t.TapCount > 1) {
						this.clearAll();
						return;
					}
					// Use the touch object (packed in an string, as the key)
					string key = NSValue.ValueFromNonretainedObject(t).ToString();

					// Create a line for the value
					PointF loc = t.LocationInView(this);
					Line newLine = new Line();
					newLine.begin = loc;
					newLine.end = loc;

					// Put pair in dictionary
					newLine.setColor();
					linesInProcess.Add(key, newLine);
				}
			}
			this.SetNeedsDisplay();
		}

		public override void TouchesMoved(NSSet touches, UIEvent evt)
		{
			if (evt.TouchesForView(this).Count == 2 && linesInProcess.Count < 1) {
				bool firstTouch = true;
				Circle circle = null;
				string key;
				foreach (UITouch t in touches) {
					PointF loc = t.LocationInView(this);
					if (firstTouch) {
						key = NSValue.ValueFromNonretainedObject(t).ToString();
						// Find the circle for this touch
						bool gotCircle = circlesInProcess.TryGetValue(key, out circle);
						// Update the Circle center
						if (gotCircle)
							circle.center = loc;
						firstTouch = false;
					} else {
						// Update the circle outside
						if (circle != null) {
							circle.point2 = loc;
							circle.setColor();
						}
					}
				}
			} else {
				foreach (UITouch t in touches) {
					string key = NSValue.ValueFromNonretainedObject(t).ToString();

					// Find the line for this touch
					Line line;
					bool gotLine = linesInProcess.TryGetValue(key, out line);

					// Update the line
					PointF loc = t.LocationInView(this);
					if (gotLine) {
						line.end = loc;
						line.setColor();
						Console.WriteLine("beginx = {0}, beginy = {1}, endx = {2}, endy = {3}", line.begin.X, line.begin.Y, line.end.X, line.end.Y);
					}
				}
			}
			this.SetNeedsDisplay();
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			this.endTouches(touches, evt);
		}

		public override void TouchesCancelled(NSSet touches, UIEvent evt)
		{
			this.endTouches(touches, evt);
		}

		public void endTouches(NSSet touches, UIEvent evt)
		{
			if (linesInProcess.Count < 1) {
				bool firstTouch = true;
				Circle circle = null;
				string key = "";
				// Remove ending touches from Dictionary
				foreach (UITouch t in touches) {
					if (firstTouch) {
						key = NSValue.ValueFromNonretainedObject(t).ToString();
						// Find the circle for this touch
						circlesInProcess.TryGetValue(key, out circle);
						firstTouch = false;
					}
				}
				// If this is a double tap, "line" will be nil
				// so make sure not to add it to the array
				if (circle != null) {
					LineStore.addCompletedCircle(circle);
					circlesInProcess.Remove(key);
				}
			} else {
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
			}
			this.SetNeedsDisplay();
		}

		public override void Draw(RectangleF rect)
		{
			CGContext context = UIGraphics.GetCurrentContext();
			context.SetLineWidth(10.0f);
			context.SetLineCap(CGLineCap.Round);

			foreach (Line line in LineStore.completeLines) {
				line.draw(context);
			}

			foreach (Circle circle in LineStore.completeCircles) {
				circle.draw(context);
			}

			foreach (KeyValuePair<string, Line> entry in linesInProcess) {
				entry.Value.draw(context);
			}

			foreach (KeyValuePair<string, Circle> entry in circlesInProcess) {
				entry.Value.draw(context);
			}
		}

		public void clearAll()
		{
			linesInProcess.Clear();
			circlesInProcess.Clear();

			LineStore.clearShapes();

			this.SetNeedsDisplay();
		}
	}
}







































