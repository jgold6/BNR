using System;
using Foundation;
using System.Collections.Generic;
using System.Timers;
using AppKit;
using System.IO;
using System.Linq;

namespace TypingTutor
{
	[Register("TutorController")]
	public class TutorController : NSObject, INSTextFieldDelegate
    {
		#region - Member variables and outlets
		Random rnd;

		[Outlet("inLetterView")]
		public BigLetterView inLetterView { get; set; } // Where to type input
		[Outlet("outLetterView")]
		public BigLetterView outLetterView { get; set; } // SHows the letter to type
		[Outlet("progressBar")]
		public NSProgressIndicator progressBar { get; set; }
		[Outlet("speedSheet")]
		public NSWindow speedSheet { get; set; }
		[Outlet("slider")]
		public NSSlider slider { get; set; }
		[Outlet("colorTextField")]
		public NSTextField colorTextField { get; set; }
		[Outlet("colorWell")]
		public NSColorWell colorWell { get; set; }
		[Outlet("lblCorrect")]
		public NSTextField lblCorrect { get; set; }
		[Outlet("lblIncorrect")]
		public NSTextField lblIncorrect { get; set; }
		[Outlet("segControl")]
		public NSSegmentedControl segControl { get; set; }

		// Flag to choose Sentences or Random Letters - initialized to false in Initialize();
		public bool Sentences;

		List<string> letters;
		int lastLetterIndex;

		List<string> sentences;
		string currentSentence;
		int currentSentenceIndex;
		public bool keyPressedFlag {get; set;}

		long startTime;

		long elapsedTime {get; set;}

		long timeLimit {get;set;}

		long timerLimitInMilliseconds = 3000;

		public Timer Timer {get; set;}

		public NSColor userSelectedBgColor {get; set;}

		public nint CorrectLetters {get; set;}
		public nint IncorrectLetters {get; set;}
		#endregion

		#region - Constructors
		public TutorController()
		{
			Initialize();
		}

		public TutorController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		void Initialize()
		{
			rnd = new Random((int)DateTime.Now.Ticks);
			Sentences = false;
			// Random letters
			string alphabet = "abcdefghijklmnopqrstuvwxyz";//"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			letters = new List<string>();
			for (int i = 0; i < alphabet.Length; i++) {
				letters.Add(alphabet.Substring(i, 1));
			}

			// Sentences
			sentences = new List<string>();
			sentences = File.ReadLines("quotes.txt").ToList();

			timeLimit = TimeSpan.TicksPerMillisecond * timerLimitInMilliseconds;
			userSelectedBgColor = NSColor.Yellow;
		}
		#endregion

		#region - Lifecycle methods
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			progressBar.MaxValue = (double)timeLimit;
			progressBar.DoubleValue = 0;

			if (Sentences) {
				// Sentences
				NextSentence();
				ShowNextLetter();
			}
			else {
				// Random Letters;
				ShowAnotherLetter();
			}

			inLetterView.SetValueForKey(userSelectedBgColor, new NSString("BgColor"));
			outLetterView.SetValueForKey(userSelectedBgColor, new NSString("BgColor"));
			CorrectLetters = 0;
			IncorrectLetters = 0;
			lblCorrect.StringValue = CorrectLetters.ToString();
			lblIncorrect.StringValue = IncorrectLetters.ToString();

//			colorTextField.EditingEnded += (object sender, EventArgs e) => {
//				userSelectedBgColor = colorWell.Color;
//				outLetterView.BgColor = colorWell.Color;
//			};

			// ColorWell has issues too, but harder to reproduce. Crash log in notepad, Xamarin folder -> Scratchpad
//			colorWell.Activated += (object sender, EventArgs e) => {
//				userSelectedBgColor = colorWell.Color;
//				outLetterView.BgColor = colorWell.Color;
//			};

			// Native crash - file bug report. go back and forth to repro, especially while running the typing tutor, or going back to "Random Letters
			// after stopping. rfe
//			segControl.Activated += (object sender, EventArgs e) => {
//				Sentences = segControl.SelectedSegment == 1;
//				if (Sentences) {
//					// Sentences
//					NextSentence();
//					ShowNextLetter();
//				}
//				else {
//					// Random Letters;
//					ShowAnotherLetter();
//				}
//			};
		}
		#endregion

		#region - Actions
		[Export("controlTextDidEndEditing:")]
		public void EditingEnded(Foundation.NSNotification notification)
		{
			userSelectedBgColor = colorWell.Color;
			outLetterView.BgColor = colorWell.Color;
		}
		// Color Well control
		[Action ("colorWellValueChanged:")]
		void ColorWellValueChanged (Foundation.NSObject sender)
		{
			userSelectedBgColor = colorWell.Color;
			outLetterView.BgColor = colorWell.Color;
		}

