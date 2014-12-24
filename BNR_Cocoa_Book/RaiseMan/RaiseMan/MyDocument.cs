
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;

namespace RaiseMan
{
    public partial class MyDocument : MonoMac.AppKit.NSDocument
    {
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

		void Initialize()
		{
			Employees = new NSMutableArray();
		}

        public override void WindowControllerDidLoadNib(NSWindowController windowController)
        {
            base.WindowControllerDidLoadNib(windowController);
            
            // Add code to here after the controller has loaded the document window
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
			for (int i = 0; i < _employees.Count; i++) {
				Person employee = _employees.GetItem<Person>(i);
				Console.WriteLine("Person Name: {0}, Expected Raise: {1:P0}, {2}", employee.Name, employee.ExpectedRaise, employee.ExpectedRaise);
			}
		}
    }
}

