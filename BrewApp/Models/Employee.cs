using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public string FatherName { get; set; }

        public string Email { get; set; }

        public string MotherName { get; set; }

        public string CurrentAddress { get; set; }

        public string PermanentAddress { get; set; }

        public string MobNo { get; set; }

        public DateTime? DOB { get; set; }

        public string PAN { get; set; }

        public string Salary { get; set; }
    }
}