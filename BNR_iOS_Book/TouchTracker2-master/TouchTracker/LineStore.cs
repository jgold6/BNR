using System;
using Foundation;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace TouchTracker
{
	public static class LineStore 
	{
		public static List<Line> completeLines = new List<Line>();

		public static void loadItemsFromArchive()
		{
			// Archive method of saving
//			string path = lineArchivePath();
//			var unarchiver = (NSMutableArray)NSKeyedUnarchiver.UnarchiveFile(path);
//			if (unarchiver != null) {
//				for (int i = 0; i < unarchiver.Count; i++) {
//					completeLines.Add(unarchiver.GetItem<Line>(i));
//				}
//			}

			string dbPath = GetDBPath();
			SQLiteConnection db;
			if (!File.Exists(dbPath)) {
				db = new SQLiteConnection(dbPath);
				db.CreateTable<Line>();

				var columnInfo = db.GetTableInfo("Lines");
				foreach (SQLiteConnection.ColumnInfo ci in columnInfo) {
					//Console.WriteLine("Collumn Info: {0}", ci.Name);
				}

				db.Close();
				db = null;
			}
			db = new SQLiteConnection(dbPath);
			completeLines = db.Query<Line>("SELECT * FROM Lines");

//			foreach (Line line in completeLines) {
//				//line.setColor();
//				//Console.WriteLine("Line bx {0}, by {1}, ex {2}, ey {3}", line.begin.X, line.begin.Y, line.end.X, line.end.Y);
//			}

			db.Close();
			db = null;
		}

		public static void addCompletedLine(Line line)
		{
			completeLines.Add(line);

			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Insert(line);
			var result = db.Query<Line>("SELECT * FROM Lines");

//			foreach (Line l in result) {
//				//Console.WriteLine("Line DB: bx {0}, by {1}, ex {2}, ey {3}", l.begin.X, l.begin.Y, l.end.X, l.end.Y);
//			}

			db.Close();
			db = null;

//			foreach (Line l in completeLines) {
//				//Console.WriteLine("Line CL: bx {0}, by {1}, ex {2}, ey {3}", l.begin.X, l.begin.Y, l.end.X, l.end.Y);
//			}
		}

		public static void removeCompletedLine(Line line)
		{
			completeLines.Remove(line);
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Delete<Line>(line.ID);
			db.Close();
			db = null;
		}

		public static void updateCompletedLine(Line line)
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Update(line);
			db.Close();
			db = null;
		}

		public static void clearLines()
		{
			completeLines.Clear();
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.DeleteAll<Line>();
			db.Close();
			db = null;

		}

		public static string GetDBPath()
		{
			string[] documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);

			// Get one and only document directory from that list
			string documentDirectory = documentDirectories[0];
			return Path.Combine(documentDirectory, "lines.db");
		}

		// Archive method of saving
//		public static string lineArchivePath()
//		{
//			string[] documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);
//
//			// Get one and only document directory from that list
//			string documentDirectory = documentDirectories[0];
//			return Path.Combine(documentDirectory, "lines.archive");
//		}

//		public static bool saveLines()
//		{
//			string path = lineArchivePath();
//			NSMutableArray newArray = new NSMutableArray();
//			foreach (Line line in completeLines) {
//				newArray.Add(line);
//			}
//			return NSKeyedArchiver.ArchiveRootObjectToFile(newArray, path);
//		}
	}
}

