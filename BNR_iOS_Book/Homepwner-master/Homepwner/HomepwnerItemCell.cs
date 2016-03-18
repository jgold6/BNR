using System;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Reflection;
using ObjCRuntime;
using System.Threading.Tasks;

namespace Homepwner
{
	public delegate void ShowImageCallback (NSObject sender, HomepwnerItemCell cell);
	public delegate void NudgeValueCallback (HomepwnerItemCell cell, double stepperValue);

	public delegate void TestIndexPathCallback (NSIndexPath indexPath);

	public partial class HomepwnerItemCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName("HomepwnerItemCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString("HomepwnerItemCell");

		public ShowImageCallback showImageCallback {get; set;}
		public NudgeValueCallback nudgeValueCallback {get; set;}

		public TestIndexPathCallback testIndexPathCallback {get; set;}

		public HomepwnerItemCell(IntPtr handle) : base(handle)
		{
		}

		public static HomepwnerItemCell Create()
		{
			return (HomepwnerItemCell)Nib.Instantiate(null, null)[0];
		}

		partial void ShowImage(NSObject sender)
		{
			showImageCallback(sender, this);
		}

		partial void NudgeValue (Foundation.NSObject sender)
		{
			UIStepper stepper = (UIStepper)sender;
			nudgeValueCallback(this, stepper.Value);
		}

		public void DoCallback(NSIndexPath indexPath)
		{
			var delay = Task.Delay (2000).ContinueWith (a => {
				testIndexPathCallback (indexPath);
			});

		}
	}
}

