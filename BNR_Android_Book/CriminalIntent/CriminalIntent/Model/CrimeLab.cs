using System;
using Android.Content;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace CriminalIntent
{
    public  class CrimeLab
    {
		#region - static variables
		static readonly string TAG = "CrimeLab";
		static readonly string FILENAME = "crimes.json";
		private static CrimeLab sCrimeLab;
		#endregion

		#region - member variables
		private Context mAppContext;
		private CriminalIntentJSONSerializer mSerializer;
		#endregion

		#region - Properties
		public List<Crime> Crimes {get; private set;}
		#endregion

		#region - constructor - singleton
		private CrimeLab(Context appContext)
		{
			mAppContext = appContext;
			mSerializer = new CriminalIntentJSONSerializer(mAppContext, FILENAME);

			// Load Crimes
			try {
				Crimes = mSerializer.LoadCrimes();
				Debug.WriteLine(String.Format("Crimes loaded from file: {0}, Type: {1}", Crimes.Count, Crimes), TAG);
			}
			catch (Exception ex) {
				Crimes = new List<Crime>();
				Debug.WriteLine(String.Format("Error loading crimes: {0}", ex.Message), TAG);
			}

			// Populate crimes list
			for (int i = 1; i <= 3; i++) {
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

		public Crime GetCrime(int position)
		{
			return Crimes[position];
		}

		public void AddCrime(Crime c)
		{
			Crimes.Add(c);
		}

		public void DeleteCrime(Crime c)
		{
			Crimes.Remove(c);
		}

		public bool SaveCrimes() 
		{
			try {
				mSerializer.SaveCrimes(Crimes);
				Debug.WriteLine(String.Format("Crimes saved to file: {0}, Type: {1}", Crimes.Count, Crimes), TAG);
				return true;
			}
			catch (Exception ex) {
				Debug.WriteLine(String.Format("Error saving crimes: {0}", ex.Message), TAG);
				return false;
			}
		}

		#endregion
    }
}

