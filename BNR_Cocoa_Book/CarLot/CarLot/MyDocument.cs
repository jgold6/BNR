
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using ObjCRuntime;

namespace CarLot
{
	public partial class MyDocument : AppKit.NSDocument
    {
		#region - Member variables and properties
		NSMutableArray _cars;

		[Export("cars")]
		NSMutableArray Cars {
			get
			{
				return _cars;
			}
			set
			{
				if (value == _cars)
					return;
				if (_cars != null) {
					for (nuint i = 0; i < _cars.Count; i++) {
						Car car = _cars.GetItem<Car>(i);
						this.StopObservingCar(car);
					}
				}

				_cars = value;

				for (nuint i = 0; i < _cars.Count; i++) {
					Car car = _cars.GetItem<Car>(i);
					this.StartObservingCar(car);
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
//        [Export("initWithCoder:")]
//        public MyDocument(NSCoder coder) : base(coder)
//        {
//        }
		#endregion

		#region - LifeCycle
        public override void WindowControllerDidLoadNib(NSWindowController windowController)
        {
            base.WindowControllerDidLoadNib(windowController);
            
            // Add code to here after the controller has loaded the document window
			if (Cars == null)
				Cars = new NSMutableArray();
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
			outError = null;
			// End editing
			tableView.Window.EndEditingFor(null);

			// Create an NSData object from the cars array
			return NSKeyedArchiver.ArchivedDataWithRootObject(Cars);
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
			this.Cars = newArray;
			// For Revert to Saved. Have to point the array controller to the new array.
			if (arrayController != null) {
				arrayController.Content = this.Cars;
			}
			return true;
        }
		#endregion

		#region - Actions
		partial void btnCheckEntries (Foundation.NSObject sender)
		{
			for (nuint i = 0; i < Cars.Count; i++) {
				Car car = Cars.GetItem<Car>(i);
				Console.WriteLine("Cars MakeModel: {0}, Price: {1:C2}, OnSpecial: {2}, Condition: {3}, Date Purchased {4}, Photo: {5}", car.MakeModel, car.Price, car.OnSpecial, car.Condition, car.DatePurchased.DescriptionWithLocale(NSLocale.CurrentLocale), car.Photo);
			}
			Console.WriteLine("****************************");
			NSObject[] arrObjects = arrayController.ArrangedObjects();
			foreach (NSObject obj in arrObjects) {
				Car car = (Car)obj;
				Console.WriteLine("ACon MakeModel: {0}, Price: {1:C2}, OnSpecial: {2}, Condition: {3}, Date Purchased {4}, Photo: {5}", car.MakeModel, car.Price, car.OnSpecial, car.Condition, car.DatePurchased.DescriptionWithLocale(NSLocale.CurrentLocale), car.Photo);
			}
			Console.WriteLine("****************************");
		}

		partial void btnCreateCar (Foundation.NSObject sender)
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
			// Should be able to do arrayController.NewObject, but it returns an NSObjectController
			// not an NSObject and also causes an InvalidCastException
			// BUG: https://bugzilla.xamarin.com/show_bug.cgi?id=25620
//			var c = arrayController.NewObject;
			// Workaround - not available in Unified API... due to protection level.
//			Car c = (Car)Runtime.GetNSObject(Messaging.IntPtr_objc_msgSend(arrayController.Handle, Selector.GetHandle ("newObject")));
			// Plus I can't figure out how to get the Car object from NSObjectController. Ah, this is due to above bug.
			// Creating my own Person object instead
			Car c = new Car();

			// Add it to the content array of arrayController
			arrayController.AddObject(c);

			// Re-sort (in case the user has sorted a column)
			arrayController.RearrangeObjects();

			// Get the sorted array
			NSArray a = NSArray.FromNSObjects(arrayController.ArrangedObjects());

			// Find the object just added
			nint row = -1;
			for (nuint i = 0; i < a.Count; i++) {
				if (c == a.GetItem<Car>(i)) {
					row = (nint)i;
					break;
				}
			}
			Console.WriteLine("Starting edit of {0} in row {1}", c, row);

			// Begin the edit of the first column
			tableView.EditColumn(0, row, null, true);
		}
		#endregion

		#region - Key Observing
		[Export("startObservingCar:")]
		public void StartObservingCar(Car car)
		{
			car.AddObserver(this, new NSString("makeModel"), NSKeyValueObservingOptions.Old, this.Handle);
			car.AddObserver(this, new NSString("datePurchased"), NSKeyValueObservingOptions.Old, this.Handle);
			car.AddObserver(this, new NSString("condition"), NSKeyValueObservingOptions.Old, this.Handle);
			car.AddObserver(this, new NSString("onSpecial"), NSKeyValueObservingOptions.Old, this.Handle);
			car.AddObserver(this, new NSString("price"), NSKeyValueObservingOptions.Old, this.Handle);
			car.AddObserver(this, new NSString("photo"), NSKeyValueObservingOptions.Old, this.Handle);
		}

		[Export("stopObservingPerson:")]
		public void StopObservingCar(Car car)
		{
			car.RemoveObserver(this, new NSString("makeModel"));
			car.RemoveObserver(this, new NSString("datePurchased"));
			car.RemoveObserver(this, new NSString("condition"));
			car.RemoveObserver(this, new NSString("onSpecial"));
			car.RemoveObserver(this, new NSString("price"));
			car.RemoveObserver(this, new NSString("photo"));
		}

		[Export("changeKeyPathofObjecttoValue:")]
		public void ChangeKeyPathOfObjectToValue(NSObject o)
		{
			NSString keyPath = ((NSArray)o).GetItem<NSString>(0);
			NSObject obj = ((NSArray)o).GetItem<NSObject>(1);
			NSObject newValue = ((NSArray)o).GetItem<NSObject>(2);
			// setValue:forKeyPath: will cause the key-value observing method
			// to be called, which takes care of the undo stuff
			if (newValue.DebugDescription != "<null>")
				obj.SetValueForKeyPath(newValue, keyPath);
			else {
				if (keyPath.ToString() == "photo")
					obj.SetValueForKeyPath(new NSImage(), keyPath);
			}
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
			undo.RegisterUndoWithTarget(this, new Selector("changeKeyPathofObjecttoValue:"), args);
			undo.SetActionname("Edit");

			// Sort if necessary
			// Not sorting avoids problem discussed in next comment
			//
			/// TODO: figure out how to sort after an edit AND hold onto the selection.
			/// Tried subclassing the NSTextField cell and creating a reference outlet to the arrayController
			/// But this outlet was always null. Need an outlet collection?
			/// However it did work properly when I did make a static property holding the array controller that I could
			/// access via an NSTextField cell subclass. Problem here was when multiple documents were open, 
			/// as it can only reference one array controller at a time.
			/// 
			/// OK, setting AutoRearrangeContent on the arrayController does the sort automatically after an edit
			/// but the item is then once again unfocused.
//			arrayController.RearrangeObjects();

			// Keep the row selected.
			// Without this, the row is selected in gray (tableView loses focus) and the arrow keys don't work to navigate to other items
			// and the return key does not trigger editing of the item again.
			/// TODO: Oops - does not work in a view based table view, 
			/// causes stack overflow as this method (ObserveValueForKeyPath) gets called infinitely.
//			tableView.EditColumn(0, tableView.SelectedRow, null, false);
		}
		#endregion

		#region - ArrayController methods
		[Export("insertObject:inCarsAtIndex:")]
		public void InsertObjectInCarsAtIndex(Car c, int index)
		{
			NSUndoManager undo = this.UndoManager;
			Console.WriteLine("Adding {0} to {1}", c, Cars);
			// Add the inverse of this operation to the undo stack
			NSArray args = NSArray.FromObjects(new object[]{c, new NSNumber(index)});
			undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);
			if (!undo.IsUndoing) {
				undo.SetActionname("Add Car");
			}
			// Add the car to the array
			this.StartObservingCar(c);
			Cars.Insert(c, index);
		}

		[Export("removeObjectFromCarsAtIndex:")]
		public void RemoveObjectFromCarsAtIndex(nint index)
		{
			NSUndoManager undo = this.UndoManager;
			Car c = Cars.GetItem<Car>((nuint)index);
			Console.WriteLine("Removing {0} from {1}", c, Cars);
			// Add the inverse of this operation to the undo stack
			NSArray args = NSArray.FromObjects(new object[]{c, new NSNumber(index)});
			undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);
			if (!undo.IsUndoing) {
				undo.SetActionname("Remove Car");
			}
			// Remove the person from the array
			this.StopObservingCar(c);
			Cars.RemoveObject(index);
		}

		[Export("undoAdd:")]
		public void UndoAdd(NSObject o)
		{
			Car c = ((NSArray)o).GetItem<Car>(0);

			Console.WriteLine("Undoing Add car");

			// Tell the array controller to remove the person, not the object at index with removeAt(i.ToInt32);
			arrayController.RemoveObject(c);
		}

		[Export("undoRemove:")]
		public void UndoRemove(NSObject o)
		{
			Car c = ((NSArray)o).GetItem<Car>(0);
			NSNumber i = ((NSArray)o).GetItem<NSNumber>(1);

			Console.WriteLine("Undoing Remove car");

			// Tell the arrayController to insert the person and sort if necessary
			arrayController.Insert(c, i.Int32Value);
			arrayController.RearrangeObjects();
		}
		#endregion
    }
}

