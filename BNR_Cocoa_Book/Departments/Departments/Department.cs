using System;
using SQLite;
using System.Collections.Generic;
using Foundation;

namespace Departments
{
	[Table("Departments")]
    public class Department
    {
		[PrimaryKey, AutoIncrement]
		public int ID {get; private set;}
		public string Name {get; set;} // Department name
		public int Manager {get; private set;} // Manager's Employee ID

		List<Employee> _employees;

		[Ignore]
		public List<Employee> Employees {
			get {
				if (_employees == null) {
					_employees = DataStore.Employees.FindAll(e => e.DepartmentName == this.Name);
				}
				return _employees;
			}
		}

		[Ignore]
		public string ManagerName {
			get {
				// Fetch and return Manager's name from Employees table using Manager property
				return DataStore.Employees.Find(x => x.ID == this.Manager).FullName;
			}
			set {
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
		}

        public Department()
        {
        }
    }
}

