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
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIButton assetTypeBtn { get; set; }

		[Outlet]
		UIKit.UITextField dateField { get; set; }

		[Outlet]
		UIKit.UIImageView imageView { get; set; }

		[Outlet]
		UIKit.UITextField nameField { get; set; }

		[Outlet]
		UIKit.UITextField serialNumberField { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem takePicture { get; set; }

		[Outlet]
		UIKit.UITextField valueField { get; set; }

		[Action ("assetTypeTapped:")]
		partial void assetTypeTapped (Foundation.NSObject sender);

		[Action ("backgroundTapped:")]
		partial void backgroundTapped (Foundation.NSObject sender);

		[Action ("deletePicture:")]
		partial void deletePicture (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (assetTypeBtn != null) {
				assetTypeBtn.Dispose ();
				assetTypeBtn = null;
			}

			if (dateField != null) {
				dateField.Dispose ();
				dateField = null;
			}

			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (nameField != null) {
				nameField.Dispose ();
				nameField = null;
			}

			if (serialNumberField != null) {
				serialNumberField.Dispose ();
				serialNumberField = null;
			}

			if (takePicture != null) {
				takePicture.Dispose ();
				takePicture = null;
			}

			if (valueField != null) {
				valueField.Dispose ();
				valueField = null;
			}
		}
	}
}
