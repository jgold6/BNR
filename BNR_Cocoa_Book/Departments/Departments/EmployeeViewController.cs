using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using System.Threading;

namespace Departments
{
    public partial class EmployeeViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public EmployeeViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EmployeeViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EmployeeViewController() : base("EmployeeView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			Title = "Employees";
        }

        #endregion

        //strongly typed view accessor
        public new EmployeeView View
        {
            get
            {
                return (EmployeeView)base.View;
            }
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			EmployeesTableView.WeakDelegate = this;
			EmployeesTableView.WeakDataSource = this;
		}

		[Action ("add:")]
		void AddClicked (NSButton sender) 
		{
			Console.WriteLine("EVC Add clicked");
		}

		[Action ("remove:")]
		void RemoveClicked (NSButton sender) 
		{
			Console.WriteLine("EVC Remove clicked");
		}

		#region - Weak Delegate and DataSource methods
		[Export("numberOfRowsInTableView:")]
		public int GetRowCount(NSTableView tableView)
		{
			switch (tableView.Identifier)
			{
				case "EmployeesTableView":
					return DataStore.Employees.Count;

				default:
					return 0;
			}
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			Employee emp = DataStore.Employees[(int)row];
			switch (tableColumn.Identifier) 
			{
				case "FirstName":
					return new NSString(emp.FirstName);

				case "LastName":
					return new NSString(emp.LastName);

				case "DepartmentName":
					NSPopUpButtonCell button = tableColumn.DataCellForRow(row) as NSPopUpButtonCell;
					if (button.Menu.Count == 0) {
						foreach(Department dep in DataStore.Departments) {
							button.Menu.AddItem(dep.Name, new ObjCRuntime.Selector("departmentSelected:"), "");
						}
					}
					return button;

				default:
					return new NSString("");
			}
		}

		[Export("tableView:willDisplayCell:forTableColumn:row:")]
		public void WillDisplayCell(NSTableView tableView, NSObject cell, NSTableColumn tableColumn, nint row)
		{
			Employee emp = DataStore.Employees[(int)row];
			if (tableColumn.Identifier == "DepartmentName") {
				NSPopUpButtonCell button = cell as NSPopUpButtonCell;
				button.SetTitle(emp.DepartmentName);
			}
		}

		[Export("departmentSelected:")]
		public void DepartmentSelected(NSMenuItem sender)
		{
			Console.WriteLine("Department Selected: {0}, Index: {1}, Handle: {2}", sender.Title, sender.Menu.IndexOf(sender), sender.Handle);
			Employee emp = DataStore.Employees[(int)EmployeesTableView.SelectedRow];

			Department dep = DataStore.Departments.Find(x => x.Name == emp.DepartmentName);
			if (dep.ManagerName == emp.FullName) {
				dep.ManagerName = "";
			}

			emp.DepartmentName = sender.Title;
		}
		#endregion
    }
}
