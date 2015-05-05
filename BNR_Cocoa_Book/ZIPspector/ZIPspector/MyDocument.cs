
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CoreGraphics;

namespace ZIPspector
{
    public partial class MyDocument : AppKit.NSDocument
    {
		public static string[] filenames;


        // Called when created from unmanaged code
        public MyDocument(IntPtr handle) : base(handle)
        {
        }
        
        // Called when created directly from a XIB file
//        [Export("initWithCoder:")]
//        public MyDocument(NSCoder coder) : base(coder)
//        {
//        }

        public override void WindowControllerDidLoadNib(NSWindowController windowController)
        {
            base.WindowControllerDidLoadNib(windowController);
            
            // Add code to here after the controller has loaded the document window
        }

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			tableView.Source = new MySource();
		}
        
		public override bool ReadFromUrl(NSUrl url, string typeName, out NSError outError)
		{
			outError = null;
			// Which files are we getting the zipinfo for?
			string filename = url.Path;


			string lPath = "";
			string flags = "";
			Console.WriteLine("Type Name: {0}", typeName);
			switch (typeName) 
			{
				case "public.zip-archive":
					lPath = "/usr/bin/zipinfo";
					flags = "-1";
					break;
				case "public.tar-archive":
					lPath = "/usr/bin/tar";
					flags = "tf";
					break;
				case "org.gnu.gnu-zip-tar-archive":
					lPath = "/usr/bin/tar";
					flags = "tzf";
					break;
				default:
					NSDictionary eDict = NSDictionary.FromObjectAndKey(new NSString("Archive type not supported"), NSError.LocalizedFailureReasonErrorKey);
					outError = NSError.FromDomain(NSError.OsStatusErrorDomain,0, eDict);
					break;
			}

			// Prepare a task object
			NSTask task = new NSTask();
			task.LaunchPath = lPath;
			string[] args = {flags, filename};
			task.Arguments = args;

			// Create a pipe to read from
			NSPipe outPipe = new NSPipe();
			task.StandardOutput = outPipe;

			// Start the process
			task.Launch();

			// Read the output
			NSData data = outPipe.ReadHandle.ReadDataToEndOfFile();

			// Make sure the task terminates normally
			task.WaitUntilExit();
			int status = task.TerminationStatus;

			// Check status
			if (status != 0) {
				if (outError != null) {
					NSDictionary eDict = NSDictionary.FromObjectAndKey(new NSString("zipinfo failed"), NSError.LocalizedFailureReasonErrorKey);
					outError = NSError.FromDomain(NSError.OsStatusErrorDomain,0, eDict);
				}
				return false;
			}

			// Convert to a string
			string aString = NSString.FromData(data,NSStringEncoding.UTF8).ToString();

			// Break the string into lines
			MyDocument.filenames = aString.Split(new char[]{'\n'});
			Console.WriteLine(MyDocument.filenames);

			// In case of revert
//			tableView.ReloadData();

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
    }

	class MySource : NSTableViewSource
	{
		public override nint GetRowCount(NSTableView tableView)
		{
			return MyDocument.filenames.Length;
		}

		public override nfloat GetRowHeight(NSTableView tableView, nint row)
		{
			return 18.0f;
		}

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{
			NSTextField textField = new NSTextField(new CGRect(0, 0, tableColumn.Width, 30));
			textField.Bordered = false;
			textField.BackgroundColor = NSColor.Clear;
			textField.StringValue = MyDocument.filenames[(int)row];
			return textField;
		}
	}
}

