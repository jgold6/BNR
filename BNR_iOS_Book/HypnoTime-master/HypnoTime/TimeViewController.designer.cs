// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace HypnoTime
{
	[Register ("TimeViewController")]
	partial class TimeViewController
	{
		[Outlet]
		UIKit.UIButton btnShowTime { get; set; }

		[Outlet]
		UIKit.UILabel lblTime { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnShowTime != null) {
				btnShowTime.Dispose ();
				btnShowTime = null;
			}

			if (lblTime != null) {
				lblTime.Dispose ();
				lblTime = null;
			}
		}
	}
}
