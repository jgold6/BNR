// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace Chap5Challenge
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton btnCountChar { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField lblOutput { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField textField { get; set; }

		[Action ("btnCountCharClicked:")]
		partial void btnCountCharClicked (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}

			if (btnCountChar != null) {
				btnCountChar.Dispose ();
				btnCountChar = null;
			}

			if (lblOutput != null) {
				lblOutput.Dispose ();
				lblOutput = null;
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
