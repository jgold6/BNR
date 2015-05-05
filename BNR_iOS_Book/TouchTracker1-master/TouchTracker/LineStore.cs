using System;
using MonoTouch.Foundation;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace TouchTracker
{
	public static class LineStore 
	{
		public static List<Line> completeLines = new List<Line>();
		public static List<Circle> completeCircles = new List<Circle>();

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
				db.CreateTable<Circle>();

				var columnInfo = db.GetTableInfo("Lines");
				foreach (SQLiteConnection.ColumnInfo ci in columnInfo) {
					Console.WriteLine("Column Info: {0}", ci.Name);
				}
				columnInfo = db.GetTableInfo("Circles");
				foreach (SQLiteConnection.ColumnInfo ci in columnInfo) {
					Console.WriteLine("Column Info: {0}", ci.Name);
				}

				db.Close();
				db = null;
			}
			db = new SQLiteConnection(dbPath);

			completeLines = db.Query<Line>("SELECT * FROM Lines");
			completeCircles = db.Query<Circle>("SELECT * FROM Circles");

			foreach (Line line in completeLines) {
				line.setColor();
				Console.WriteLine("Line bx {0}, by {1}, ex {2}, ey {3}", line.begin.X, line.begin.Y, line.end.X, line.end.Y);
			}
			foreach (Circle circle in completeCircles) {
				circle.setColor();
				Console.WriteLine("Circle bx {0}, by {1}, ex {2}, ey {3}", circle.center.X, circle.center.Y, circle.point2.X, circle.point2.Y);
			}

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

			foreach (Line l in result) {
				Console.WriteLine("Line DB: bx {0}, by {1}, ex {2}, ey {3}", l.begin.X, l.begin.Y, l.end.X, l.end.Y);
			}

			db.Close();
			db = null;

			foreach (Line l in completeLines) {
				Console.WriteLine("Line CL: bx {0}, by {1}, ex {2}, ey {3}", l.begin.X, l.begin.Y, l.end.X, l.end.Y);
			}
		}

		public static void addCompletedCircle(Circle circle)
		{
			completeCircles.Add(circle);

			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.Insert(circle);

			var result = db.Query<Line>("SELECT * FROM Lines");
			foreach (Line l in result) {
				Console.WriteLine("Line DB: bx {0}, by {1}, ex {2}, ey {3}", l.begin.X, l.begin.Y, l.end.X, l.end.Y);
			}
			var result2 = db.Query<Circle>("SELECT * FROM Circles");
			foreach (Circle c in result2) {
				Console.WriteLine("Circle DB: cx {0}, cy {1}, p2x {2}, p2yy {3}", c.center.X, c.center.Y, c.point2.X, c.point2.Y);
			}

			db.Close();
			db = null;

			foreach (Line l in completeLines) {
				Console.WriteLine("Line CL: bx {0}, by {1}, ex {2}, ey {3}", l.begin.X, l.begin.Y, l.end.X, l.end.Y);
			}
			foreach (Circle c in completeCircles) {
				Console.WriteLine("Circle CC: cx {0}, cy {1}, p2x {2}, p2yy {3}", c.center.X, c.center.Y, c.point2.X, c.point2.Y);
			}
		}

		public static void clearShapes()
		{
			completeLines.Clear();
			completeCircles.Clear();
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);
			db.DeleteAll<Line>();
			db.DeleteAll<Circle>();
			db.Close();
			db = null;

		}

		public static string GetDBPath()
		{
			string[] documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);

			// Get one and only document directory from that list
			string documentDirectory = documentDirectories[0];
			return Path.Combine(documentDirectory, "shapes.db");
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

