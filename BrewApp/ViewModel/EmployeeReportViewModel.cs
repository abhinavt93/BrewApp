using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrewApp.ViewModel
{
    public class EmployeeReportViewModel
    {
        public IPagedList<vw_Employee_Report> EmployeeReport { get; set; }

        [Display(Name = "Records per Page")]
        public int RecordPerPage { get; set; }

        [Display(Name = "Ref ID")]
        public string RefID { get; set; }

        public EmployeeReportViewModel()
        {
            RecordPerPage = 10;
        }
    }
}