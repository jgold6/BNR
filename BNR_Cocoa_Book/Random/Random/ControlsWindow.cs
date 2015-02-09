
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Random
{
    public partial class ControlsWindow : AppKit.NSWindow
    {
        #region Constructors

        // Called when created from unmanaged code
		public ControlsWindow(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
		public ControlsWindow(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}

