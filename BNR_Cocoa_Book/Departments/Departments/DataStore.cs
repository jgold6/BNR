﻿using System;
using System.Collections.Generic;
using SQLite;
using System.IO;
using Foundation;

namespace Departments
{
    public class DataStore : object
    {
		public static List<Department> Departments {get; private set;}
		public static List<Employee> Employees  {get; private set;}


		public static void LoadItemsFromDatabase()
		{
			//			string path = itemArchivePath(); // Archiving method of saving
			//			var unarchiver = (NSMutableArray)NSKeyedUnarchiver.UnarchiveFile(path); // Archiving method of saving
			//			if (unarchiver != null) { // Archiving method of saving
			//				for (int i = 0; i < unarchiver.Count; i++) { // Archiving method of saving
			//					allItems.Add(unarchiver.GetItem<BNRItem>(i)); // Archiving method of saving
			//				} // Archiving method of saving
			//			} // Archiving method of saving

			string dbPath = GetDBPath();
			SQLiteConnection db;
			if (!File.Exists(dbPath)) {
				db = new SQLiteConnection(dbPath);

				db.CreateTable<Department>();
				db.CreateTable<Employee>();

				db.Close();
			} 
			db = new SQLiteConnection(dbPath);

			Departments = db.Query<Department>("SELECT * FROM Departments ORDER BY Name");
			Employees = db.Query<Employee>("SELECT * FROM Employees ORDER BY LastName");

			db.Close();
		}

		public static void AddItem<T>(object item)
		{
			
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);

			if (item is Employee) {
				Employees.Add(item as Employee);
			}
			else if (item is Department) {
				Departments.Add(item as Department);
			}

			db.Insert(item);

			db.Close();
		}

		public static void RemoveItem<T>(T item)
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);

			if (item is Employee) {
				Employees.Remove(item as Employee);
			}
			else if (item is Department) {
				Departments.Remove(item as Department);
			}
			db.Delete(item);

			db.Close();
		}

		public static void UpdateDBItem(Employee emp)
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);

			db.Update(emp, typeof(Employee));

			db.Close();
		}

		public static void UpdateDBItem(Department dep)
		{
			string dbPath = GetDBPath();
			SQLiteConnection db;
			db = new SQLiteConnection(dbPath);

			db.Update(dep, typeof(Department));

			db.Close();
		}

		public static string GetDBPath()
		{
			string[] documentDirectories = NSSearchPath.GetDirectories(NSSearchPathDirectory.DocumentDirectory, NSSearchPathDomain.User, true);

			// Get one and only document directory from that list
			string documentDirectory = documentDirectories[0];
			return Path.Combine(documentDirectory, "DepartmentsDatabase/Departments.db");
		}
    }
}

