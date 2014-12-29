
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace CarLot
{
    public partial class MyDocument : MonoMac.AppKit.NSDocument
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
//				if (_cars != null) {
//					for (int i = 0; i < _cars.Count; i++) {
//						Car car = _cars.GetItem<Car>(i);
//						this.StopObservingCar(car);
//					}
//				}

				_cars = value;

//				for (int i = 0; i < _cars.Count; i++) {
//					Car car = _cars.GetItem<Car>(i);
//					this.StartObservingCar(car);
//				}
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

		#region - Key Observing
//		[Export("startObservingCar:")]
//		public void StartObservingCar(Car car)
//		{
//			car.AddObserver(this, new NSString("name"), NSKeyValueObservingOptions.Old, this.Handle);
//			car.AddObserver(this, new NSString("expectedRaise"), NSKeyValueObservingOptions.Old, this.Handle);
//		}
//
//		[Export("stopObservingPerson:")]
//		public void StopObservingCar(Car car)
//		{
//			car.RemoveObserver(this, new NSString("name"));
//			car.RemoveObserver(this, new NSString("expectedRaise"));
//		}
//
//		[Export("changeKeyPath:ofObject:toValue:")]
//		public void ChangeKeyPathOfObjectToValue(NSObject o)
//		{
//			NSString keyPath = ((NSArray)o).GetItem<NSString>(0);
//			NSObject obj = ((NSArray)o).GetItem<NSObject>(1);
//			NSObject newValue = ((NSArray)o).GetItem<NSObject>(2);
//			// setValue:forKeyPath: will cause the key-value observing method
//			// to be called, which takes care of the undo stuff
//			if (newValue.DebugDescription != "<null>")
//				obj.SetValueForKeyPath(newValue, keyPath);
//			else
//				obj.SetValueForKeyPath(new NSString("New Person"), keyPath);
//		}
//
//		[Export("observeValueForKeyPath:ofObject:change:context:")]
//		public void ObserveValueForKeyPath(NSString keyPath, NSObject obj, NSDictionary change, IntPtr context)
//		{
//			if (context != this.Handle) {
//				// If the context does not match, this message
//				// must be intended for our superclass
//				base.ObserveValue(keyPath, obj, change, context);
//				return;
//			}
//
//			NSUndoManager undo = this.UndoManager;
//			NSObject oldValue = change.ObjectForKey(ChangeOldKey);
//
//			// NSNull objects are used to represent nil in a dictinoary
//			if (oldValue == NSNull.Null) {
//				oldValue = null;
//			}
//			Console.WriteLine("oldValue = {0}", oldValue);
//			NSArray args = NSArray.FromObjects(new object[]{keyPath, obj, oldValue});
//			undo.RegisterUndoWithTarget(this, new Selector("changeKeyPath:ofObject:toValue:"), args);
//			undo.SetActionname("Edit");
//
//			// Sort if necessary
//			arrayController.RearrangeObjects();
//
//			// Keep the row selected.
//			// Without this, the row is selected in gray (tableView loses focus) and the arrow keys don't work to navigate to other items
//			// and the return key does not trigger editing of the item again.
//			tableView.EditColumn(0, tableView.SelectedRow, null, false);
//		}
		#endregion

		#region - Actions
		partial void btnCheckEntries (MonoMac.Foundation.NSObject sender)
		{
			for (int i = 0; i < Cars.Count; i++) {
				Car car = Cars.GetItem<Car>(i);
				Console.WriteLine("Cars MakeModel: {0}, Price: {1:C2}, OnSpecial: {2}, Condition: {3}, Date Purchased {4}", car.MakeModel, car.Price, car.OnSpecial, car.Condition, car.DatePurchased.DescriptionWithLocale(NSLocale.CurrentLocale));
			}
			Console.WriteLine("****************************");
			NSObject[] arrObjects = arrayController.ArrangedObjects();
			foreach (NSObject obj in arrObjects) {
				Car car = (Car)obj;
				Console.WriteLine("ACon MakeModel: {0}, Price: {1:C2}, OnSpecial: {2}, Condition: {3}, Date Purchased {4}", car.MakeModel, car.Price, car.OnSpecial, car.Condition, car.DatePurchased.DescriptionWithLocale(NSLocale.CurrentLocale));
			}
			Console.WriteLine("****************************");
		}
		#endregion
    }
}

