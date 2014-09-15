using System;

namespace CriminalIntent
{
	public class Crime : Java.Lang.Object
	{
		#region = member variables
		#endregion

		#region - Properties
		public string Id {get; private set;}
		public string Title {get; set;}
		public bool Solved {get; set;}
		public DateTime Date {get; private set;}
		#endregion

		#region - Constructors
		public Crime() : this(String.Empty)
		{
		}

		public Crime(string title)
        {
			Id = Guid.NewGuid().ToString().GetHashCode().ToString("x");
			Title = title;
			Date = DateTime.Now;
        }
		#endregion

		#region - overrides
		public override string ToString()
		{
			return string.Format("{0}", Title);
		}
		#endregion
    }
}

