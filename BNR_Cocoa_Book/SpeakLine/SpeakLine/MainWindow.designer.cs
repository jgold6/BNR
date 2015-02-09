// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SpeakLine
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		public AppKit.NSButton btnAddPhrase { get; set; }

		[Outlet]
		AppKit.NSButton btnClear { get; set; }

		[Outlet]
		AppKit.NSButton btnSpeak { get; set; }

		[Outlet]
		AppKit.NSButton btnStop { get; set; }

		[Outlet]
		public SpeakLine.PhrasesTableView phrasesTableView { get; private set; }

		[Outlet]
		public AppKit.NSTextField textField { get; private set; }

		[Outlet]
		AppKit.NSTableView voicesTableView { get; set; }

		[Action ("btnAddPhraseHandler:")]
		partial void btnAddPhraseHandler (Foundation.NSObject sender);

		[Action ("btnClearHandler:")]
		partial void btnClearHandler (Foundation.NSObject sender);

		[Action ("btnSpeakHandler:")]
		partial void btnSpeakHandler (Foundation.NSObject sender);

		[Action ("btnStopHandler:")]
		partial void btnStopHandler (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (btnAddPhrase != null) {
				btnAddPhrase.Dispose ();
				btnAddPhrase = null;
			}

			if (btnClear != null) {
				btnClear.Dispose ();
				btnClear = null;
			}

			if (btnSpeak != null) {
				btnSpeak.Dispose ();
				btnSpeak = null;
			}

			if (btnStop != null) {
				btnStop.Dispose ();
				btnStop = null;
			}

			if (phrasesTableView != null) {
				phrasesTableView.Dispose ();
				phrasesTableView = null;
			}

			if (textField != null) {
				textField.Dispose ();
				textField = null;
			}

			if (voicesTableView != null) {
				voicesTableView.Dispose ();
				voicesTableView = null;
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
