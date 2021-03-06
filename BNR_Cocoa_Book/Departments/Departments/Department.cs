﻿using System;
using SQLite;
using System.Collections.Generic;
using Foundation;

namespace Departments
{
	[Table("Departments")]
    public class Department
    {
		#region - Database fields
		[PrimaryKey, AutoIncrement]
		public int ID {get; private set;}
		// Manager's Employee ID
		public int Manager {get; private set;}
		// Department name
		public string Name {get; private set;}
		#endregion

		#region - Setters and Getters
		public void SetName(string name)
		{
			if (Name != name) {
				Name = name;
				DataStore.UpdateDBItem(this);
			}
		}

		[Ignore]
		public List<Employee> Employees {
			get {
				return DataStore.Employees.FindAll(e => e.DepartmentName == this.Name);;
			}
		}

		[Ignore]
		public string ManagerName {
			get {
				// Fetch and return Manager's name from Employees table using Manager property
				if (Manager == 0)
					return "";
				else
					return DataStore.Employees.Find(x => x.ID == this.Manager).FullName;
			}
			set {
				if (value == "") {
					Manager = 0;
				}
				else {
					// Fetch Employee ID for ManagerName
					string[] splitName = value.Split(new char[]{' '});
					string firstName = splitName[0];
					string lastName = splitName[1];
					int empID = DataStore.Employees.Find(x => x.FirstName == firstName && x.LastName == lastName).ID;
					// Duplicate names?

					// Is Manager part of Department?

					// Set Manager property with Employee ID of Manager
					Manager = empID;
				}
				DataStore.UpdateDBItem(this);
			}
		}
		#endregion

		#region - Constructors
        public Department()
        {
        }
		#endregion
    }
}

