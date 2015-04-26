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
	[Register ("DepartmentViewController")]
	partial class DepartmentViewController
	{
		[Outlet]
		AppKit.NSTableView DepartmentEmployeesTableView { get; set; }

		[Outlet]
		AppKit.NSTableView DepartmentsTableView { get; set; }

		[Outlet]
		AppKit.NSPopUpButton SelectManagerButton { get; set; }

		[Action ("selectManager:")]
		partial void SelectManager (AppKit.NSPopUpButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (DepartmentEmployeesTableView != null) {
				DepartmentEmployeesTableView.Dispose ();
				DepartmentEmployeesTableView = null;
			}

			if (DepartmentsTableView != null) {
				DepartmentsTableView.Dispose ();
				DepartmentsTableView = null;
			}

			if (SelectManagerButton != null) {
				SelectManagerButton.Dispose ();
				SelectManagerButton = null;
			}
		}
	}
}
