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
		#region- Member variables / Properties
		bool IsViewReady = false;

		//strongly typed view accessor
		public new EmployeeView View
		{
			get
			{
				return (EmployeeView)base.View;
			}
		}
		#endregion

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

		#region - LifeCycle
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			EmployeesTableView.WeakDelegate = this;
			EmployeesTableView.WeakDataSource = this;
		}

		public override void ViewWillAppear()
		{
			base.ViewWillAppear();
			IsViewReady = true;
			EmployeesTableView.ReloadData();
		}

		public override void ViewDidDisappear()
		{
			base.ViewDidDisappear();
			IsViewReady = false;
		}
		#endregion

		#region - Actions
		[Action ("add:")]
		void AddClicked (NSButton sender) 
		{
			Console.WriteLine("EVC Add clicked");
			Employee emp = new Employee();
			DataStore.AddItem<Employee>(emp);
			emp.SetFirstName("New");
			emp.SetLastName("Employee");
			EmployeesTableView.ReloadData();

			// Start editing new item
			int row = DataStore.Employees.IndexOf(emp);
			EmployeesTableView.SelectRow(row, false);
			EmployeesTableView.EditColumn(0, row, null, true);
		}

		[Action ("remove:")]
		void RemoveClicked (NSButton sender) 
		{
			Console.WriteLine("EVC Remove clicked");
			if (!StopEditing() || EmployeesTableView.SelectedRow <0) {
				AppKitFramework.NSBeep();
				return;
			}

			Employee emp = DataStore.Employees[(int)EmployeesTableView.SelectedRow];

			foreach(Department dep in DataStore.Departments) {
				if (dep.Manager == emp.ID) {
					dep.ManagerName = "";
				}					
			}

			DataStore.RemoveItem(emp);
			EmployeesTableView.DeselectAll(this);
			EmployeesTableView.ReloadData();
		}
		#endregion

		#region - Weak Delegate and DataSource methods
		[Export("numberOfRowsInTableView:")]
		public int GetRowCount(NSTableView tableView)
		{
			if (IsViewReady == true) {
				switch (tableView.Identifier)
				{
					case "EmployeesTableView":
						return DataStore.Employees.Count;

					default:
						return 0;
				}
			}
			else 
				return 0;
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			if (IsViewReady) {
				Employee emp = DataStore.Employees[(int)row];
				switch (tableColumn.Identifier) 
				{
					case "FirstName":
						return new NSString(emp.FirstName);

					case "LastName":
						return new NSString(emp.LastName);

					case "DepartmentName":
						NSPopUpButtonCell button = tableColumn.DataCellForRow(row) as NSPopUpButtonCell;
						button.RemoveAllItems();
						foreach(Department dep in DataStore.Departments) {
							button.Menu.AddItem(dep.Name, new ObjCRuntime.Selector("departmentSelected:"), "");
						}
						return button;

					default:
						return new NSString("");
				}
			}
			else return new NSString("");
		}

		[Export("tableView:setObjectValue:forTableColumn:row:")]
		public void SetObjectValue(NSTableView tableView, NSObject theObject, NSTableColumn tableColumn, int row)
		{
			// Get Employee
			Employee emp = DataStore.Employees[row];

			// Set the value
			switch (tableColumn.Identifier)
			{
				case "FirstName":
					emp.SetFirstName((theObject as NSString).ToString());
					break;

				case "LastName":
					emp.SetLastName((theObject as NSString).ToString());
					break;

				default:
					break;
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

			// If Employee was manager of the old department, remove them as manager of the old deparment.
			if (emp.DepartmentName != "")  {
				Department dep = DataStore.Departments.Find(x => x.Name == emp.DepartmentName);
				if (dep.ManagerName == emp.FullName) {
					dep.ManagerName = "";
				}
			}

			emp.DepartmentName = sender.Title;
		}
		#endregion

		#region - Helpers
		public bool StopEditing()
		{
			NSWindow w = EmployeesTableView.Window;
			// try to end any editing that is taking place
			bool editingEnded = w.MakeFirstResponder(w);
			if (!editingEnded) {
				Console.WriteLine("Unable to end editing");
			}
			return editingEnded;
		}
		#endregion
    }
}