		// Segmented control
		[Action ("valueChanged:")]
		void ValueChanged (Foundation.NSObject sender)
		{
			Sentences = segControl.SelectedSegment == 1;
			if (Sentences) {
				// Sentences
				NextSentence();
				ShowNextLetter();
			}
			else {
				// Random Letters;
				ShowAnotherLetter();
			}
		}

		// Start and stop the timer
		[Action ("stopGo:")]
		void StopGo (Foundation.NSObject sender)
		{
			ResetElapsedTime();
			if (Timer == null) {
				Timer = new Timer(100);
				Timer.Elapsed += timer_Elapsed;
				Timer.Start();
//				colorTextField.Enabled = false;
//				colorWell.Enabled = false;
//				segControl.Enabled = false;
				CorrectLetters = 0;
				IncorrectLetters = 0;
				lblCorrect.StringValue = CorrectLetters.ToString();
				lblIncorrect.StringValue = IncorrectLetters.ToString();
			}
			else {
				Timer.Stop();
				Timer.Elapsed -= timer_Elapsed;
				Timer = null;
//				colorTextField.Enabled = true;
//				colorWell.Enabled = true;
//				segControl.Enabled = true;
			}
		}

		[Action ("showSpeedSheet:")]
		void ShowSpeedSheet (Foundation.NSObject sender)
		{
			slider.IntValue = (int)timerLimitInMilliseconds/1000;

			NSApplication.SharedApplication.BeginSheet(speedSheet, inLetterView.Window);

			// Not needed, just wanted to test this overload of BeginSheet.
//			NSString test = new NSString("test");
//			NSApplication.SharedApplication.BeginSheet(speedSheet, inLetterView.Window, this, new ObjCRuntime.Selector("didEnd:returnCode:test:"), test.Handle);
		}

		// Not needed, just wanted to test the overload of BeginSheet.
//		[Export("didEnd:returnCode:test:")]
//		public void DidEnd(NSWindow sheet, int returnCode, IntPtr test)
//		{
//			var retest = NSString.FromHandle(test);
//			Console.WriteLine("Did it work?: {0}", retest);
//		}

		[Action ("endSpeedSheet:")]
		void EndSpeedSheet (Foundation.NSObject sender)
		{
			timerLimitInMilliseconds = slider.IntValue *1000;
			timeLimit = TimeSpan.TicksPerMillisecond * timerLimitInMilliseconds;
			progressBar.MaxValue = (double)timeLimit;
			//progressBar.DoubleValue = 0;
			NSApplication.SharedApplication.EndSheet(speedSheet);
			speedSheet.OrderOut(sender);
		}



		[Export("control:didFailToFormatString:errorDescription:")]
		public bool DidFailToFormatString(AppKit.NSControl control, string str, string error)
		{
			Console.WriteLine("Failed to format string {0}: {1}", str, error);
			return false;
		}
		#endregion

		#region - Timer Delegate
		void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			UpdateElapsedTime();
			if (inLetterView.Letter == outLetterView.Letter && keyPressedFlag) {
				if (Sentences) {
					// Sentences
					ShowNextLetter();
				}
				else {
				// Random Letters
					ShowAnotherLetter();
				}
			}
			if (elapsedTime >= timeLimit) {
				AppKitFramework.NSBeep();
				InvokeOnMainThread(() => {
					inLetterView.SetValueForKey(userSelectedBgColor, new NSString("BgColor"));
//					colorTextField.Enabled = false;
//					colorWell.Enabled = false;
				});

				if (Sentences) {
					// Sentences
					ShowNextLetter();
				}
				else {
					// Random Letters
					ShowAnotherLetter();
				}
			}
		}
		#endregion

		#region - Methods
		void ResetElapsedTime()
		{
			startTime = DateTime.Now.Ticks;
			UpdateElapsedTime();
		}

		void UpdateElapsedTime()
		{
			elapsedTime = DateTime.Now.Ticks - startTime;
			InvokeOnMainThread(() => {
				progressBar.DoubleValue = (double)elapsedTime;
			});
		}

		// Random Letters
		void ShowAnotherLetter()
		{
			int x = lastLetterIndex;
			while (x == lastLetterIndex) {
				x = rnd.Next(letters.Count);
			}
			lastLetterIndex = x;
			InvokeOnMainThread(() => {
				outLetterView.Letter = letters[x];
			});

			ResetElapsedTime();
		}

		// Sentences
		void NextSentence()
		{
			currentSentence = sentences[rnd.Next(sentences.Count)];
			currentSentenceIndex = 0;
		}
		void ShowNextLetter()
		{
			if (currentSentenceIndex < currentSentence.Length) {
				keyPressedFlag = false;
			}
			else {
				NextSentence();
			}
			InvokeOnMainThread(() => {
				outLetterView.Letter = currentSentence.Substring(currentSentenceIndex, 1);
			});
			currentSentenceIndex++;

			ResetElapsedTime();
		}
		#endregion
    }
}

