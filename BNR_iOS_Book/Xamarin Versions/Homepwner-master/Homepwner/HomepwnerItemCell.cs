using System;
using CoreGraphics;
using Foundation;
using UIKit;
using System.Reflection;
using ObjCRuntime;

namespace Homepwner
{
	public partial class HomepwnerItemCell : UITableViewCell
	{
		public static readonly UINib Nib = UINib.FromName("HomepwnerItemCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString("HomepwnerItemCell");

		public ItemsViewController controller {get; set;}
		public UITableView tableView {get; set;}

		public HomepwnerItemCell(IntPtr handle) : base(handle)
		{
		}

		public static HomepwnerItemCell Create()
		{
			return (HomepwnerItemCell)Nib.Instantiate(null, null)[0];
		}

		partial void showImage(NSObject sender)
		{
			NSIndexPath indexPath = tableView.IndexPathForCell(this);

			if (indexPath != null) {
				controller.showImageAtIndexPath(sender, indexPath);
			}

		}

		partial void NudgeValue (Foundation.NSObject sender)
		{
			UIStepper stepper = (UIStepper)sender;
			NSIndexPath indexPath = tableView.IndexPathForCell(this);
			controller.nudgeItemValue(indexPath, stepper.Value);
		}
	}
}

