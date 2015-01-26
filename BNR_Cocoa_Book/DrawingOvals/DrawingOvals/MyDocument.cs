
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using ObjCRuntime;

namespace DrawingOvals
{
    public partial class MyDocument : AppKit.NSDocument
    {
		public List<Oval> Ovals {get; set;}

        // Called when created from unmanaged code
        public MyDocument(IntPtr handle) : base(handle)
        {
			Ovals = new List<Oval>();
        }

        public override void WindowControllerDidLoadNib(NSWindowController windowController)
        {
            base.WindowControllerDidLoadNib(windowController);
            
            // Add code to here after the controller has loaded the document window
			stretchView.AddToUndo = new UndoDelegate(delegate(Oval oval)
			{
				NSUndoManager undo = this.UndoManager;

				NSArray args = NSArray.FromObjects(new object[]{oval});
				undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);
				undo.SetActionname("Add Oval");
			});

			stretchView.Ovals = Ovals;
        }
        
        //
        // Save support:
        //    Override one of GetAsData, GetAsFileWrapper, or WriteToUrl.
        //
        
        // This method should store the contents of the document using the given typeName
        // on the return NSData value.
        public override NSData GetAsData(string documentType, out NSError outError)
        {
			outError = null;
			NSMutableArray array = new NSMutableArray();

			foreach (Oval o in Ovals) {
				array.Add(o);
			}

			// Create an NSData object from the employees array
			NSData data = NSKeyedArchiver.ArchivedDataWithRootObject(array);
			return data;
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

			Ovals = NSArray.FromArray<Oval>(newArray).ToList<Oval>();
			return true;
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

		[Export("undoAdd:")]
		public void UndoAdd(NSObject o)
		{
			Oval oval = ((NSArray)o).GetItem<Oval>(0);
			Console.WriteLine("Undoing Add Oval");

			// Add the inverse of this operation to the undo stack
			NSUndoManager undo = this.UndoManager;
			NSArray args = NSArray.FromObjects(new object[]{oval});
			undo.RegisterUndoWithTarget(this, new Selector("undoRemove:"), args);

			Ovals.Remove(oval);
			stretchView.Ovals = Ovals;
			stretchView.NeedsDisplay = true;
		}

		[Export("undoRemove:")]
		public void UndoRemove(NSObject o)
		{
			Oval oval = ((NSArray)o).GetItem<Oval>(0);

			Console.WriteLine("Undoing Remove oval");

			// Undo add
			NSUndoManager undo = this.UndoManager;
			NSArray args = NSArray.FromObjects(new object[]{oval});
			undo.RegisterUndoWithTarget(this, new Selector("undoAdd:"), args);

			Ovals.Add(oval);
			stretchView.Ovals = Ovals;
			stretchView.NeedsDisplay = true;
		}

    }
}

