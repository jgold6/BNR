using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Departments
{
    public partial class DepartmentViewController : AppKit.NSViewController
    {
		Department currentSelectedDepartment;
		bool IsViewReady = false;
        #region Constructors

        // Called when created from unmanaged code
        public DepartmentViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public DepartmentViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public DepartmentViewController() : base("DepartmentView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			Title = "Departments";
        }

        #endregion

        //strongly typed view accessor
        public new DepartmentView View
        {
            get
            {
                return (DepartmentView)base.View;
            }
        }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			DepartmentEmployeesTableView.WeakDelegate = this;
			DepartmentEmployeesTableView.WeakDataSource = this;

			DepartmentsTableView.WeakDelegate = this;
			DepartmentsTableView.WeakDataSource = this;

		}

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();
			IsViewReady = true;
			if (currentSelectedDepartment != null) {
				Console.WriteLine("Current Selected Department: {0}", currentSelectedDepartment.Name);
				SelectManagerButton.SelectItem(currentSelectedDepartment.ManagerName);
			}
			DepartmentsTableView.ReloadData();
			DepartmentEmployeesTableView.ReloadData();
		}

		public override void ViewDidDisappear()
		{
			base.ViewDidDisappear();
			IsViewReady = false;
		}

		partial void SelectManager (NSPopUpButton sender)
		{
			Console.WriteLine("Select Manager Changed: {0}", sender.IndexOfSelectedItem);
		}

		[Action ("add:")]
		void AddClicked (NSButton sender) 
		{
			Console.WriteLine("DVC Add clicked");
		}

		[Action ("remove:")]
		void RemoveClicked (NSButton sender) 
		{
			Console.WriteLine("DVC Remove clicked");
		}

		#region - Weak Delegate and DataSource methods
		[Export("numberOfRowsInTableView:")]
		public int GetRowCount(NSTableView tableView)
		{
			switch (tableView.Identifier)
			{
				case "DepartmentsTableView":
					return DataStore.Departments.Count;

				case "DepartmentEmployeesTableView":
					if (currentSelectedDepartment != null && IsViewReady) {
						return currentSelectedDepartment.Employees.Count;
					}
					else return 0;
				default:
					return 0;
			}
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			// What is the identifier for the column?
			string identifier = tableColumn.Identifier;

			switch (tableView.Identifier)
			{
				case "DepartmentsTableView":
					Department dep = DataStore.Departments[row];
					return new NSString(dep.Name);

				case "DepartmentEmployeesTableView":
					if (IsViewReady)
						return new NSString(currentSelectedDepartment.Employees[row].FullName);
					else 
						return new NSString("");

				default:
					return new NSString("No Table View");
			}
		}

		[Export("tableViewSelectionDidChange:")]
		public void RowSelected(NSNotification notification)
		{
			NSTableView tv = notification.Object as NSTableView;

			switch (tv.Identifier)
			{
				case "DepartmentsTableView":
					if (tv.SelectedRow >= 0) {
						currentSelectedDepartment = DataStore.Departments[(int)tv.SelectedRow];
						SelectManagerButton.RemoveAllItems();
						foreach(Employee emp in currentSelectedDepartment.Employees) {
							SelectManagerButton.Menu.AddItem(emp.FullName, new ObjCRuntime.Selector("managerSelected:"), "");
						}
						SelectManagerButton.SelectItem(currentSelectedDepartment.ManagerName);
					}
					else {
						currentSelectedDepartment = null;
						SelectManagerButton.RemoveAllItems();
					}
					break;

				case "DepartmentEmployeesTableView":
					if (tv.SelectedRow >= 0)
						Console.WriteLine("Employe selected: {0}", currentSelectedDepartment.Employees[(int)tv.SelectedRow].FullName);
					break;

				default:
					break;
			}
			DepartmentEmployeesTableView.ReloadData();
		}

		[Export("managerSelected:")]
		public void ManagerSelected(NSMenuItem sender)
		{
			Console.WriteLine("Manager Selected: {0}, Index: {1}", sender.Title, sender.Menu.IndexOf(sender));
			currentSelectedDepartment.ManagerName = sender.Title;
		}
		#endregion
    }
}
