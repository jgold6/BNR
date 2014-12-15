
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Drawing;

namespace SpeakLine
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
    {
		#region - Member Variables
		NSSpeechSynthesizer mSpeechSynth;
		string[] mVoices;
		#endregion

		#region - Public Properties
		//strongly typed window accessor
		public new MainWindow Window{get {return (MainWindow)base.Window;}}
		public PhrasesTableViewSource PhrasesTableViewSource {get; private set;}
		#endregion

        #region Constructors
        // Called when created from unmanaged code
        public MainWindowController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        
        // Call to load from the XIB/NIB file
        public MainWindowController() : base("MainWindow")
        {
            Initialize();
        }
        
        // Shared initialization code
        void Initialize()
        {
			mSpeechSynth = new NSSpeechSynthesizer();
			mVoices = NSSpeechSynthesizer.AvailableVoices;
        }
		#endregion

		#region - Lifecycle methods
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			this.Window.WeakDelegate = this;

			mSpeechSynth.WeakDelegate = this;

			// Voices
			voicesTableView.WeakDelegate = this;
			voicesTableView.WeakDataSource = this;

			// Phrases
			PhrasesTableViewSource = new PhrasesTableViewSource(new WeakReference(this));
			phrasesTableView.Source = PhrasesTableViewSource;
			phrasesTableView.mainWindowController = new WeakReference(this);

			// Select row for default voice in voicesTableView
			string defaultVoice = NSSpeechSynthesizer.DefaultVoice;
			int defaultRow = -1;
			for (int i = 0; i < mVoices.Count<string>(); i++) {
				if (mVoices[i] == defaultVoice) {
					defaultRow = i;
					break;
				}
			}
			NSIndexSet indices = NSIndexSet.FromIndex(defaultRow);
			voicesTableView.SelectRows(indices, false);
			voicesTableView.ScrollRowToVisible(defaultRow);

			// Handles when return is pressed while editing or textField loses focus
			textField.Activated += (object sender, EventArgs e) => {
				// If the add button is enabled, then add this item to the list
				if (btnAddPhrase.Enabled) {
					btnAddPhrase.PerformClick(textField);
				}
			};
			textField.Changed += (object sender, EventArgs e) => {
				if (phrasesTableView.SelectedRow > -1) {
					string text = textField.StringValue;
					phrasesTableView.DeselectAll(textField);
					textField.StringValue = text;
					textField.CurrentEditor.SelectedRange = new NSRange(text.Length, 0);
					btnAddPhrase.Enabled = true;
				}
			};
		}
        #endregion

		#region - Actions from XIB
		partial void btnSpeakHandler (MonoMac.Foundation.NSObject sender)
		{
			string value = textField.StringValue;
			// Is the string 0 length?
			if (value.Length == 0) {
				return;
			}
			mSpeechSynth.StartSpeakingString(value);

			btnStop.Enabled = true;
			btnSpeak.Enabled = false;
			voicesTableView.Enabled = false;
			textField.Enabled = false;
		}

		partial void btnStopHandler (MonoMac.Foundation.NSObject sender)
		{
			mSpeechSynth.StopSpeaking(NSSpeechBoundary.hWord);
		}

		partial void btnAddPhraseHandler (MonoMac.Foundation.NSObject sender)
		{
			if (textField.StringValue != "") {
				PhrasesTableViewSource.todoItems.Add(textField.StringValue);
				phrasesTableView.ReloadData();
				textField.StringValue = "";
			}
		}

		partial void btnClearHandler (MonoMac.Foundation.NSObject sender)
		{
			textField.StringValue = "";
			phrasesTableView.DeselectAll(btnClear);
			textField.BecomeFirstResponder();
			btnAddPhrase.Enabled = true;
		}
		#endregion

		#region - NSSpeechSynthesizer Weak Delegate Methods
		[Export("speechSynthesizer:didFinishSpeaking:")]
		public void DidFinishSpeaking(NSSpeechSynthesizer sender, bool finishedSpeaking)
		{
			btnStop.Enabled = false;
			btnSpeak.Enabled = true;
			voicesTableView.Enabled = true;
			textField.Enabled = true;
		}
		#endregion

		#region - voicesTableView Weak Delegate and DataSource Methods
		[Export("numberOfRowsInTableView:")]
		public int GetRowCount(NSTableView tv)
		{
			return mVoices.Count<string>();
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			NSDictionary dict = NSSpeechSynthesizer.AttributesForVoice(mVoices[row]);
			// See all of the keys and Value types
//			var keys = dict.Keys;
//			var values = dict.Values;
//			for (int i = 0; i < dict.Count; i++) {
//				if (keys[i].ToString() != "VoiceIndividuallySpokenCharacters" &&  keys[i].ToString() != "VoiceSupportedCharacters")
//					Console.WriteLine("Key {0} = {1}, Value = {2}", i, keys[i], values[i].GetType());
//			}

			var name = dict.ObjectForKey(new NSString("VoiceName"));
			var age = dict.ObjectForKey(new NSString("VoiceAge"));
			var lang = dict.ObjectForKey(new NSString("VoiceLanguage"));
			NSString full = new NSString(String.Format("{0}, Age {1}, Language {2}", name, age, lang));

			return full;
		}

		[Export("tableViewSelectionDidChange:")]
		public void SelectionDidChange(NSNotification notification)
		{
			int row = voicesTableView.SelectedRow;
			if (row == -1)
				return;
			string selectedVoice = mVoices[row];
			mSpeechSynth.Voice = selectedVoice;
		}
		#endregion

		#region - Window WeakDelegate methods
		[Export("windowWillResize:toSize:")]
		public System.Drawing.SizeF WillResize(NSWindow sender, System.Drawing.SizeF toFrameSize)
		{
			float newWidth = toFrameSize.Width < 820 ? 820 : toFrameSize.Width;
			float newHieght = toFrameSize.Height < 250 ? 250 : toFrameSize.Height;
			return new SizeF(newWidth, newHieght);
		}
		#endregion
    }

	#region - PhrasesTableViewSource class
	public class PhrasesTableViewSource : NSTableViewSource
	{
		public List<string> todoItems;
		WeakReference mainWindowController;

		public PhrasesTableViewSource(WeakReference mwc)
		{
			todoItems = new List<string>();
			mainWindowController = mwc;
		}

		public override int GetRowCount(NSTableView tableView)
		{
			return todoItems.Count;
		}

		public override NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			return new NSString(todoItems[row]);
		}

		public override void ObjectDidEndEditing(NSObject editor)
		{
			base.ObjectDidEndEditing(editor);
			NSTextField ed = (NSTextField)editor;
			Console.WriteLine("Edited Row = {0}", ed.StringValue);
		}

		public override void SelectionDidChange(NSNotification notification)
		{
			MainWindowController mwc = (MainWindowController)mainWindowController.Target;
			int selectedRow = mwc.phrasesTableView.SelectedRow;
			if (selectedRow != -1) {
				mwc.textField.StringValue = todoItems[selectedRow];
				mwc.btnAddPhrase.Enabled = false;
			}
			else {
				mwc.phrasesTableView.DeselectRow(selectedRow);
				mwc.textField.StringValue = "";
				mwc.textField.BecomeFirstResponder();
				mwc.btnAddPhrase.Enabled = true;
			}
		}
	}
	#endregion

	#region - PhrasesTableView class
	[Register("PhrasesTableView")]
	public class PhrasesTableView : NSTableView
	{
		public WeakReference mainWindowController {get; set;}

		public PhrasesTableView(IntPtr handle) : base(handle)
		{}

		// Allows editing directly in cell
		public override void TextDidEndEditing(NSNotification notification)
		{
			base.TextDidEndEditing(notification);
			int row = this.SelectedRow;
			MainWindowController mwc = (MainWindowController)mainWindowController.Target;
			NSTextView tv = (NSTextView)notification.Object;
			if (tv.Value !="") {
				mwc.PhrasesTableViewSource.todoItems[row] = tv.Value;
				mwc.btnAddPhrase.Enabled = false;
			}
			else {
				mwc.PhrasesTableViewSource.todoItems.RemoveAt(row);
				mwc.phrasesTableView.DeselectAll(this);
				mwc.btnAddPhrase.Enabled = true;
			}
			mwc.textField.StringValue = tv.Value;
			mwc.phrasesTableView.ReloadData();
		}
	}
	#endregion
}

