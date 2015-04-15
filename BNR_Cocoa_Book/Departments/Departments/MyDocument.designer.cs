// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Departments
{
	[Register ("MyDocument")]
	partial class MyDocument
	{
		[Outlet]
		AppKit.NSBox box { get; set; }

		[Outlet]
		AppKit.NSPopUpButton popup { get; set; }

		[Action ("changeViewController:")]
		partial void changeViewController (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (popup != null) {
				popup.Dispose ();
				popup = null;
			}

			if (box != null) {
				box.Dispose ();
				box = null;
			}
		}
	}
}
