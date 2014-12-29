// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;
using MonoMac.AppKit;

namespace CarLot
{
	[Register ("MyDocument")]
	partial class MyDocument
	{
		[Outlet]
		MonoMac.AppKit.NSArrayController arrayController { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTableView tableView { get; set; }

		[Action ("btnCheckEntries:")]
		partial void btnCheckEntries (MonoMac.Foundation.NSObject sender);

		[Action ("btnCreateCar:")]
		partial void btnCreateCar (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (arrayController != null) {
				arrayController.Dispose ();
				arrayController = null;
			}

			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
