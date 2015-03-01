﻿using System;
using Foundation;
using System.Collections.Generic;
using System.Timers;
using AppKit;

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

		List<string> letters;
		int lastIndex;

		long startTime;

		long elapsedTime {get; set;}

		long timeLimit {get;set;}

		long timerLimitInMilliseconds = 5000;

		public Timer Timer {get; set;}

		public NSColor userSelectedBgColor {get; set;}
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
			string alphabet = "abcdefghijklmnopqrstuvwxyz";//"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			letters = new List<string>();
			for (int i = 0; i < alphabet.Length; i++) {
				letters.Add(alphabet.Substring(i, 1));
			}
			rnd = new Random((int)DateTime.Now.Ticks);
			timeLimit = TimeSpan.TicksPerMillisecond * timerLimitInMilliseconds;
			userSelectedBgColor = NSColor.Orange;
		}
		#endregion

		#region - Lifecycle methods
		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			progressBar.MaxValue = (double)timeLimit;
			progressBar.DoubleValue = 0;
			ShowAnotherLetter();
			inLetterView.SetValueForKey(userSelectedBgColor, new NSString("BgColor"));
			colorWell.Activated += (object sender, EventArgs e) => {
				userSelectedBgColor = colorWell.Color;
			};
			colorTextField.EditingEnded += (object sender, EventArgs e) => {
				userSelectedBgColor = colorWell.Color;
			};
		}
		#endregion

		#region - Actions
		// Start and stop the timer
		[Action ("stopGo:")]
		void StopGo (Foundation.NSObject sender)
		{
			ResetElapsedTime();
			if (Timer == null) {
				Timer = new Timer(100);
				Timer.Elapsed += timer_Elapsed;
				Timer.Start();
				colorTextField.Enabled = false;
				colorWell.Enabled = false;
			}
			else {
				Timer.Stop();
				Timer.Elapsed -= timer_Elapsed;
				Timer = null;
				colorTextField.Enabled = true;
				colorWell.Enabled = true;
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
			if (inLetterView.Letter == outLetterView.Letter) {
				ShowAnotherLetter();
			}
			if (elapsedTime >= timeLimit) {
				AppKitFramework.NSBeep();
				InvokeOnMainThread(() => {
					inLetterView.SetValueForKey(userSelectedBgColor, new NSString("BgColor"));
					colorTextField.Enabled = false;
					colorWell.Enabled = false;
				});
				ShowAnotherLetter();
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

		void ShowAnotherLetter()
		{
			int x = lastIndex;
			while (x == lastIndex) {
				x = rnd.Next(letters.Count);
			}
			lastIndex = x;
			InvokeOnMainThread(() => {
				outLetterView.Letter = letters[x];
			});

			ResetElapsedTime();
		}
		#endregion
    }
}

