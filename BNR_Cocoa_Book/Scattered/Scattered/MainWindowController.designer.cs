// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Scattered
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		AppKit.NSTextField durationTextField { get; set; }

		[Outlet]
		AppKit.NSButton repositionButton { get; set; }

		[Outlet ("view")]
		AppKit.NSView View { get; set; }

		[Action ("repositionImages:")]
		partial void repositionImages (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (repositionButton != null) {
				repositionButton.Dispose ();
				repositionButton = null;
			}

			if (View != null) {
				View.Dispose ();
				View = null;
			}

			if (durationTextField != null) {
				durationTextField.Dispose ();
				durationTextField = null;
			}
		}
	}
}
