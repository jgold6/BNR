
using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace KvcFun
{
    public partial class MainWindowController : AppKit.NSWindowController
    {
		int _fido;

		[Export("fido")]
		int Fido {
			get
			{
				Console.WriteLine("fido is returning {0}", _fido);
				return _fido;
			}
			set
			{
				Console.WriteLine("setFido is called with {0}", value);
				_fido = value;
			}
		}



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
			this.SetValueForKey(new NSNumber(12), new NSString("fido"));
			NSNumber n = (NSNumber)this.ValueForKey(new NSString("fido"));
			Console.WriteLine("fido = {0}", n);

        }

        #endregion

		partial void btnIncFido (Foundation.NSObject sender)
		{
			// Set fido using SetValueForKey - is reflected in the slider and label
//			this.SetValueForKey(new NSNumber(++_fido), new NSString("fido"));
			this.WillChangeValue("fido");
			_fido++;
			Console.WriteLine("fido is now {0}", _fido);
			this.DidChangeValue("fido");
		}

		partial void btnDecFido (Foundation.NSObject sender)
		{
			// Set fido using SetValueForKey - is reflected in the slider and label
//			this.SetValueForKey(new NSNumber(--_fido), new NSString("fido"));
			this.WillChangeValue("fido");
			_fido--;
			Console.WriteLine("fido is now {0}", _fido);
			this.DidChangeValue("fido");
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

