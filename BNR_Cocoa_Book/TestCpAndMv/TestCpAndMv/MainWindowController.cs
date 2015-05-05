using System;

using Foundation;
using AppKit;

namespace TestCpAndMv
{
    public partial class MainWindowController : NSWindowController
    {
        public MainWindowController(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
        }

        public MainWindowController() : base("MainWindow")
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public new MainWindow Window
        {
            get { return (MainWindow)base.Window; }
        }

		partial void copyFile (Foundation.NSObject sender)
		{
			if (textFieldFrom.StringValue == "" || textFieldTo.StringValue == "") {
				textFieldResults.StringValue = "Must set 'from' and 'to' paths";
				return;
			}

			// Prepare a task object
			NSTask task = new NSTask();
			task.LaunchPath = "/bin/cp";
			string[] args = {textFieldFrom.StringValue, textFieldTo.StringValue};
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
				textFieldResults.StringValue = "Copy Failed: " + status;
				return;
			}

			textFieldResults.StringValue = String.Format("{0} copied to {1}", textFieldFrom.StringValue, textFieldTo.StringValue);
		}

		partial void moveFile (Foundation.NSObject sender)
		{
			if (textFieldFrom.StringValue == "" || textFieldTo.StringValue == "") {
				textFieldResults.StringValue = "Must set 'from' and 'to' paths";
				return;
			}

			// Prepare a task object
			NSTask task = new NSTask();
			task.LaunchPath = "/bin/mv";
			string[] args = {textFieldFrom.StringValue, textFieldTo.StringValue};
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
				textFieldResults.StringValue = "Move Failed: " + status;
				return;
			}

			textFieldResults.StringValue = String.Format("{0} moved to {1}", textFieldFrom.StringValue, textFieldTo.StringValue);
		}
    }
}
