using System;

using Foundation;
using AppKit;

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
//			Window.Delegate = new WindowDelegate(stretchView);
        }

        public new MainWindow Window
        {
            get { return (MainWindow)base.Window; }
        }
    }

//	[global::Foundation.Register("WindowDelegate")]
//	public class WindowDelegate : NSWindowDelegate
//	{
//		StretchView stretchView;
//		bool mFirstLaunch;
//
//		public WindowDelegate(StretchView s)
//		{
//			stretchView = s;
//			mFirstLaunch = true;
//		}
//
//		public override void DidResize(NSNotification notification)
//		{
//			if (mFirstLaunch) {
//				stretchView.CreateRandomPath();
//				mFirstLaunch = false;
//			}
//		}
//	}
}
