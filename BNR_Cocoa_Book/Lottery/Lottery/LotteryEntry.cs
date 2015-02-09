using System;
using Foundation;

namespace Lottery
{
    public class LotteryEntry
    {
		static Random _random = new Random();

		public NSDate entryDate {get; set;}
		public DateTime EntryDate {get; set;}

		public int firstNumber {get; private set;}
		public int secondNumber {get; private set;}

		public LotteryEntry(NSDate iDate, DateTime cDate)
        {
			entryDate = iDate;
			EntryDate = cDate;
			firstNumber = _random.Next(1, 101);
			secondNumber = _random.Next(1, 101);
		}

		public override string ToString()
		{
			NSDateFormatter df = new NSDateFormatter();
			df.TimeStyle = NSDateFormatterStyle.None;
			df.DateStyle = NSDateFormatterStyle.Full;
			return string.Format("NSDate:   {0}\nDateTime: {1} = {2} and {3}", df.StringFor(entryDate), EntryDate.ToLocalTime().ToLongDateString(), firstNumber, secondNumber);
		}
    }
}

