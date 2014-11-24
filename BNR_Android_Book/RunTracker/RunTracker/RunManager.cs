using System;
using Android.Content;
using Android.Locations;
using Android.App;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace RunTracker
{
    public class RunManager
    {
		public static readonly string TAG = "RunManager";

		public static readonly string ACTION_LOCATION = "com.onobytes.runtracker.ACTION_LOCATION";

		private string mDbName;
		private string mDbPath;

		private static RunManager sRunManager;
		private Context mAppContext;
		private LocationManager mLocationManager;

        private RunManager(Context appContext)
        {
			mAppContext = appContext;
			mDbName = "runs.db3";
			mDbPath = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), mDbName);
			mLocationManager = (LocationManager)mAppContext.GetSystemService(Context.LocationService);
        }

		public static RunManager Get(Context c)
		{
			if (sRunManager == null) {
				// Use the application context to avoid leaking activities
				sRunManager = new RunManager(c.ApplicationContext);
			}
			return sRunManager;
		}

		private PendingIntent GetLocationPendingIntent(bool shouldCreate)
		{
			Intent broadcast = new Intent(ACTION_LOCATION);
			int flags = (int)(shouldCreate ? 0 : PendingIntentFlags.NoCreate);
			return PendingIntent.GetBroadcast(mAppContext, 0, broadcast, (PendingIntentFlags)flags);
		}

		public void StartLocationUpdates() {
			string provider = LocationManager.GpsProvider;

			// Get the last known location and broadcast it if you have one
			Location lastKnown = mLocationManager.GetLastKnownLocation(provider);
			if (lastKnown != null) {
				// Reset the time to now
				lastKnown.Time =  Java.Lang.JavaSystem.CurrentTimeMillis();
				broadcastLocation(lastKnown);
			}

			// Start updates from the location manager
			PendingIntent pi = GetLocationPendingIntent(true);
			mLocationManager.RequestLocationUpdates(provider, 0, 0, pi);
		}

		private void broadcastLocation(Location location)
		{
			Intent broadcast = new Intent(ACTION_LOCATION);
			broadcast.PutExtra(LocationManager.KeyLocationChanged, location);
			mAppContext.SendBroadcast(broadcast);
		}

		public void StopLocationUpdates()
		{
			PendingIntent pi = GetLocationPendingIntent(false);
			if (pi != null) {
				mLocationManager.RemoveUpdates(pi);
				pi.Cancel();
			}
		}

		public Run StartNewRun()
		{
			StartLocationUpdates();
			Run run = new Run();
			InsertItem<Run>(run);
			return run;
		}

		public void StopRun(Run run)
		{
			StopLocationUpdates();
			run.Active = false;
			UpdateItem<Run>(run);
		}

		public bool IsTrackingRun()
		{
			return GetLocationPendingIntent(false) != null;
		}

		#region - Database
		public void CreateDatabase() 
		{
			var db = new SQLiteConnection(mDbPath);
			db.CreateTable<Run>();
			db.CreateTable<RunLocation>();
			db.Close();
//			ListAll();
		}

		public void InsertItem<T>(T item)
		{
			var db = new SQLiteConnection(mDbPath);
			db.Insert(item, item.GetType());
			db.Close();
//			ListAll();
		}

		public void UpdateItem<T>(T item)
		{
			var db = new SQLiteConnection(mDbPath);
			db.Update(item, item.GetType());
			db.Close();
//			ListAll();
		}

		public void DeleteItem<T>(T item)
		{
			var db = new SQLiteConnection(mDbPath);
			var rowsDeleted = db.Delete<T>(item);
			db.Close();
			Console.WriteLine("{0} Rows Deleted: {1}", TAG, rowsDeleted);
//			ListAll();
		}

		public Run GetRun(int id)
		{
			var db = new SQLiteConnection(mDbPath);
			var item = db.Get<Run>(id);
			db.Close();
			return item;
		}

		public RunLocation GetRunLocation(int id)
		{
			var db = new SQLiteConnection(mDbPath);
			var item = db.Get<RunLocation>(id);
			db.Close();
			return item;
		}

		public List<Run> GetRuns()
		{
			var db = new SQLiteConnection(mDbPath);
			var items = db.Table<Run>().ToList();
			db.Close();
			return items;
		}

		public List<RunLocation> GetRunLocations()
		{
			var db = new SQLiteConnection(mDbPath);
			var items = db.Table<RunLocation>().ToList();
			db.Close();
			return items;
		}

		public List<RunLocation> GetLocationsForRun(Run run)
		{
			// ORM
//			List<RunLocation> matched = new List<RunLocation>();
			var db = new SQLiteConnection(mDbPath);

			//ORM
//			var items = db.Table<RunLocation>().ToList();
//			foreach(RunLocation loc in items) {
//				if (run.Id == loc.RunId)
//					matched.Add(loc);
//			}

			// ADO
			var ADOitems = db.Query<RunLocation>("SELECT * FROM RunLocations WHERE RunId=" + run.Id).ToList();

			db.Close();

			// ORM
//			return matched;

			// ADO
			return ADOitems;
		}

		public Run GetActiveRun()
		{
			var runs = GetRuns();
			foreach (Run run in runs) {
				if (run.Active)
					return run;
			}
			return null;
		}

		private void ListAll()
		{
			var runs = GetRuns();
			foreach (Run run in runs) {
				Console.WriteLine("{0} RunId: {1}, Active: {2}, Date: {3}", TAG, run.Id, run.Active, run.StartDate);
				var locations = GetLocationsForRun(run);
				foreach (RunLocation location in locations) {
					Console.WriteLine("{0} Location: {1}, Lat: {2:F3}, Long: {3:F3}, RunId: {4}, Time: {5}", TAG, location.Id, location.Latitude, location.Longitude, location.RunId, location.Time);
				}
			}
			Console.WriteLine("{0} ************************************", TAG);
		}
		#endregion
    }
}

