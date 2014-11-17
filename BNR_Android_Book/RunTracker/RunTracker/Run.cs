using System;
using Java.Util;

namespace RunTracker
{
    public class Run
    {
		Date mStartDate;

        public Run()
        {
			mStartDate = new Date();
        }

		public Date StartDate {
			get {return mStartDate;}
			set {mStartDate = value;}
		}

		public int GetDurationSeconds(long endMillis)
		{
			return (int)((endMillis - mStartDate.Time) / 1000);
		}

		public static string FormatDuration(int durationSeconds)
		{
			int seconds = durationSeconds % 60;
			int minutes = ((durationSeconds - seconds) /60)%60;
			int hours = (durationSeconds - (minutes *60) - seconds) / 3600;
			return String.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
		}
    }
}

