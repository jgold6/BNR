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
	[Register ("EmployeeViewController")]
	partial class EmployeeViewController
	{
		[Outlet]
		public AppKit.NSTableView EmployeesTableView { get; private set; }

		void ReleaseDesignerOutlets ()
		{
			if (EmployeesTableView != null) {
				EmployeesTableView.Dispose ();
				EmployeesTableView = null;
			}
		}
	}
}
