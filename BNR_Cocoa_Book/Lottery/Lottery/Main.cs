using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using System.Diagnostics;
using System.Collections.Generic;

namespace Lottery
{
    class MainClass
    {
        static void Main(string[] args)
        {
            NSApplication.Init();

			NSDate now = NSDate.Now;
			DateTime cNow = DateTime.UtcNow;
			NSCalendar cal = NSCalendar.CurrentCalendar;
			NSDateComponents weekComponents = new NSDateComponents();

			List<LotteryEntry> entries = new List<LotteryEntry>();
			for (int i = 0; i < 10; i++) {

				weekComponents.Week = i;
				NSDate iWeeksFromNow = cal.DateByAddingComponents(weekComponents, now, NSCalendarOptions.None);

				DateTime cWeeksFromNow = cNow.AddDays(i*7);

				LotteryEntry newEntry = new LotteryEntry(iWeeksFromNow, cWeeksFromNow);
				entries.Add(newEntry);
			}

			foreach (LotteryEntry entry in entries) {
				Debug.WriteLine("{0}", entry);
			}

			NSApplication.Main(args);


        }
    }
}

