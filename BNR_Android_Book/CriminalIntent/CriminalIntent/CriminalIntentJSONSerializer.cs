using System;
using Android.Content;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace CriminalIntent
{
    public class CriminalIntentJSONSerializer
    {
		static readonly string TAG = "CriminalIntentJSONSerializer";

		Context mContext;
		string mFilename;

		public CriminalIntentJSONSerializer(Context c, string f)
        {
			mContext = c;
			mFilename = f;
        }

		public void SaveCrimes(List<Crime> crimes) 
		{
			string json = JsonConvert.SerializeObject(crimes);

			// Sandbox
			var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(directory, mFilename);
			// External storage
//			if (Android.OS.Environment.ExternalStorageState = Android.OS.Environment.MediaRemoved)
//				var filePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, mFilename);
//			else {
//				var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
//				var filePath = Path.Combine(directory, mFilename);
//			}

			File.WriteAllText(filePath, json);
			Debug.WriteLine(String.Format("JSON Save: {0}", json), TAG);
		}

		public List<Crime> LoadCrimes()
		{
			List<Crime> crimes = new List<Crime>();

			// Sandbox
			var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var filePath = Path.Combine(directory, mFilename);
			// External storage
//			if (Android.OS.Environment.ExternalStorageState = Android.OS.Environment.MediaRemoved)
//				var filePath = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, mFilename);
//			else {
//				var directory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
//				var filePath = Path.Combine(directory, mFilename);
//			}

			string json = File.ReadAllText(filePath);

			crimes = JsonConvert.DeserializeObject<List<Crime>>(json);
			Debug.WriteLine(String.Format("JSON Load: {0}", json), TAG);
			return crimes;
		}
    }
}

