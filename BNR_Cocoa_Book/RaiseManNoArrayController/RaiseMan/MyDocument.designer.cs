// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace RaiseMan
{
	[Register ("MyDocument")]
	partial class MyDocument
	{
		[Outlet]
		public AppKit.NSTableView tableView { get; set; }

		[Action ("btnCheckEntries:")]
		partial void btnCheckEntries (Foundation.NSObject sender);

		[Action ("createEmployee:")]
		partial void createEmployee (Foundation.NSObject sender);

		[Action ("deleteSelectedEmployees:")]
		partial void deleteSelectedEmployees (Foundation.NSObject sender);

		[Action ("removeEmployee:")]
		partial void removeEmployee (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}
		}
	}
}
