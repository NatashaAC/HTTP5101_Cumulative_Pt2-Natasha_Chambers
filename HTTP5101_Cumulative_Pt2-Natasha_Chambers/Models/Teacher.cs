using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP5101_Cumulative_Pt2_Natasha_Chambers.Models
{
    public class Teacher
    {
        // The fields below define a Teacher
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public decimal Salary;

        // Parameter-less constructor function
        public Teacher() { }
    }
}