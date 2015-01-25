
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
			Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MyDocument(NSCoder coder) : base(coder)
        {
			Initialize();
        }

		// Shared initialization code
		void Initialize()
		{
			NSNotificationCenter nc = NSNotificationCenter.DefaultCenter;
			nc.AddObserver(this, new Selector("handleColorChange:"), DefaultStrings.RMColorChangedNotification, null);
			Console.WriteLine("{0}: Registered with notification center", this);
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

			tableView.BackgroundColor = PreferenceController.PreferenceTableBgColor;
        }

		public override void ShouldCloseWindowController(NSWindowController windowController, NSObject delegateObject, Selector shouldCloseSelector, IntPtr contextInfo)
		{
			base.ShouldCloseWindowController(windowController, delegateObject, shouldCloseSelector, contextInfo);
			NSNotificationCenter.DefaultCenter.RemoveObserver(this);
			Console.WriteLine("{0}: Unregistered from notification center", this);
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
				NSDictionary d = NSDictionary.FromObjectAndKey(new NSString(NSBundle.MainBundle.LocalizedString("DATA_CORRUPTED", null)), NSError.LocalizedFailureReasonErrorKey);
				outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4, d);
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

		partial void createEmployee (MonoMac.Foundation.NSObject sender)
		{
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
			undo.SetActionname(NSBundle.MainBundle.LocalizedString("ADD_PERSON", null));

			Employees.Add(newEmployee);
			StartObservingPerson(newEmployee);
			tableView.ReloadData();

			int row = Employees.IndexOf(newEmployee);
			Console.WriteLine("Starting edit of {0} in row {1}", newEmployee, row);

			// Begin the edit of the first column
			tableView.SelectRow(row, false);
			tableView.EditColumn(0, row, null, true);
		}

		partial void deleteSelectedEmployees (MonoMac.Foundation.NSObject sender)
		{
			if (!StopEditing())
				return;
			// Which row(s) are selected?
			NSIndexSet rows = tableView.SelectedRows;

			// Get a list of people to be removed
			List<Person> removedPersons = new List<Person>();
			NSUndoManager undo = this.UndoManager;
			for (int i = 0; i < rows.Count; i++) {
				int index = (int)rows.ElementAt(i);
				Person p = Employees[index];
				removedPersons.Add(p);
			}

			// remove each Person and add to the undo stack
			foreach(Person p in removedPersons) {
				Console.WriteLine("Removing {0} from {1}", p, Employees);
				// Add the inverse of this operation to the undo stack
				int index = Employees.IndexOf(p);
				NSArray args = NSArray.FromObjects(new object[]{p, new NSNumber(index)});
				undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);
				undo.SetActionname(NSBundle.MainBundle.LocalizedString("REMOVE_PERSON", null));

				StopObservingPerson(p);
				Employees.Remove(p);
			}
			tableView.ReloadData();
			tableView.DeselectAll(this);
		}

		partial void removeEmployee (MonoMac.Foundation.NSObject sender)
		{
			// Which row(s) are selected?
			NSIndexSet rows = tableView.SelectedRows;

			// Is the selection empty?
			if (rows.Count == 0) {
				AppKitFramework.NSBeep();
				return;
			}
			NSAlert alert = NSAlert.WithMessage(NSBundle.MainBundle.LocalizedString("REMOVE_MSG", null), 
				NSBundle.MainBundle.LocalizedString("CANCEL", null),
				NSBundle.MainBundle.LocalizedString("OK", null), 
				NSBundle.MainBundle.LocalizedString("NO_RAISE", null),
				"");
			alert.InformativeText = String.Format("{0} {1} {2}", 
				rows.Count, 
				rows.Count == 1 ? NSBundle.MainBundle.LocalizedString("EMPLOYEE", null) : NSBundle.MainBundle.LocalizedString("EMPLOYEES", null), 
				NSBundle.MainBundle.LocalizedString("REMOVE_INF", null));
			alert.BeginSheetForResponse(tableView.Window, (response) => GetResponse(alert, response));
		}

		void GetResponse(NSAlert alert, int response)
		{
			if (response <= 1) {
				switch (response) {
					case -1:
						NSIndexSet rows = tableView.SelectedRows;
						for (int i = 0; i < rows.Count; i++) {
							Person p = Employees[(int)rows.ElementAt(i)];
							p.SetValueForKey(new NSNumber(0.0f), new NSString("expectedRaise"));
						}
						break;
					case 0: // OK
						deleteSelectedEmployees(this);
						break;
					default: // Cancel
						break;
				}
			}
		}
		#endregion

		#region - Undo
		[Export("undoAdd:")]
		public void UndoAdd(NSObject o)
		{
			// try to end any editing that is taking place
			if (!StopEditing())
				return;

			Person p = ((NSArray)o).GetItem<Person>(0);
			int index = Employees.IndexOf(p);
			Console.WriteLine("Undoing Add person");

			// Add the inverse of this operation to the undo stack
			NSUndoManager undo = this.UndoManager;
			NSArray args = NSArray.FromObjects(new object[]{p, new NSNumber(index)});
			undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);

			StopObservingPerson(p);
			// have to push any previous selections that are after this up one
			for (int i = index; i < Employees.Count; i++) {
				if (tableView.IsRowSelected(i)) {
					tableView.DeselectRow(i);
					tableView.SelectRow(i-1, true);
				}
			}
			Employees.Remove(p);
			tableView.ReloadData();
		}

		[Export("undoRemove:")]
		public void UndoRemove(NSObject o)
		{
			NSIndexSet selections = tableView.SelectedRows;

			Person p = ((NSArray)o).GetItem<Person>(0);
			NSNumber index = ((NSArray)o).GetItem<NSNumber>(1);

			Console.WriteLine("Undoing Remove person");

			// Undo add
			NSUndoManager undo = this.UndoManager;
			NSArray args = NSArray.FromObjects(new object[]{p});
			undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);

			StartObservingPerson(p);
			Employees.Insert(index.Int32Value, p);
			tableView.ReloadData();
			// have to push any previous selections that are after this up one
			for (int i = Employees.Count-1; i > index.Int32Value; i--) {
				if (tableView.IsRowSelected(i-1)) {
					tableView.DeselectRow(i-1);
					tableView.SelectRow(i, true);
				}
			}
			// Uncomment to reselect added rows. However I decided that maintaining the current selection is more important
			// So as not to change the items the user has selected. 
