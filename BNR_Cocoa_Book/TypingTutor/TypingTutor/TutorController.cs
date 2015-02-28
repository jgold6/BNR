using System;
using Foundation;
using System.Collections.Generic;
using System.Timers;
using AppKit;

namespace TypingTutor
{
	[Register("TutorController")]
    public class TutorController : NSObject
    {
		Random rnd;

		[Outlet("inLetterView")]
		public BigLetterView inLetterView { get; set; }
		[Outlet("outLetterView")]
		public BigLetterView outLetterView { get; set; }
		[Outlet("progressBar")]
		public NSProgressIndicator progressBar { get; set; }

		List<string> letters;
		int lastIndex;

		long startTime;

		long elapsedTime {get; set;}

		long timeLimit {get;set;}

		long timerIntervalInMilliseconds = 5000;

		Timer timer;

		[Action ("stopGo:")]
		void StopGo (Foundation.NSObject sender)
		{
			ResetElapsedTime();
			if (timer == null) {
				Console.WriteLine("Starting");
				timer = new Timer(100);
				timer.Elapsed += timer_Elapsed;
				timer.Start();
			}
			else {
				timer.Stop();
				timer = null;
			}
		}

		void timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			Console.WriteLine("Elapsed");
			if (inLetterView.Letter == outLetterView.Letter) {
				ShowAnotherLetter();
			}
			UpdateElapsedTime();
			if (elapsedTime >= timeLimit) {
				AppKitFramework.NSBeep();
				ShowAnotherLetter();
			}
		}

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
			string alphabet = "abcdefghijklmnopqrstuvwxyz";
			letters = new List<string>();
			for (int i = 0; i < alphabet.Length; i++) {
				letters.Add(alphabet.Substring(i, 1));
			}

			rnd = new Random((int)DateTime.Now.Ticks);
			timeLimit = TimeSpan.TicksPerMillisecond * timerIntervalInMilliseconds;
		}

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			progressBar.MaxValue = (double)timeLimit;
			progressBar.DoubleValue = 0;
			inLetterView.BgColor = NSColor.Green;
			ShowAnotherLetter();
		}
    }
}

