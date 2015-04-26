
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using ObjCRuntime;
using CoreGraphics;
using System.Threading.Tasks;

namespace Departments
{
	public partial class MyDocument : AppKit.NSDocument
	{
		NSMutableArray viewControllers;
		#region - Member variables and properties
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

		// Updated Xam.Mac doesn't have an initWithCoder constructor for NSDocument.
//        // Called when created directly from a XIB file
//        [Export("initWithCoder:")]
//        public MyDocument(NSCoder coder) : base(coder)
//        {
//			Initialize();
//        }

		// Shared initialization code
		void Initialize()
		{
			viewControllers = new NSMutableArray();

			var dvc = new DepartmentViewController();
			var evc = new EmployeeViewController();
			viewControllers.AddObjects(new NSObject[]{dvc, evc});

			DataStore.LoadItemsFromDatabase();

			foreach (Employee emp in DataStore.Employees) {
				Console.WriteLine("Employee: {0}, Department: {1}", emp.FullName, emp.DepartmentName);
			}
			foreach (Department dep in DataStore.Departments) {
				Console.WriteLine("Department: {0}, Manager: {1}", dep.Name, dep.ManagerName);
			}
		}

		private void DisplayViewController(NSViewController vc)
		{
			BeginInvokeOnMainThread(() => {
				NSWindow w = box.Window;

				bool ended = w.MakeFirstResponder(w);
				if (!ended) {
					AppKitFramework.NSBeep();
					return;
				}
				// get the new View
				NSView newView = vc.View;

				// Get the old View
				NSView oldView = (NSView)box.ContentView;

				if (oldView == newView)
					return;

				// Compute the new window frame
				CGSize currentSize = oldView.Frame.Size;
				CGSize newSize = newView.Frame.Size;

				nfloat deltaWidth = newSize.Width - currentSize.Width;
				nfloat deltaHeight = newSize.Height - currentSize.Height;
				CGRect windowframe = w.Frame;
				windowframe.Size = new CGSize(windowframe.Size.Width, windowframe.Size.Height + deltaHeight);
				windowframe.Location = new CGPoint(windowframe.Location.X, windowframe.Location.Y - deltaHeight);
				windowframe.Size = new CGSize(windowframe.Size.Width + deltaWidth, windowframe.Size.Height);


				NSDictionary windowResize = NSDictionary.FromObjectsAndKeys( new NSObject[]{w, NSValue.FromCGRect(windowframe)}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EndFrameKey});
				NSDictionary oldViewFadeOut = NSDictionary.FromObjectsAndKeys( new NSObject[]{oldView, NSViewAnimation.FadeOutEffect}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EffectKey});
				NSDictionary newViewFadeOut = NSDictionary.FromObjectsAndKeys( new NSObject[]{newView, NSViewAnimation.FadeOutEffect}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EffectKey});
				NSDictionary fadeIn = NSDictionary.FromObjectsAndKeys( new NSObject[]{newView, NSViewAnimation.FadeInEffect}, new NSObject[]{NSViewAnimation.TargetKey, NSViewAnimation.EffectKey});

				NSViewAnimation animation = new NSViewAnimation(new NSDictionary[]{oldViewFadeOut});
				animation.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation.AnimationCurve = NSAnimationCurve.Linear;
				animation.Duration = 0.1;
				animation.StartAnimation();

				NSViewAnimation animation2 = new NSViewAnimation(new NSDictionary[]{newViewFadeOut});
				animation2.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation2.Duration = 0.0;
				animation2.StartAnimation();

				box.ContentView = newView;

				NSViewAnimation animation3 = new NSViewAnimation(new NSDictionary[]{windowResize});
				animation3.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation3.AnimationCurve = NSAnimationCurve.EaseInOut;
				animation3.Duration = 0.2;
				animation3.StartAnimation();


