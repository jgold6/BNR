using System;
using SQLite;
using Foundation;

namespace Departments
{
	[Table("Employees")]
    public class Employee
    {
		[PrimaryKey, AutoIncrement]
		public int ID {get; private set;}
		public int Department {get; private set;}
		public string FirstName {get; set;}
		public string LastName {get; set;}

		[Ignore]
		public string FullName {
			get {
				return String.Format("{0} {1}", FirstName, LastName);
			}
		}

		[Ignore]
		public string DepartmentName {
			get {
				// Fetch and return Name from Departments table
				return DataStore.Departments.Find(x => x.ID == this.Department).Name;
			}
			set {
				// Fetch Department ID for DepartmentName
				int deptId = DataStore.Departments.Find(x => x.Name == value).ID;
				// Duplicate DepartmentNames?

				// Set Department property with Department ID of Department
				Department = deptId;
			}
		}


        public Employee()
        {
        }
    }
}

