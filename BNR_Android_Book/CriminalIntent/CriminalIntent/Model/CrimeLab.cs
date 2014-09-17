using System;
using Android.Content;
using System.Collections.Generic;
using System.Linq;

namespace CriminalIntent
{
    public  class CrimeLab
    {
		#region - member variables
		private static CrimeLab sCrimeLab;
		private Context mAppContext;
		#endregion

		#region - Properties
		public List<Crime> Crimes {get; private set;}
		#endregion

		#region - constructor - singleton
		private CrimeLab(Context appContext)
		{
			mAppContext = appContext;
			Crimes = new List<Crime>();
			for (int i = 1; i <= 100; i++) {
				Crime c = new Crime("Crime #"+i);
				c.Solved = (i % 2 ==0);
				Crimes.Add(c);
			}


		}

		public static CrimeLab GetInstance(Context c)
		{
			if (sCrimeLab == null) {
				sCrimeLab = new CrimeLab(c.ApplicationContext);
			}
			return sCrimeLab;
		}
		#endregion

		#region - methods
		public Crime GetCrime(string guid)
		{
			var crime = Crimes.Where(c => c.Id == guid).ElementAt(0);
			return crime;
		}
		#endregion
    }
}

