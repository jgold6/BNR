
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;

namespace RaiseMan
{
    public partial class MyDocument : MonoMac.AppKit.NSDocument
    {
		bool firstTime = true;
		#region - Member variables and properties
		NSMutableArray _employees;

		[Export("employees")]
		NSMutableArray Employees {
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

		// If this returns the name of a NIB file instead of null, a NSDocumentController
		// is automatically created for you.
		public override string WindowNibName
		{ 
			get
			{
				return "MyDocument";
			}
		}
		#endregion

		#region - Constructors
        // Called when created from unmanaged code
        public MyDocument(IntPtr handle) : base(handle)
        {
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MyDocument(NSCoder coder) : base(coder)
        {
        }
		#endregion

		#region - Lifecycle
        public override void WindowControllerDidLoadNib(NSWindowController windowController)
        {
            base.WindowControllerDidLoadNib(windowController);
            
            // Add code to here after the controller has loaded the document window
			Employees = new NSMutableArray();
			for (int i = 0; i < 5; i++) {
				arrayController.Add(this);
			}
        }
		#endregion

		#region - save and load support
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
		#endregion

		#region - Actions
		partial void btnCheckEntries (MonoMac.Foundation.NSObject sender)
		{
			if (firstTime) {
				firstTime = false;
				Employees.GetItem<Person>(0).Name = "One";
				Employees.GetItem<Person>(1).Name = "Two";
				Employees.GetItem<Person>(2).Name = "Three";
				Employees.GetItem<Person>(3).Name = "Four";
				Employees.GetItem<Person>(4).Name = "Five";
				tableView.ReloadData();
			}
			for (int i = 0; i < Employees.Count; i++) {
				Person employee = Employees.GetItem<Person>(i);
				Console.WriteLine("Employees Person Name: {0}, Expected Raise: {1:P0}, {2}", employee.Name, employee.ExpectedRaise, employee.ExpectedRaise);
			}
			Console.WriteLine("****************************");
			NSObject[] arrObjects = arrayController.ArrangedObjects();
			foreach (NSObject obj in arrObjects) {
				Person employee = (Person)obj;
				Console.WriteLine("ArrayController Person Name: {0}, Expected Raise: {1:P0}, {2}", employee.Name, employee.ExpectedRaise, employee.ExpectedRaise);
			}
			Console.WriteLine("****************************");
		}
		#endregion

		#region - ArrayController methods
		[Export("insertObject:inEmployeesAtIndex:")]
		public void InsertObjectInEmployeesAtIndex(Person p, int index)
		{
			NSUndoManager undo = this.UndoManager;
			Console.WriteLine("Adding {0} to {1}", p, Employees);
			// Add the inverse of this operation to the undo stack
			NSArray args = NSArray.FromObjects(new object[]{p, new NSNumber(index)});
			undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);
			if (!undo.IsUndoing) {
				undo.SetActionname("Add Person");
			}
			// Add the person to the array
			Employees.Insert(p, index);

		}

		[Export("removeObjectFromEmployeesAtIndex:")]
		public void RemoveObjectFromEmployeesAtIndex(int index)
		{
			NSUndoManager undo = this.UndoManager;
			Person p = Employees.GetItem<Person>(index);
			Console.WriteLine("Removing {0} from {1}", p, Employees);
			// Add the inverse of this operation to the undo stack
			NSArray args = NSArray.FromObjects(new object[]{p, new NSNumber(index)});
			undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);
			if (!undo.IsUndoing) {
				undo.SetActionname("Remove Person");
			}
			// Remove the person from the array
			Employees.RemoveObject(index);
		}

		[Export("undoAdd:")]
		public void UndoAdd(NSObject o)
		{
			Person p = ((NSArray)o).GetItem<Person>(0);
//			NSNumber i = ((NSArray)o).GetItem<NSNumber>(1);

			Console.WriteLine("Undoing Add person");

			// Tell the array controller to remove the person, not the object at index with removeAt(i.ToInt32);
			arrayController.RemoveObject(p);
		}

		[Export("undoRemove:")]
		public void UndoRemove(NSObject o)
		{
			Person p = ((NSArray)o).GetItem<Person>(0);
			NSNumber i = ((NSArray)o).GetItem<NSNumber>(1);

			Console.WriteLine("Undoing Remove person");

			// Tell the arrayController to insert the person
			arrayController.Insert(p, i.Int32Value);
		}
		#endregion
    }
}

