using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using System.Diagnostics;

namespace HypnoTime
{
	public partial class TimeViewController : UIViewController
	{
		public TimeViewController() : base("TimeViewController", null)
		{
			UITabBarItem tbi = this.TabBarItem;
			tbi.Title = "Time";

			UIImage i = UIImage.FromFile("Time.png");
			tbi.Image = i;
		}

		public override void DidReceiveMemoryWarning()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			btnShowTime.TouchUpInside += (sender, e) => {
				setCurrentTime();
			};
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			setCurrentTime();
		}

		public override void ViewDidAppear(bool animated)
		{
			SlideButtonIn();
		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
			btnShowTime.Layer.Opacity = 1.0f;
		}

		public void setCurrentTime()
		{
			NSDate now = DateTime.Now;
			NSDateFormatter dateFormat = new NSDateFormatter();
			dateFormat.TimeStyle = NSDateFormatterStyle.Medium;

			lblTime.Text = dateFormat.StringFor(now);

			//SpinTimeLabel();
			BounceTimeLabel();
		}

		public void SpinTimeLabel()
		{
			// Create a basic animation
			CABasicAnimation spin = CABasicAnimation.FromKeyPath("transform.rotation");

			spin.AnimationStopped += AnimationStopped;

			// from value is implied
			spin.To = NSNumber.FromDouble(Math.PI * 2);
			spin.Duration = 0.6;

			//Set the timing function
			CAMediaTimingFunction tf = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			spin.TimingFunction = tf;

			// Kick off the animation by adding it to the layer
			lblTime.Layer.AddAnimation(spin, "spinAnimation");
		}

		public void BounceTimeLabel()
		{
			// Create a key frame animation
			CAKeyFrameAnimation bounce = CAKeyFrameAnimation.GetFromKeyPath("transform");
			CAKeyFrameAnimation fade = CAKeyFrameAnimation.GetFromKeyPath("opacity");

			bounce.AnimationStopped += AnimationStopped;
			fade.AnimationStopped += AnimationStopped;

			// Create the values it will pass through
			CATransform3D forward = CATransform3D.MakeScale(1.3f, 1.3f, 1.0f);
			CATransform3D back = CATransform3D.MakeScale(0.7f, 0.7f, 1.0f);
			CATransform3D forward2 = CATransform3D.MakeScale(1.2f, 1.2f, 1.0f);
			CATransform3D back2 = CATransform3D.MakeScale(0.9f, 0.9f, 1.0f);

			NSNumber opacity0 = NSNumber.FromFloat(0.0f);
			NSNumber opacity1 = NSNumber.FromFloat(1.0f);

			bounce.Values = new NSObject[] {
				NSValue.FromCATransform3D(CATransform3D.Identity), 
				NSValue.FromCATransform3D(forward), 
				NSValue.FromCATransform3D(back), 
				NSValue.FromCATransform3D(forward2), 
				NSValue.FromCATransform3D(back2), 
				NSValue.FromCATransform3D(CATransform3D.Identity)};

			fade.Values = new NSObject[] {
				NSNumber.FromFloat(lblTime.Layer.Opacity), 
				opacity1, 
				opacity0, 
				opacity1, 
				opacity0, 
				NSNumber.FromFloat(lblTime.Layer.Opacity)};

			// Set the duration
			bounce.Duration = 5.0f;
			fade.Duration = 5.0f;

			// Animate the layer
			lblTime.Layer.AddAnimation(bounce, "bounceAnimation");
			lblTime.Layer.AddAnimation(fade, "fadeAnimation");
		}

		public void SlideButtonIn()
		{
			CABasicAnimation slide = CABasicAnimation.FromKeyPath("position");

			slide.From = NSValue.FromCGPoint(new PointF(-100.0f, btnShowTime.Layer.Position.Y));
			slide.To = NSValue.FromCGPoint(btnShowTime.Layer.Position);
			slide.Duration = 1.0f;

			//Set the timing function
			CAMediaTimingFunction tf = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			slide.TimingFunction = tf;
			slide.AnimationStopped += FadeRepeat;

			// Kick off the animation by adding it to the layer
			btnShowTime.Layer.AddAnimation(slide, "slideAnimation");

		}

		public void AnimationStopped(object sender, CAAnimationStateEventArgs e)
		{
			Console.WriteLine("{0} finished {1}", sender, e.Finished);
		}

		public void FadeRepeat(object sender, CAAnimationStateEventArgs e)
		{
			//btnShowTime.Layer.RemoveAnimation("fadeInOUt");
			CAKeyFrameAnimation fade = CAKeyFrameAnimation.GetFromKeyPath("opacity");

			NSNumber opacity0 = NSNumber.FromFloat(0.0f);
			NSNumber opacity1 = NSNumber.FromFloat(1.0f);
			fade.Values = new NSObject[] {
				opacity1,
				opacity0,
				opacity1,
			};

			fade.Duration = 1.0f;
			fade.RepeatDuration= 1000.0;

			btnShowTime.Layer.AddAnimation(fade, "fadeInOut");
		}
	}
}



























