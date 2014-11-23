using System;
using Java.Util;

namespace RunTracker
{
    public class Run
    {
		DateTime mStartTimeUTC;

        public Run()
        {
			mStartTimeUTC = DateTime.UtcNow;
        }

		public DateTime StartDate {
			get {return mStartTimeUTC;}
			set {mStartTimeUTC = value;}
		}

		public int GetDurationSeconds(DateTime endTime)
		{
			int seconds = (int)Math.Round((endTime - mStartTimeUTC).TotalSeconds);

			return seconds;
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

