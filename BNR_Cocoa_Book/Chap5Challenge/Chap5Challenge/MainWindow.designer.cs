// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Chap5Challenge
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		AppKit.NSButton btnCountChar { get; set; }

		[Outlet]
		AppKit.NSTextField lblOutput { get; set; }

		[Outlet]
		AppKit.NSTextField textField { get; set; }

		[Action ("btnCountCharClicked:")]
		partial void btnCountCharClicked (Foundation.NSObject sender);
		
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
