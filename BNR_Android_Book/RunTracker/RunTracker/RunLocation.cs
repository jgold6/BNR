using System;
using SQLite;

namespace RunTracker
{
	[Table("RunLocations")]
    public class RunLocation
    {
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id {get;set;}

		public int RunId {get;set;}

		public double Latitude {get; set;}

		public double Longitude {get; set;}

		public double Altitude {get; set;}

		public DateTime Time {get; set;}
    }
}

