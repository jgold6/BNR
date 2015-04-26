using System;
using SQLite;
using System.Collections.Generic;
using Foundation;

namespace Departments
{
	[Table("Departments")]
    public class Department : NSObject
    {
		[PrimaryKey, AutoIncrement]
		public int ID {get; private set;}
		[Export("Name")]
		public string Name {get; set;} // Department name
		int Manager {get; set;} // Manager's Employee ID

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
				return "Test";
			}
			set {
				// Fetch Employee ID for ManagerName

				// Duplicate names?

				// Is Manager part of Department?

				// Set Manager property with Employee ID of Manager

			}
		}

        public Department()
        {
        }
    }
}

