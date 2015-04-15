using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace Departments
{
    public partial class DepartmentViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public DepartmentViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public DepartmentViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public DepartmentViewController() : base("DepartmentView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
			Title = "Departments";
        }

        #endregion

        //strongly typed view accessor
        public new DepartmentView View
        {
            get
            {
                return (DepartmentView)base.View;
            }
        }
    }
}
