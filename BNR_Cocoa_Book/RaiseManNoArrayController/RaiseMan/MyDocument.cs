
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace RaiseMan
{
    public partial class MyDocument : MonoMac.AppKit.NSDocument
    {
		EmployeeTableSource _employeeTableSource;

        // Called when created from unmanaged code
        public MyDocument(IntPtr handle) : base(handle)
        {
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MyDocument(NSCoder coder) : base(coder)
        {
        }

        public override void WindowControllerDidLoadNib(NSWindowController windowController)
        {
            base.WindowControllerDidLoadNib(windowController);
            
            // Add code to here after the controller has loaded the document window
			_employeeTableSource = new EmployeeTableSource();

			// Using List
			_employeeTableSource.Employees = new List<Person>();
			// Using NSMutableArray
//			_employeeTableSource.Employees = new NSMutableArray();

			tableView.Source = _employeeTableSource;
        }
        
        //
        // Save support:
        //    Override one of GetAsData, GetAsFileWrapper, or WriteToUrl.
        //
        
        // This method should store the contents of the document using the given typeName
        // on the return NSData value.
        public override NSData GetAsData(string documentType, out NSError outError)
        {
            outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
            return null;
        }
        
        //
        // Load support:
        //    Override one of ReadFromData, ReadFromFileWrapper or ReadFromUrl
        //
        public override bool ReadFromData(NSData data, string typeName, out NSError outError)
        {
            outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
            return false;
        }

        // If this returns the name of a NIB file instead of null, a NSDocumentController
        // is automatically created for you.
        public override string WindowNibName
        { 
            get
            {
                return "MyDocument";
            }
        }

		partial void btnCheckEntries (MonoMac.Foundation.NSObject sender)
		{
			for (int i = 0; i < _employeeTableSource.Employees.Count; i++) {
				// Using List
				Person employee = _employeeTableSource.Employees[i];
				// using NSMutableArray
//				Person employee = _employeeTableSource.Employees.GetItem<Person>(i);
				Console.WriteLine("Person Name: {0}, Expected Raise: {1:P0}, {2}", employee.Name, employee.ExpectedRaise, employee.ExpectedRaise);
			}
		}

		partial void createEmployee (MonoMac.Foundation.NSObject sender)
		{
			Person newEmployee = new Person();
			_employeeTableSource.Employees.Add(newEmployee);
			tableView.ReloadData();
		}

		partial void deleteSelectedEmployees (MonoMac.Foundation.NSObject sender)
		{
			// Which row(s) are selected?
			NSIndexSet rows = tableView.SelectedRows;

			// Is the selection empty?
			if (rows.Count == 0) {
				AppKitFramework.NSBeep();
				return;
			}

			// Using List
			_employeeTableSource.Employees.RemoveRange((int)rows.FirstIndex, (int)rows.LastIndex - (int)rows.FirstIndex +1);
			// Using NSMutableArray
//			_employeeTableSource.Employees.RemoveObjectsAtIndexes(rows);

			tableView.ReloadData();
		}
    }

	[Register("EmployeeTableSource")]
	public class EmployeeTableSource : NSTableViewSource
	{
		// Using list - not sure how to use sort descriptors with a list
		List<Person> _employees;

		public List<Person> Employees {
			get
			{
				return _employees;
			}
			set
			{
				if (value == _employees)
					return;
				_employees = value;
			}
		}
		// Using NSMutableArray
//		NSMutableArray _employees;
//
//		public NSMutableArray Employees {
//			get
//			{
//				return _employees;
//			}
//			set
//			{
//				if (value == _employees)
//					return;
//				_employees = value;
//			}
//		}


		public override int GetRowCount(NSTableView tableView)
		{
			// Using list
			return _employees.Count;
			// Using NSMutableArray
//			return (int)_employees.Count;
		}

		public override NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			// What is the identifier for the column?
			string identifier = tableColumn.Identifier;

			// What person?
			// Using List
			Person person = _employees[row];
			// Using NSMutableArray
//			Person person = _employees.GetItem<Person>(row);

			// What is the value of the attribute named identifier?
			return person.ValueForKey(new NSString(identifier));
		}

		public override void SetObjectValue(NSTableView tableView, NSObject theObject, NSTableColumn tableColumn, int row)
		{
			string identifier = tableColumn.Identifier;

			// Using List
			Person person = _employees[row];
			// Using NSMutableArray
//			Person person = _employees.GetItem<Person>(row);

			// Set the value for the Attribute named identifier
			person.SetValueForKey(theObject, new NSString(identifier));
		}

		public override void SortDescriptorsChanged(NSTableView tableView, NSSortDescriptor[] oldDescriptors)
		{
			NSSortDescriptor[] newDescriptors = tableView.SortDescriptors;

			// Using List
			NSSortDescriptor descriptor = newDescriptors[0];
			if (descriptor.Key == "name") {
				if (descriptor.Ascending)
					_employees.Sort((emp1, emp2)=>emp1.Name.ToLower().CompareTo(emp2.Name.ToLower()));
				else
					_employees.Sort((emp1, emp2)=>emp2.Name.ToLower().CompareTo(emp1.Name.ToLower()));
			}
			else if (descriptor.Key == "expectedRaise") {
				if (descriptor.Ascending)
					_employees.Sort((emp1, emp2)=>emp1.ExpectedRaise.CompareTo(emp2.ExpectedRaise));
				else
					_employees.Sort((emp1, emp2)=>emp2.ExpectedRaise.CompareTo(emp1.ExpectedRaise));
			}
			// Using NSMutableArray
//			_employees.SortUsingDescriptors(newDescriptors);

			tableView.ReloadData();
		}
	}
}

