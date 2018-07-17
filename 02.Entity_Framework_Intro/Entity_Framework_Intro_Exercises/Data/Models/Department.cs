using System;
using System.Collections.Generic;

namespace Entity_Framework_Intro_Exercises.Data.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        public Employee Manager { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
