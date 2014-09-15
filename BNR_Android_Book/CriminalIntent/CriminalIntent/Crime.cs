using System;

namespace CriminalIntent
{
    public class Crime
	{
		#region - Properties
		public string Id {get; private set;}
		public string Title {get; set;}
		#endregion

		#region - Constructors
		public Crime() : this(String.Empty)
		{
		}

		public Crime(string title)
        {
			Id = Guid.NewGuid().ToString().GetHashCode().ToString("x");
			Title = title;
        }
		#endregion
    }
}

