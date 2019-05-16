﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inner_Join_LINQ
{
    class Program
    {
        public class Department
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public static List<Department> GetAllDepartments()
            {
                return new List<Department>()
        {
            new Department { ID = 1, Name = "IT"},
            new Department { ID = 2, Name = "HR"},
            new Department { ID = 3, Name = "Payroll"},
        };
            }
        }

        public class Employee
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int DepartmentID { get; set; }

            public static List<Employee> GetAllEmployees()
            {
                return new List<Employee>()
        {
            new Employee { ID = 1, Name = "Mark", DepartmentID = 1 },
            new Employee { ID = 2, Name = "Steve", DepartmentID = 2 },
            new Employee { ID = 3, Name = "Ben", DepartmentID = 1 },
            new Employee { ID = 4, Name = "Philip", DepartmentID = 1 },
            new Employee { ID = 5, Name = "Mary", DepartmentID = 2 },
            new Employee { ID = 6, Name = "Valarie", DepartmentID = 2 },
            new Employee { ID = 7, Name = "John", DepartmentID = 1 },
            new Employee { ID = 8, Name = "Pam", DepartmentID = 1 },
            new Employee { ID = 9, Name = "Stacey", DepartmentID = 2 },
            new Employee { ID = 10, Name = "Andy"}
        };
            }
        }

        public static void Main()
        {
            /*
            var result = Employee.GetAllEmployees().Join(Department.GetAllDepartments(),
                                                   e => e.DepartmentID,
                                                   d => d.ID,
                                                   (employee, department) => new
                                                   {
                                                       EmployeeName = employee.Name,
                                                       DepartmentName = department.Name
                                                   });
            */

            //Better version
            var result = from e in Employee.GetAllEmployees()
                         join d in Department.GetAllDepartments()
                         on e.DepartmentID equals d.ID
                         select new
                         {
                             EmployeeName = e.Name,
                             DepartmentName = d.Name
                         };
            foreach (var employee in result)
            {
                Console.WriteLine(employee.EmployeeName + "\t" + employee.DepartmentName);
            }
            Console.ReadKey();
        }
    }
}
