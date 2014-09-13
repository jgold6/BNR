// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace HeavyRotation
{
	[Register ("HeavyViewController")]
	partial class HeavyViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btn1 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btn2 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btn3 { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView image { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISlider slider { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (slider != null) {
				slider.Dispose ();
				slider = null;
			}

			if (image != null) {
				image.Dispose ();
				image = null;
			}

			if (btn1 != null) {
				btn1.Dispose ();
				btn1 = null;
			}

			if (btn2 != null) {
				btn2.Dispose ();
				btn2 = null;
			}

			if (btn3 != null) {
				btn3.Dispose ();
				btn3 = null;
			}
		}
	}
}