				NSViewAnimation animation4 = new NSViewAnimation(new NSDictionary[]{fadeIn});
				animation4.AnimationBlockingMode = NSAnimationBlockingMode.Blocking;
				animation4.AnimationCurve = NSAnimationCurve.Linear;
				animation4.Duration = 0.1;
				animation4.StartAnimation();

//				w.SetFrame(windowframe, true, true);
			});
		}
		#endregion

		#region - Lifecycle
		public override void WindowControllerDidLoadNib(NSWindowController windowController)
		{
			base.WindowControllerDidLoadNib(windowController);

			// Add code to here after the controller has loaded the document window

			// Populate the popup menu
			NSMenu menu = popup.Menu;
			nuint i, itemCount;
			itemCount = viewControllers.Count;

//			for (i = 0; i < itemCount; i++) {
				NSViewController vc = viewControllers.GetItem<NSViewController>(0);
				NSMenuItem mi = new NSMenuItem(vc.Title, null, "b");
			mi.KeyEquivalentModifierMask = NSEventModifierMask.CommandKeyMask;
				menu.AddItem(mi);

				vc = viewControllers.GetItem<NSViewController>(1);
				mi = new NSMenuItem(vc.Title, null, "a");
			mi.KeyEquivalentModifierMask = NSEventModifierMask.CommandKeyMask;
				menu.AddItem(mi);
//			}
			// Initially show the first controller.
			popup.SelectItem(0);
			DisplayViewController(viewControllers.GetItem<NSViewController>(0));
		}

		public override void ShouldCloseWindowController(NSWindowController windowController, NSObject delegateObject, Selector shouldCloseSelector, IntPtr contextInfo)
		{
			base.ShouldCloseWindowController(windowController, delegateObject, shouldCloseSelector, contextInfo);
		}
		#endregion

		#region - save and load support
		//
		// Save support:
		//    Override one of GetAsData, GetAsFileWrapper, or WriteToUrl.
		//

		// This method should store the contents of the document using the given typeName
		// on the return NSData value.
//		public override NSData GetAsData(string typeName, out NSError outError)
//		{
//			outError = null;
//			// End editing
//			tableView.Window.EndEditingFor(null);
//
//			NSMutableArray array = new NSMutableArray();
//			foreach (Person p in Employees) {
//				array.Add(p);
//			}
//
//			// Create an NSData object from the employees array
//			NSData data = NSKeyedArchiver.ArchivedDataWithRootObject(array);
//			return data;
//
//			// Default template code
//			//			outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
//			//			return null;
//		}

		//
		// Load support:
		//    Override one of ReadFromData, ReadFromFileWrapper or ReadFromUrl
		//
//		public override bool ReadFromData(NSData data, string typeName, out NSError outError)
//		{
//			outError = null;
//			Console.WriteLine("About to read data of type {0}", typeName);
//
//			NSMutableArray newArray = null;
//			try {
//				newArray = (NSMutableArray)NSKeyedUnarchiver.UnarchiveObject(data);
//			}
//			catch (Exception ex) {
//				Console.WriteLine("Error loading file: Exception: {0}", ex.Message);
//				NSDictionary d = NSDictionary.FromObjectAndKey(new NSString(NSBundle.MainBundle.LocalizedString("DATA_CORRUPTED", null)), NSError.LocalizedFailureReasonErrorKey);
//				outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4, d);
//				return false;
//			}
//
//			Employees = NSArray.FromArray<Person>(newArray).ToList<Person>();
//			return true;
//
//			// Default template code
//			//			outError = NSError.FromDomain(NSError.OsStatusErrorDomain, -4);
//			//			return false;
//		}
		#endregion

		#region - Printing Support
		// NOTE: I needed to add this method and export it as an action in order to hook up the
		// Print... menu to the FirstResponder printDocument: method which has to be called bu the OS
		// and will trigger the call to PrintOperation(NSDictionary printSettings, out NSError outError)
		// However, once I added this method and made the connection, I no longer need this here, 
		// so it was just needed to be able to set the target/ action pair for the Print... menu. 
//		[Action("printDocument:")]
//		public override void PrintDocument(NSObject sender)
//		{
//			//base.PrintDocument(sender);
//		}

//		public override NSPrintOperation PrintOperation(NSDictionary printSettings, out NSError outError)
//		{
//			outError = new NSError();
//			PeopleView view = new PeopleView(NSArray.FromObjects(Employees.ToArray()));
//			NSPrintInfo printInfo = this.PrintInfo;
//			NSPrintOperation printOp = NSPrintOperation.FromView(view, printInfo);
//			return printOp;
//		}
		#endregion

		#region - Actions
		partial void ChangeViewController (NSPopUpButton sender)
		{
			nint i = sender.IndexOfSelectedItem;
			var vc = viewControllers.GetItem<NSViewController>((nuint)i);
			Task.Run(()=> {;
				DisplayViewController(vc);
			});
		}
		#endregion

		#region - Undo
