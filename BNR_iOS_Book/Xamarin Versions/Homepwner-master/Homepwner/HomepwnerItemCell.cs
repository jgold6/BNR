using System;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Reflection;
using ObjCRuntime;

namespace Homepwner
{
	public delegate void ShowImageCallback (NSObject sender, HomepwnerItemCell cell);
	public delegate void NudgeValueCallback (HomepwnerItemCell cell, double stepperValue);

	public partial class HomepwnerItemCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName("HomepwnerItemCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString("HomepwnerItemCell");

		public ShowImageCallback showImageCallback {get; set;}
		public NudgeValueCallback nudgeValueCallback {get; set;}

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
	}
}

