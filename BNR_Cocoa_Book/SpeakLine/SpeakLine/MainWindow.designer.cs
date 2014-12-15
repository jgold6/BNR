// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace SpeakLine
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton btnSpeak { get; set; }

		[Outlet]
		MonoMac.AppKit.NSButton btnStop { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTableView tableView { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField textField { get; set; }

		[Action ("btnSpeakHandler:")]
		partial void btnSpeakHandler (MonoMac.Foundation.NSObject sender);

		[Action ("btnStopHandler:")]
		partial void btnStopHandler (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnSpeak != null) {
				btnSpeak.Dispose ();
				btnSpeak = null;
			}

			if (btnStop != null) {
				btnStop.Dispose ();
				btnStop = null;
			}

			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}

			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
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
