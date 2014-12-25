
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
		NSMutableArray _employees;
		Stack<int> _undoIndexes;
		Stack<int> _redoIndexes;
		Stack<Person> _removedPersons;

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
			_undoIndexes = new Stack<int>();
			_redoIndexes = new Stack<int>();
			_removedPersons = new Stack<Person>();
			Employees = new NSMutableArray();
			for (int i = 0; i < 5; i++) {
				arrayController.Add(this);
			}
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
			for (int i = 0; i < Employees.Count; i++) {
				Person employee = Employees.GetItem<Person>(i);
				Console.WriteLine("Person Name: {0}, Expected Raise: {1:P0}, {2}", employee.Name, employee.ExpectedRaise, employee.ExpectedRaise);
			}
		}

		[Export("insertObject:inEmployeesAtIndex:")]
		public void InsertObjectInEmployeesAtIndex(Person p, int index)
		{
			NSUndoManager undo = this.UndoManager;
			Console.WriteLine("Adding {0} to {1}", p, Employees);
			// Add the inverse of this operation to the undo stack
			undo.RegisterUndoWithTarget(this, new Selector("undoAdd"), new NSObject());
			if (!undo.IsUndoing && !undo.IsRedoing) {
				undo.SetActionname("Add Person");
				// Add the person to the array
				_undoIndexes.Push(index);
				_redoIndexes.Clear();
			}
			Employees.Insert(p, index);

		}

		[Export("removeObjectFromEmployeesAtIndex:")]
		public void RemoveObjectFromEmployeesAtIndex(int index)
		{
			NSUndoManager undo = this.UndoManager;
			Person p = Employees.GetItem<Person>((int)index);
			Console.WriteLine("Removing {0} from {1}", p, Employees);
			// Add the inverse of this operation to the undo stack
			undo.RegisterUndoWithTarget(this, new Selector("undoRemove"), new NSObject());
			if (!undo.IsUndoing && !undo.IsRedoing) {
				undo.SetActionname("Remove Person");
				// Remove the person from the array
				_undoIndexes.Push(index);
				_redoIndexes.Clear();
			}
			Employees.RemoveObject(index);
			_removedPersons.Push(p);
		}

		[Export("undoAdd")]
		public void UndoAdd()
		{
			Console.WriteLine("Undoing Add person");
			NSUndoManager undo = this.UndoManager;
			int index = 0;
			if (undo.IsUndoing) {
				index = _undoIndexes.Pop();
				_redoIndexes.Push(index);
			}
			else  {
				index = _redoIndexes.Pop();
				_undoIndexes.Push(index);
			}
			arrayController.RemoveAt(index);
		}

		[Export("undoRemove")]
		public void UndoRemove()
		{
			Console.WriteLine("Undoing Remove person");
			NSUndoManager undo = this.UndoManager;
			int index = 0;
			if (undo.IsUndoing) {
				index = _undoIndexes.Pop();
				_redoIndexes.Push(index);
			}
			else {
				index = _redoIndexes.Pop();
				_undoIndexes.Push(index);
			}
			arrayController.Insert(_removedPersons.Pop(), index);
		}
    }
}

