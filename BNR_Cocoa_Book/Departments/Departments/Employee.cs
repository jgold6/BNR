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
		public string FirstName {get; private set;}
		public string LastName {get; private set;}

		public void SetFirstName(string name)
		{
			if (FirstName != name) {
				FirstName = name;
				DataStore.UpdateDBItem(this);
			}
		}

		public void SetLastName(string name)
		{
			if (LastName != name) {
				LastName = name;
				DataStore.UpdateDBItem(this);
			}
		}

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
				if (Department == 0)
					return "";
				else
					return DataStore.Departments.Find(x => x.ID == this.Department).Name;
			}
			set {
				if (value == "") {
					Department = 0;
				}
				else {
					// Fetch Department ID for DepartmentName
					int deptId = DataStore.Departments.Find(x => x.Name == value).ID;
					// Duplicate DepartmentNames?

					// Set Department property with Department ID of Department
					Department = deptId;
				}
				DataStore.UpdateDBItem(this);
			}
		}


        public Employee()
        {
        }
    }
}

