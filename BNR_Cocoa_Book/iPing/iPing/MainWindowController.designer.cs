// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace iPing
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		AppKit.NSTextField hostField { get; set; }

		[Outlet]
		AppKit.NSTextView outputView { get; set; }

		[Outlet]
		AppKit.NSButton startButton { get; set; }

		[Action ("startStopPing:")]
		partial void startStopPing (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (hostField != null) {
				hostField.Dispose ();
				hostField = null;
			}

			if (outputView != null) {
				outputView.Dispose ();
				outputView = null;
			}

			if (startButton != null) {
				startButton.Dispose ();
				startButton = null;
			}
		}
	}
}
