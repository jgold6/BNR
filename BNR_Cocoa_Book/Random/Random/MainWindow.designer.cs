// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace Random
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSView mainView { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton btnSeed { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton btnGenerate { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField textField { get; set; }

		[Action ("generate:")]
		partial void generate (MonoMac.Foundation.NSObject sender);

		[Action ("seed:")]
		partial void seed (MonoMac.Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (mainView != null) {
				mainView.Dispose ();
				mainView = null;
			}
			if (btnSeed != null) {
				btnSeed.Dispose ();
				btnSeed = null;
			}
			if (btnGenerate != null) {
				btnGenerate.Dispose ();
				btnGenerate = null;
			}
			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
