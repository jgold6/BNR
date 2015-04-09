// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Homepwner
{
	[Register ("HomepwnerItemCell")]
	partial class HomepwnerItemCell
	{
		[Outlet]
		public UIKit.UILabel nameLabel { get; private set; }

		[Outlet]
		public UIKit.UILabel serialNumberLabel { get; private set; }

		[Outlet]
		public UIKit.UIImageView thumbnailView { get; private set; }

		[Outlet]
		public UIKit.UILabel valueLabel { get; private set; }

		[Outlet]
		public UIKit.UIStepper stepper { get; private set; }

		[Action ("showImage:")]
		partial void ShowImage (Foundation.NSObject sender);

		[Action ("nudgeValue:")]
		partial void NudgeValue (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (nameLabel != null) {
				nameLabel.Dispose ();
				nameLabel = null;
			}

			if (serialNumberLabel != null) {
				serialNumberLabel.Dispose ();
				serialNumberLabel = null;
			}

			if (thumbnailView != null) {
				thumbnailView.Dispose ();
				thumbnailView = null;
			}

			if (valueLabel != null) {
				valueLabel.Dispose ();
				valueLabel = null;
			}
		}
	}
}
