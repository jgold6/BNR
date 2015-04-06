using System;

using Foundation;
using AppKit;
using System.Threading.Tasks;
using WebKit;
using CoreGraphics;
using ObjCRuntime;

namespace RanchForecast
{
	public partial class MainWindowController : NSWindowController, INSTableViewSource
    {
		ScheduleFetcher scheduleFetcher;
		NSPanel webPanel;

        public MainWindowController(IntPtr handle) : base(handle)
        {
			Initialize();
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
			Initialize();
        }

        public MainWindowController() : base("MainWindow")
        {
			Initialize();
        }

		void Initialize()
		{
			
		}

        public override async void AwakeFromNib()
        {
            base.AwakeFromNib();
			scheduleFetcher = new ScheduleFetcher();
			await scheduleFetcher.FetchClassesAsync();
			tableView.ReloadData();
			tableView.DoubleClick += TableView_DoubleClick;
        }

        void TableView_DoubleClick (object sender, EventArgs e)
        {
			NSTableView tv = sender as NSTableView;
			ScheduledClass c = scheduleFetcher.ScheduledClasses[(int)tv.ClickedRow];

			webPanel = new NSPanel();
			webPanel.SetContentSize(new CGSize(Window.ContentView.Frame.Size.Width, 500.0f));
			WebView webView = new WebView(new CGRect(0.0f, 0.0f, Window.ContentView.Frame.Size.Width, 500.0f), "", "");
			webPanel.ContentView.AddSubview(webView);

			NSButton closebutton = new NSButton(new CGRect(webPanel.Frame.Width/2 - 62.0f, 0.0f, 100.0f, 25.0f));
			closebutton.Title = "Close";
			closebutton.BezelStyle = NSBezelStyle.Rounded;
			closebutton.Target = this;
			closebutton.Action= new Selector("closePanel");
			webPanel.DefaultButtonCell = closebutton.Cell;
			webPanel.ContentView.AddSubview(closebutton);
			webView.MainFrameUrl = c.Href;
			Window.BeginSheet(webPanel, (i) => {

			});

			//NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl(c.Href));
        }

		[Export("closePanel")]
		public void ClosePanel () 
		{
			Window.EndSheet(webPanel);
			webPanel.Dispose();
			webPanel = null;
		}

        public new MainWindow Window
        {
            get { return (MainWindow)base.Window; }
        }

		[Export("numberOfRowsInTableView:")]
		public System.nint GetRowCount(AppKit.NSTableView tableView)
		{
			return scheduleFetcher.ScheduledClasses.Count;
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public Foundation.NSObject GetObjectValue(AppKit.NSTableView tableView, AppKit.NSTableColumn tableColumn, System.nint row)
		{
			ScheduledClass cl = scheduleFetcher.ScheduledClasses[(int)row];

			if (tableColumn.Identifier != "Begin") {
				return cl.ValueForKey(new NSString(tableColumn.Identifier));
			}
			else {
				DateTime date = DateTime.Parse(cl.ValueForKey(new NSString(tableColumn.Identifier)).ToString()).ToUniversalTime();
				return new NSString(date.ToLongDateString());
			}
		}
    }
}
