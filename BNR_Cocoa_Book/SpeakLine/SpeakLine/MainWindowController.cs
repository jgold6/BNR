
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
		NSSpeechSynthesizer speechSynth;
		string[] voices;

		TodoTableViewSource todoTableViewSource;

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
			speechSynth = new NSSpeechSynthesizer();
			voices = NSSpeechSynthesizer.AvailableVoices;
        }

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();

			speechSynth.WeakDelegate = this;

			tableView.WeakDelegate = this;
			tableView.WeakDataSource = this;

			string defaultVoice = NSSpeechSynthesizer.DefaultVoice;
			int defaultRow = -1;
			for (int i = 0; i < voices.Count<string>(); i++) {
				if (voices[i] == defaultVoice) {
					defaultRow = i;
					break;
				}
			}
			NSIndexSet indices = NSIndexSet.FromIndex(defaultRow);
			tableView.SelectRows(indices, false);
			tableView.ScrollRowToVisible(defaultRow);

			this.Window.WeakDelegate = this;

//			textField.Activated += (object sender, EventArgs e) => {
//				btnSpeak.PerformClick(textField);
//			};

			// To do
			todoTableViewSource = new TodoTableViewSource(new WeakReference(this));
			tableViewTodo.Source = todoTableViewSource;

			todoTextField.Activated += (object sender, EventArgs e) => {
				btnAddTodo.PerformClick(todoTextField);
			};

		}

        #endregion

		partial void btnSpeakHandler (MonoMac.Foundation.NSObject sender)
		{
			string value = textField.StringValue;
			// Is the string 0 length?
			if (value.Length == 0) {
				return;
			}
			speechSynth.StartSpeakingString(value);

			btnStop.Enabled = true;
			btnSpeak.Enabled = false;
			tableView.Enabled = false;
			textField.Enabled = false;
		}

		partial void btnStopHandler (MonoMac.Foundation.NSObject sender)
		{
			speechSynth.StopSpeaking(NSSpeechBoundary.hWord);
		}

		partial void btnAddTodoHandler (MonoMac.Foundation.NSObject sender)
		{
			if (todoTextField.StringValue != "") {
				if (btnAddTodo.Title == "Add") {
					todoTableViewSource.todoItems.Add(todoTextField.StringValue);
					tableViewTodo.ReloadData();
					todoTextField.StringValue = "";
				}
				else if (btnAddTodo.Title == "Edit") {
					todoTableViewSource.todoItems.RemoveAt(tableViewTodo.SelectedRow);
					todoTableViewSource.todoItems.Insert(tableViewTodo.SelectedRow, todoTextField.StringValue);
					tableViewTodo.ReloadData();
					todoTextField.StringValue = "";
					btnAddTodo.Title = "Add";
				}
			}
		}

		#region - NSSpeechSynthesizer Weak Delegate Methods
		[Export("speechSynthesizer:didFinishSpeaking:")]
		public void DidFinishSpeaking(NSSpeechSynthesizer sender, bool finishedSpeaking)
		{
//			Console.WriteLine("Finished Speaking = {0}", finishedSpeaking);
			btnStop.Enabled = false;
			btnSpeak.Enabled = true;
			tableView.Enabled = true;
			textField.Enabled = true;

		}

		#endregion

		#region - NSTableView Weak Delegate and DataSource Methods
		[Export("numberOfRowsInTableView:")]
		public int GetRowCount(NSTableView tv)
		{
			return voices.Count<string>();
		}

		[Export("tableView:objectValueForTableColumn:row:")]
		public NSObject GetObjectValue(NSTableView tableView, NSTableColumn tableColumn, int row)
		{
			NSDictionary dict = NSSpeechSynthesizer.AttributesForVoice(voices[row]);
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
			int row = tableView.SelectedRow;
			if (row == -1)
				return;
			string selectedVoice = voices[row];
			speechSynth.Voice = selectedVoice;
		}

		#endregion

        //strongly typed window accessor
        public new MainWindow Window
        {
            get
            {
                return (MainWindow)base.Window;
            }
        }

		[Export("windowWillResize:toSize:")]
		public System.Drawing.SizeF WillResize(NSWindow sender, System.Drawing.SizeF toFrameSize)
		{
			float newWidth = toFrameSize.Width < 690 ? 690 : toFrameSize.Width;
			float newHieght = toFrameSize.Height < 500 ? 500 : toFrameSize.Height;
			return new SizeF(newWidth, newHieght);
		}
    }

	public class TodoTableViewSource : NSTableViewSource
	{
		public List<string> todoItems;
		WeakReference mainWindowController;

		public TodoTableViewSource(WeakReference mwc)
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

		public override void SelectionDidChange(NSNotification notification)
		{
			MainWindowController mwc = (MainWindowController)mainWindowController.Target;
			int selectedRow = mwc.tableViewTodo.SelectedRow;
			if (selectedRow != -1) {
				mwc.btnAddTodo.Title = "Edit";
				mwc.todoTextField.StringValue = todoItems[selectedRow];
				mwc.todoTextField.BecomeFirstResponder();
			}
		}
	}
}

