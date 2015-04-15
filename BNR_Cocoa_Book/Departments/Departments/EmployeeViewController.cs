using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Departments
{
    public partial class EmployeeViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public EmployeeViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EmployeeViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EmployeeViewController() : base("EmployeeView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			Title = "Employees";
        }

        #endregion

        //strongly typed view accessor
        public new EmployeeView View
        {
            get
            {
                return (EmployeeView)base.View;
            }
        }
    }
}
