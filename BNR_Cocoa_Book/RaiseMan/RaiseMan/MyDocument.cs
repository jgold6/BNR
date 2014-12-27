
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using System.Threading;

namespace RaiseMan
{
    public partial class MyDocument : MonoMac.AppKit.NSDocument
    {
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
				if (_employees != null) {
					for (int i = 0; i < _employees.Count; i++) {
						Person person = _employees.GetItem<Person>(i);
						this.StopObservingPerson(person);
					}
				}

				_employees = value;

				for (int i = 0; i < _employees.Count; i++) {
					Person person = _employees.GetItem<Person>(i);
					this.StartObservingPerson(person);
				}
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

		partial void btnCreateEmployee (MonoMac.Foundation.NSObject sender)
		{
			NSWindow w = tableView.Window;

			// try to end any editing that is taking place
			bool editingEnded = w.MakeFirstResponder(w);
			if (!editingEnded) {
				Console.WriteLine("Unable to end editing");
				return;
			}

			NSUndoManager undo = this.UndoManager;

			// Has an edit occurred already in this event?
			if (undo.GroupingLevel > 0) {
				// Close the last group
				undo.EndUndoGrouping();
				// Open a new group
				undo.BeginUndoGrouping();
			}

			// Create the object
			Person p = new Person();

			// Add it to the content array of arrayController
			arrayController.AddObject(p);

			// Re-sort (in case the user has sorted a column)
			arrayController.RearrangeObjects();

			// Get the sorted array
			NSArray a = NSArray.FromNSObjects(arrayController.ArrangedObjects());

			// Find the object just added
			int row = -1;
			for (int i = 0; i < a.Count; i++) {
				if (p == a.GetItem<Person>(i)) {
					row = i;
					break;
				}
			}
			Console.WriteLine("Starting edit of {0} in row {1}", p, row);

			// Begin the edit of the first column
			tableView.EditColumn(0, row, null, true);
		}
		#endregion

		#region - Key Observing
		[Export("startObservingPerson:")]
		public void StartObservingPerson(Person person)
		{
			person.AddObserver(this, new NSString("name"), NSKeyValueObservingOptions.Old, this.Handle);
			person.AddObserver(this, new NSString("expectedRaise"), NSKeyValueObservingOptions.Old, this.Handle);
		}

		[Export("stopObservingPerson:")]
		public void StopObservingPerson(Person person)
		{
			person.RemoveObserver(this, new NSString("name"));
			person.RemoveObserver(this, new NSString("expectedRaise"));
		}

		[Export("changeKeyPath:ofObject:toValue:")]
		public void ChangeKeyPathOfObjectToValue(NSObject o)
		{
			NSString keyPath = ((NSArray)o).GetItem<NSString>(0);
			NSObject obj = ((NSArray)o).GetItem<NSObject>(1);
			NSObject newValue = ((NSArray)o).GetItem<NSObject>(2);
			// setValue:forKeyPath: will cause the key-value observing method
			// to be called, which takes care of the undo stuff
			if (newValue.DebugDescription != "<null>")
				obj.SetValueForKeyPath(newValue, keyPath);
			else
				obj.SetValueForKeyPath(new NSString("New Person"), keyPath);
		}

		[Export("observeValueForKeyPath:ofObject:change:context:")]
		public void ObserveValueForKeyPath(NSString keyPath, NSObject obj, NSDictionary change, IntPtr context)
		{
			if (context != this.Handle) {
				// If the context does not match, this message
				// must be intended for our superclass
				base.ObserveValue(keyPath, obj, change, context);
				return;
			}

			NSUndoManager undo = this.UndoManager;
			NSObject oldValue = change.ObjectForKey(ChangeOldKey);

			// NSNull objects are used to represent nil in a dictinoary
			if (oldValue == NSNull.Null) {
				oldValue = null;
			}
			Console.WriteLine("oldValue = {0}", oldValue);
			NSArray args = NSArray.FromObjects(new object[]{keyPath, obj, oldValue});
			undo.RegisterUndoWithTarget(this, new Selector("changeKeyPath:ofObject:toValue:"), args);
			undo.SetActionname("Edit");
			arrayController.RearrangeObjects();
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
			this.StartObservingPerson(p);
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
			this.StopObservingPerson(p);
			Employees.RemoveObject(index);
		}

		[Export("undoAdd:")]
		public void UndoAdd(NSObject o)
		{
			Person p = ((NSArray)o).GetItem<Person>(0);

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

			// Tell the arrayController to insert the person and sort if necessary
			arrayController.Insert(p, i.Int32Value);
			arrayController.RearrangeObjects();
		}
		#endregion
    }
}

