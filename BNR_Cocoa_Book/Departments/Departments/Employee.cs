using System;
using SQLite;
using Foundation;

namespace Departments
{
	[Table("Employees")]
    public class Employee : NSObject
    {
		[PrimaryKey, AutoIncrement]
		public int ID {get; private set;}
		int Department {get; set;}
		[Export("FirstName")]
		public string FirstName {get; set;}
		[Export("LastName")]
		public string LastName {get; set;}

		[Export("FullName")]
		[Ignore]
		public string FullName {
			get {
				return String.Format("{0}, {1}", LastName, FirstName);
			}
		}

		[Export("DepartmentName")]
		[Ignore]
		public string DepartmentName {
			get {
				// Fetch and return Name from Departments table
				return "Test";
			}
			set {
				// Fetch Department ID for DepartmentName

				// Duplicate DepartmentNames?

				// Set Department property with Department ID of Department

			}
		}


        public Employee()
        {
        }
    }
}

