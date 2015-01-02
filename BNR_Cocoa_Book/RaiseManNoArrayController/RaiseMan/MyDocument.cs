
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
		#region - Member variables and properties
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

				if (_employees != null) {
					for (int i = 0; i < _employees.Count; i++) {
						Person person = _employees[i];
						this.StopObservingPerson(person);
					}
				}

				_employees = value;

				for (int i = 0; i < _employees.Count; i++) {
					Person person = _employees[i];
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
			if (Employees == null)
				Employees = new List<Person>();

			tableView.WeakDataSource = this;
			tableView.WeakDelegate = this;
        }
		#endregion

		#region - save and load support
        //
        // Save support:
        //    Override one of GetAsData, GetAsFileWrapper, or WriteToUrl.
        //
        
        // This method should store the contents of the document using the given typeName
        // on the return NSData value.
		public override NSData GetAsData(string typeName, out NSError outError)
        {
			outError = null;
			// End editing
			tableView.Window.EndEditingFor(null);

			NSMutableArray array = new NSMutableArray();
			foreach (Person p in Employees) {
				array.Add(p);
			}

			// Create an NSData object from the employees array
			NSData data = NSKeyedArchiver.ArchivedDataWithRootObject(array);
			return data;

			// Default template code
//			outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
//			return null;
        }
        
        //
        // Load support:
        //    Override one of ReadFromData, ReadFromFileWrapper or ReadFromUrl
        //
        public override bool ReadFromData(NSData data, string typeName, out NSError outError)
        {
			outError = null;
			Console.WriteLine("About to read data of type {0}", typeName);

			NSMutableArray newArray = null;
			try {
				newArray = (NSMutableArray)NSKeyedUnarchiver.UnarchiveObject(data);
			}
			catch (Exception ex) {
				Console.WriteLine("Error loading file: Exception: {0}", ex.Message);
				if (outError != null) {
					NSDictionary d = NSDictionary.FromObjectAndKey(new NSString("The data is corrupted."), NSError.LocalizedFailureReasonErrorKey);
					outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4, d);
				}
				return false;
			}

			Employees = NSArray.FromArray<Person>(newArray).ToList<Person>();
			return true;

			// Default template code
//			outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
//			return false;
        }
		#endregion

		#region - Actions
		partial void btnCheckEntries (MonoMac.Foundation.NSObject sender)
		{
			for (int i = 0; i < Employees.Count; i++) {
				Person employee = Employees[i];
				Console.WriteLine("Person Name: {0}, Expected Raise: {1:P0}, {2}", employee.Name, employee.ExpectedRaise, employee.ExpectedRaise);
			}
		}

		// TODO: Set up undo
		partial void createEmployee (MonoMac.Foundation.NSObject sender)
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

			Person newEmployee = new Person();
			Console.WriteLine("Adding {0} to {1}", newEmployee, Employees);

			// Undo add
			NSArray args = NSArray.FromObjects(new object[]{newEmployee});
			undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);
			if (!undo.IsUndoing) {
				undo.SetActionname("Add Person");
			}

			Employees.Add(newEmployee);
			StartObservingPerson(newEmployee);
			tableView.ReloadData();

			int row = Employees.IndexOf(newEmployee);
			Console.WriteLine("Starting edit of {0} in row {1}", newEmployee, row);

			// Begin the edit of the first column
			tableView.EditColumn(0, row, null, true);
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

			NSUndoManager undo = this.UndoManager;
			undo.BeginUndoGrouping();
			for (int i = 0; i < rows.Count; i++) {
				int index = (int)rows.ElementAt(i);
				Person p = Employees[index];
				Console.WriteLine("Removing {0} from {1}", p, Employees);

				// Add the inverse of this operation to the undo stack
				NSArray args = NSArray.FromObjects(new object[]{p, new NSNumber(index)});
				undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);
				if (!undo.IsUndoing) {
					undo.SetActionname("Remove Person");
				}

				StopObservingPerson(p);
				Employees.RemoveAt(index);
			}
			undo.EndUndoGrouping();
			tableView.ReloadData();
		}
		#endregion

		#region - Undo
		[Export("undoAdd:")]
		public void UndoAdd(NSObject o)
		{
			NSWindow w = tableView.Window;
			// try to end any editing that is taking place
			bool editingEnded = w.MakeFirstResponder(w);
			if (!editingEnded) {
				Console.WriteLine("Unable to end editing");
				return;
			}

			Person p = ((NSArray)o).GetItem<Person>(0);
			int index = Employees.IndexOf(p);
			Console.WriteLine("Undoing Add person");

			// Add the inverse of this operation to the undo stack
			NSUndoManager undo = this.UndoManager;
			NSArray args = NSArray.FromObjects(new object[]{p, new NSNumber(index)});
			undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);
			if (!undo.IsUndoing) {
				undo.SetActionname("Remove Person");
			}
				
			Employees.Remove(p);
			tableView.ReloadData();
		}

		[Export("undoRemove:")]
		public void UndoRemove(NSObject o)
		{
			NSWindow w = tableView.Window;
			// try to end any editing that is taking place
			bool editingEnded = w.MakeFirstResponder(w);
			if (!editingEnded) {
				Console.WriteLine("Unable to end editing");
				return;
			}

			Person p = ((NSArray)o).GetItem<Person>(0);
			NSNumber index = ((NSArray)o).GetItem<NSNumber>(1);

			Console.WriteLine("Undoing Remove person");

			// Undo add
			NSUndoManager undo = this.UndoManager;
			NSArray args = NSArray.FromObjects(new object[]{p});
			undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);
			if (!undo.IsUndoing) {
				undo.SetActionname("Add Person");
			}
				
			Employees.Insert(index.Int32Value, p);
			if (tableView.SortDescriptors.Count() > 0) {
				NSSortDescriptor[] newDescriptors = tableView.SortDescriptors;

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
			}
			tableView.ReloadData();
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
				obj.SetValueForKeyPath(new NSString(""), keyPath);
			tableView.ReloadData();
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
		}
		#endregion

		#region - Weak Delegate and DataSource methods
		[Export("numberOfRowsInTableView:")]
		public int GetRowCount(NSTableView tableView)
		{
			return Employees.Count;
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			// What is the identifier for the column?
			string identifier = tableColumn.Identifier;

			// What person?
			Person person = _employees[row];

			// What is the value of the attribute named identifier?
			return person.ValueForKey(new NSString(identifier));
		}

		[Export("tableView:setObjectValue:forTableColumn:row:")]
		public void SetObjectValue(NSTableView tableView, NSObject theObject, NSTableColumn tableColumn, int row)
		{
			string identifier = tableColumn.Identifier;

			// Using List
			Person person = _employees[row];

			// Set the value for the Attribute named identifier
			person.SetValueForKey(theObject, new NSString(identifier));
		}

		[Export("tableView:sortDescriptorsDidChange:")]
		public void SortDescriptorsChanged(NSTableView tableView, NSSortDescriptor[] oldDescriptors)
		{
			NSSortDescriptor[] newDescriptors = tableView.SortDescriptors;

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
			tableView.ReloadData();
		}
		#endregion
    }
}