//			tableView.SelectRow(index.Int32Value, true);

			SortData(tableView.SortDescriptors);
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
			undo.SetActionname(NSBundle.MainBundle.LocalizedString("EDIT", null));
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
			SortData(tableView.SortDescriptors);
			tableView.ReloadData();
		}
		#endregion

		#region - Helper methods
		public void SortData(NSSortDescriptor[] descriptors) {
			NSIndexSet selections = tableView.SelectedRows;
			// Get a list of people to be removed
			List<Person> selectedPersons = new List<Person>();
			for (int i = 0; i < selections.Count; i++) {
				int index = (int)selections.ElementAt(i);
				Person p = Employees[index];
				selectedPersons.Add(p);
			}
			if (descriptors.Count<NSSortDescriptor>() > 0) {
				NSSortDescriptor descriptor = descriptors[0];
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

			tableView.DeselectAll(this);
			foreach (Person p in selectedPersons) {
				tableView.SelectRow(Employees.IndexOf(p), true);
			}
		}

		public bool StopEditing()
		{
			NSWindow w = tableView.Window;
			// try to end any editing that is taking place
			bool editingEnded = w.MakeFirstResponder(w);
			if (!editingEnded) {
				Console.WriteLine("Unable to end editing");
			}
			return editingEnded;
		}
		#endregion

		#region - Notification receiving
		[Export("handleColorChange:")]
		public void HandleColorChange(NSNotification note)
		{
			Console.WriteLine("{0}: Received color change notification: {1}", this, note);
			NSColor color = (NSColor)note.UserInfo.ObjectForKey(DefaultStrings.RMColor);
			tableView.BackgroundColor = color;
		}
		#endregion
    }
}

