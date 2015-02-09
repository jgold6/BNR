
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Chap5Challenge
{
    public partial class MainWindowController : AppKit.NSWindowController
    {
        #region Constructors

        // Called when created from unmanaged code
        public MainWindowController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
        // Call to load from the XIB/NIB file
        public MainWindowController() : base("MainWindow")
        {
            Initialize();
        }
        
        // Shared initialization code
        void Initialize()
        {
        }

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}

        #endregion

		partial void btnCountCharClicked (Foundation.NSObject sender)
		{
			lblOutput.StringValue = String.Format("'{0}' has {1} characters", textField.StringValue, textField.StringValue.Length);
			textField.StringValue = "";
		}

        //strongly typed window accessor
        public new MainWindow Window
        {
            get
            {
                return (MainWindow)base.Window;
            }
        }
    }
}

