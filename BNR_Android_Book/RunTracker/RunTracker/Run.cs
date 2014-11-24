using System;
using SQLite;

namespace RunTracker
{
	[Table("Runs")]
    public class Run
    {
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id {get; set;}

		public DateTime StartDate {get; set;}

        public Run()
        {
			StartDate = DateTime.UtcNow;
        }

		public int GetDurationSeconds(DateTime endTime)
		{
			int seconds = (int)Math.Round((endTime - StartDate).TotalSeconds);

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

