using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

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

		partial void SelectDepartment (NSPopUpButton sender)
		{
			Console.WriteLine("Select Department Changed: {0}", sender.IndexOfSelectedItem);
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

				case "DepartmentsTableView":
					return DataStore.Departments.Count;

				case "DepartmentEmployeesTableView":
					return 0;

				default:
					return 0;
			}
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			// What is the identifier for the column?
			string identifier = tableColumn.Identifier;

			Employee emp = DataStore.Employees[row];
			return emp.ValueForKey(new NSString(identifier));

		}
		#endregion
    }
}
