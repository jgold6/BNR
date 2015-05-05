using System;

using Foundation;
using AppKit;
using ObjCRuntime;

namespace iPing
{
    public partial class MainWindowController : NSWindowController
    {
		NSTask task;
		NSPipe pipe;


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

		partial void startStopPing (Foundation.NSObject sender)
		{
			if (task != null) {
				task.Interrupt();
			}
			else {
				task = new NSTask();
				task.LaunchPath = "/sbin/ping";
				string[] args = {"-c10", hostField.StringValue};

				task.Arguments = args;

				// Create a new pipe
				pipe = new NSPipe();
				task.StandardOutput = pipe;

				NSFileHandle fh = pipe.ReadHandle;

				NSNotificationCenter nc = NSNotificationCenter.DefaultCenter;
				nc.RemoveObserver(this);
				nc.AddObserver(this, new Selector("dataReady:"), NSFileHandle.ReadCompletionNotification, fh);
				nc.AddObserver(this, new Selector("taskTerminated:"), NSTask.NSTaskDidTerminateNotification, task);
				task.Launch();
				outputView.Value = "";

				// Suspect = Obj-C example is [fh readInBackgroundAndNotify] - no arguments
				fh.ReadInBackground();
			}
		}

		void AppendData(NSData d)
		{
			NSString s = NSString.FromData(d, NSStringEncoding.UTF8);
			NSTextStorage ts = outputView.TextStorage;
			ts.Replace(new NSRange(ts.Length, 0), s);
		}

		[Export("dataReady:")]
		void DataReady(NSNotification n)
		{
			foreach (NSString str in n.UserInfo.Keys) {
				Console.WriteLine(str);
			}

			NSData d = (NSData)n.UserInfo.ValueForKey(new NSString("NSFileHandleNotificationDataItem"));

			Console.WriteLine("Data Ready: {0} bytes", d.Length);

			if (d.Length > 0) {
				this.AppendData(d);
			}

			// If the task is running, start reading again
			if (task != null) {
				pipe.ReadHandle.ReadInBackground();
			}
		}

		[Export("taskTerminated:")]
		void TaskTerminated(NSNotification n)
		{
			Console.WriteLine("Task Terminated");
			task = null;
			startButton.State = NSCellStateValue.Off;
		}
    }
}
