using System;
using System.Collections.Generic;

namespace Entity_Framework_Intro_Exercises.Data.Models
{
    public partial class EmployeeProject
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public Employee Employee { get; set; }
        public Project Project { get; set; }
    }
}
