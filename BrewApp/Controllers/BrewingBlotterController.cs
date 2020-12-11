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
    public class BrewingBlotterController : Controller
    {
        private WorkflowAPIController oWorkflowAPI;

        public BrewingBlotterController()
        {
            oWorkflowAPI = new WorkflowAPIController();
        }

        // GET: Workflow
        public ActionResult Load(string id, string processedYN, int? page)
        {
            try
            {
                BrewingBlotterViewModel oBrewingBlotterViewModel = GetBrewingBlotterViewModel(id, processedYN ?? "All", page: page);
                oBrewingBlotterViewModel.ProcessedYN = processedYN;
                oBrewingBlotterViewModel.RefID = id;
                return View(oBrewingBlotterViewModel);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log("Error occurred while loading the page: " + ex.ToString());
                return Content("Error occurred while loading the page.");
            }
            
        }

        public ActionResult LoadBrewingBlotter(string id, int? page)
        {
            try
            {
                BrewingBlotterViewModel oBrewingBlotterViewModel = GetBrewingBlotterViewModel(id, "All", page);

                ViewBag.BlotterId = 1;
                return View("~/Views/Workflow/Load.cshtml", oBrewingBlotterViewModel);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log("Error occurred while loading the page: " + ex.ToString());
                return Content("Error occurred while loading the page.");
            }

        }

        public BrewingBlotterViewModel GetBrewingBlotterViewModel(string id, string processedYN, int? page)
        {
            IPagedList<vw_Brewing_Blotter> ovw_Brewing_Blotter;
            BrewingBlotterViewModel oBrewingBlotterViewModel = new BrewingBlotterViewModel();

            if ((id != null && id != "") || (processedYN != "All"))
            {
                ovw_Brewing_Blotter = oWorkflowAPI.GetBrewingWorkflowDetailUsingRefId(Convert.ToInt32(id), processedYN, page, oBrewingBlotterViewModel.RecordPerPage);
                oBrewingBlotterViewModel.RefID = id;
            }
            else
            {
                ovw_Brewing_Blotter = oWorkflowAPI.GetBrewingWorkflowDetail(page, oBrewingBlotterViewModel.RecordPerPage);
            }

            oBrewingBlotterViewModel.BrewingBlotter = ovw_Brewing_Blotter;

            return oBrewingBlotterViewModel;
        }

        [HttpPost]
        public ActionResult GetRefIdDetails(BrewingBlotterViewModel oWorkflow)
        {
            return RedirectToAction("Load", new { id = oWorkflow.RefID, processedYN = oWorkflow.ProcessedYN });
        }

    }
}