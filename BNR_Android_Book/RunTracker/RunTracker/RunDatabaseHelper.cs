using System;
using System.IO;
using SQLite;

namespace RunTracker
{
    public static class RunDatabaseHelper
    {
		private static readonly string DB_NAME = "runs.db3";
		private static readonly string DB_PATH = Path.Combine (System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal), DB_NAME);
		private static readonly int Version = 1;

		public static SQLiteConnection GetSQLteConnection()
		{
			var db = new SQLiteConnection(DB_PATH);
			return db;
		}
    }
}

