using BrewApp.Controllers.API;
using BrewApp.DTOs;
using BrewApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace BrewApp.Controllers
{
    public class EmployeeReportController : Controller
    {
        private EmployeeReportAPIController oEmployeeReportAPI;

        public EmployeeReportController()
        {
            oEmployeeReportAPI = new EmployeeReportAPIController();
        }

        public ActionResult Load(string id, int? page)
        {
            IPagedList<vw_Employee_Report> ovw_Employee_Report;
            EmployeeReportViewModel oEmployeeReportViewModel = new EmployeeReportViewModel();

            if (id != null && id != "" )
            {
                ovw_Employee_Report = oEmployeeReportAPI.GetEmployeeReportUsingRefId(Convert.ToInt32(id),page, oEmployeeReportViewModel.RecordPerPage);
                oEmployeeReportViewModel.RefID = id;
            }
            else {
                ovw_Employee_Report = oEmployeeReportAPI.GetEmployeeReport(page, oEmployeeReportViewModel.RecordPerPage);
            }

            oEmployeeReportViewModel.EmployeeReport = ovw_Employee_Report;

            return View(oEmployeeReportViewModel);
        }

        [HttpPost]
        public ActionResult GetRefIdDetails(EmployeeReportViewModel oEmployeeReport)
        {

            return RedirectToAction("Load", new { id = oEmployeeReport.RefID });
        }
    }
}