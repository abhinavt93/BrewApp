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
    public class RecipeReportController : Controller
    {
        private RecipeReportAPIController oRecipeReportAPI;

        public RecipeReportController()
        {
            oRecipeReportAPI = new RecipeReportAPIController();
        }

        public ActionResult Load(string id, int? page)
        {
            IPagedList<vw_Recipe_Report> ovw_Recipe_Report;
            RecipeReportViewModel oRecipeReportViewModel = new RecipeReportViewModel();

            if (id != null && id != "" )
            {
                ovw_Recipe_Report = oRecipeReportAPI.GetRecipeReportUsingRefId(Convert.ToInt32(id),page, oRecipeReportViewModel.RecordPerPage);
                oRecipeReportViewModel.RefID = id;
            }
            else {
                ovw_Recipe_Report = oRecipeReportAPI.GetRecipeReport(page, oRecipeReportViewModel.RecordPerPage);
            }

            oRecipeReportViewModel.RecipeReport = ovw_Recipe_Report;

            return View(oRecipeReportViewModel);
        }

        [HttpPost]
        public ActionResult GetRefIdDetails(RecipeReportViewModel oRecipeReport)
        {

            return RedirectToAction("Load", new { id = oRecipeReport.RefID });
        }
    }
}