//		[Export("undoAdd:")]
//		public void UndoAdd(NSObject o)
//		{
//			// try to end any editing that is taking place
//			if (!StopEditing())
//				return;
//
//			Person p = ((NSArray)o).GetItem<Person>(0);
//			int index = Employees.IndexOf(p);
//			Console.WriteLine("Undoing Add person");
//
//			// Add the inverse of this operation to the undo stack
//			NSUndoManager undo = this.UndoManager;
//			NSArray args = NSArray.FromObjects(new object[]{p, new NSNumber(index)});
//			undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);
//
//			StopObservingPerson(p);
//			// have to push any previous selections that are after this up one
//			for (int i = index; i < Employees.Count; i++) {
//				if (tableView.IsRowSelected(i)) {
//					tableView.DeselectRow(i);
//					tableView.SelectRow(i-1, true);
//				}
//			}
//			Employees.Remove(p);
//			tableView.ReloadData();
//		}
//
//		[Export("undoRemove:")]
//		public void UndoRemove(NSObject o)
//		{
//			NSIndexSet selections = tableView.SelectedRows;
//
//			Person p = ((NSArray)o).GetItem<Person>(0);
//			NSNumber index = ((NSArray)o).GetItem<NSNumber>(1);
//
//			Console.WriteLine("Undoing Remove person");
//
//			// Undo add
//			NSUndoManager undo = this.UndoManager;
//			NSArray args = NSArray.FromObjects(new object[]{p});
//			undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);
//
//			StartObservingPerson(p);
//			Employees.Insert(index.Int32Value, p);
//			tableView.ReloadData();
//			// have to push any previous selections that are after this up one
//			for (int i = Employees.Count-1; i > index.Int32Value; i--) {
//				if (tableView.IsRowSelected(i-1)) {
//					tableView.DeselectRow(i-1);
//					tableView.SelectRow(i, true);
//				}
//			}
//			// Uncomment to reselect added rows. However I decided that maintaining the current selection is more important
//			// So as not to change the items the user has selected. 
//			//			tableView.SelectRow(index.Int32Value, true);
//
//			SortData(tableView.SortDescriptors);
//		}
//
//		[Export("changeKeyPathofObjecttoValue:")]
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
//				obj.SetValueForKeyPath(new NSString(""), keyPath);
//			tableView.ReloadData();
//		}
		#endregion

		#region - Key Observing
//		[Export("startObservingPerson:")]
//		public void StartObservingPerson(Person person)
//		{
//			person.AddObserver(this, new NSString("name"), NSKeyValueObservingOptions.Old, this.Handle);
//			person.AddObserver(this, new NSString("expectedRaise"), NSKeyValueObservingOptions.Old, this.Handle);
//		}
//
//		[Export("stopObservingPerson:")]
//		public void StopObservingPerson(Person person)
//		{
//			person.RemoveObserver(this, new NSString("name"));
//			person.RemoveObserver(this, new NSString("expectedRaise"));
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
//			undo.RegisterUndoWithTarget(this, new Selector("changeKeyPathofObjecttoValue:"), args);
//			undo.SetActionname(NSBundle.MainBundle.LocalizedString("EDIT", null));
//		}
		#endregion

		#region - Helper methods
//		public void SortData(NSSortDescriptor[] descriptors) {
//			NSIndexSet selections = tableView.SelectedRows;
//			// Get a list of people to be removed
//			List<Person> selectedPersons = new List<Person>();
//			for (int i = 0; i < selections.Count; i++) {
//				int index = (int)selections.ElementAt(i);
//				Person p = Employees[index];
//				selectedPersons.Add(p);
//			}
//			if (descriptors.Count<NSSortDescriptor>() > 0) {
//				NSSortDescriptor descriptor = descriptors[0];
//				if (descriptor.Key == "name") {
//					if (descriptor.Ascending)
//						_employees.Sort((emp1, emp2)=>emp1.Name.ToLower().CompareTo(emp2.Name.ToLower()));
//					else
//						_employees.Sort((emp1, emp2)=>emp2.Name.ToLower().CompareTo(emp1.Name.ToLower()));
//				}
//				else if (descriptor.Key == "expectedRaise") {
//					if (descriptor.Ascending)
//						_employees.Sort((emp1, emp2)=>emp1.ExpectedRaise.CompareTo(emp2.ExpectedRaise));
//					else
//						_employees.Sort((emp1, emp2)=>emp2.ExpectedRaise.CompareTo(emp1.ExpectedRaise));
//				}
//			}
//
//			tableView.DeselectAll(this);
//			foreach (Person p in selectedPersons) {
//				tableView.SelectRow(Employees.IndexOf(p), true);
//			}
//		}
//
//		public bool StopEditing()
//		{
//			NSWindow w = tableView.Window;
//			// try to end any editing that is taking place
//			bool editingEnded = w.MakeFirstResponder(w);
//			if (!editingEnded) {
//				Console.WriteLine("Unable to end editing");
//			}
//			return editingEnded;
//		}
		#endregion

		#region - Notification receiving
//		[Export("handleColorChange:")]
//		public void HandleColorChange(NSNotification note)
//		{
//			Console.WriteLine("{0}: Received color change notification: {1}", this, note);
//			NSColor color = (NSColor)note.UserInfo.ObjectForKey(DefaultStrings.RMColor);
//			tableView.BackgroundColor = color;
//		}
		#endregion
	}
}

