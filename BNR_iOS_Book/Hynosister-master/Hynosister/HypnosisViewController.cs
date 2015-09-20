using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Hynosister
{
	public partial class HypnosisViewController : UIViewController
	{
		public HypnosisViewController() : base("HypnosisViewController", null)
		{
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
		}

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}
	}
}

