using System;
using CoreGraphics;
using UIKit;
using Foundation;

namespace HypnoTime
{
	public class HypnosisViewController : UIViewController
	{
		UISegmentedControl segControl;
		nint lastSelectedSegmentIndex;
		UIColor lastSelectedColor;

		public HypnosisViewController() : base("HypnosisViewController", null)
		{
			UITabBarItem tbi = this.TabBarItem;
			tbi.Title = "Hypnosis";

			UIImage i = UIImage.FromFile("Hypno.png");
			tbi.Image = i;
		}

		public override void LoadView()
		{
			// Create a view
			CGRect frame = UIScreen.MainScreen.Bounds;
			frame.Y += 23;
			frame.Height -= 23;
			HypnosisView v = new HypnosisView(frame);

			// Set it as the view of this view controller
			this.View = v;

			// Create a segmented control
			segControl = new UISegmentedControl(new string[4]{"Grey","Red", "Green", "Blue"});
			segControl.Frame = new CGRect(0, 25, View.Bounds.Size.Width, 25);
			segControl.BackgroundColor = UIColor.White;
			segControl.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleBottomMargin);

			// Set subview tint colors
			var subViews = segControl.Subviews;
			subViews[0].TintColor = UIColor.LightGray;
			subViews[1].TintColor = UIColor.Red;
			subViews[2].TintColor = UIColor.Green;
			subViews[3].TintColor = UIColor.Blue;
			// set staring index
			segControl.SelectedSegment = 0;
			// Add it
			View.Add(segControl);



			segControl.ValueChanged += (sender, e) =>  {
				switch (segControl.SelectedSegment)
				{
					case 0:
						v.CircleColor = UIColor.LightGray;
						break;
					case 1:
						v.CircleColor = UIColor.Red;
						break;
					case 2:
						v.CircleColor = UIColor.Green;
						break;
					case 3:
						v.CircleColor = UIColor.Blue;
						break;
					default:
						break;

				}
			};



		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Console.WriteLine("Hypnosis View Loaded - frame" + View.Frame.ToString());
			Console.WriteLine("Hypnosis View Loaded - bounds" + View.Bounds.ToString());
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			View.SetNeedsDisplay();
			Console.WriteLine("Hypnosis View will Appear - frame" + View.Frame.ToString());
			Console.WriteLine("Hypnosis View will Appear - bounds" + View.Bounds.ToString());
			Console.WriteLine("TabBar - frame" + this.ParentViewController.View.Frame.ToString());
			Console.WriteLine("TabBar - bounds" + this.ParentViewController.View.Bounds.ToString());

		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			View.SetNeedsDisplay();
			Console.WriteLine("Hypnosis View did Appear - frame" + View.Frame.ToString());
			Console.WriteLine("Hypnosis View did Appear - bounds" + View.Bounds.ToString());
			Console.WriteLine("TabBar - frame" + this.ParentViewController.View.Frame.ToString());
			Console.WriteLine("TabBar - bounds" + this.ParentViewController.View.Bounds.ToString());
		}

		public override void DidRotate(UIInterfaceOrientation orientation)
		{
			base.DidRotate(orientation);
			View.SetNeedsDisplay();
			Console.WriteLine("Hypnosis View did rotate - frame" + View.Frame.ToString());
			Console.WriteLine("Hypnosis View did rotate - bounds" + View.Frame.ToString());
		}

		public override bool CanBecomeFirstResponder{ get {return true;}}

		public override void MotionBegan(UIEventSubtype motion, UIEvent evt)
		{
			HypnosisView view = this.View as HypnosisView;
			if (motion == UIEventSubtype.MotionShake) {
				Console.WriteLine("Device started shaking");
				if (view.CircleColor != UIColor.Orange) {
					lastSelectedColor = view.CircleColor;
					lastSelectedSegmentIndex = segControl.SelectedSegment;
					view.CircleColor = UIColor.Orange;
					segControl.SelectedSegment = -1;
				}
				else {
					view.CircleColor = lastSelectedColor;
					segControl.SelectedSegment = lastSelectedSegmentIndex;
				}
			}
		}
	}
}

