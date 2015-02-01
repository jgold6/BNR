using System;

using Foundation;
using AppKit;
using CoreGraphics;

namespace DrawingFun
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

		#region - Actions
		partial void ShowOpenPanel (Foundation.NSObject sender)
		{
			NSOpenPanel panel = NSOpenPanel.OpenPanel;
			panel.AllowedFileTypes = NSImage.ImageFileTypes;
			panel.BeginSheet(stretchView.Window, (result) => {
				if (result == 1) {
					StretchImage image = new StretchImage(panel.Url);
					stretchView.Image = image;
				}
				panel = null;
			});
		}
		#endregion
    }

}
