using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Departments
{
    public partial class DepartmentViewController : AppKit.NSViewController
    {
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
				case "EmployeesTableView":
					return DataStore.Employees.Count;

				case "DepartmentsTableView":
					return DataStore.Departments.Count;

				case "DepartmentEmployeesTableView":
					return 1;

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
					return dep.ValueForKey(new NSString(identifier));

				case "DepartmentEmployeesTableView":
					return new NSString("Not implemented yet");

				default:
					return new NSString("No Table View");
			}
		}
		#endregion
    }
}
