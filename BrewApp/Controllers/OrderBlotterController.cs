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
    public class OrderBlotterController : Controller
    {
        private WorkflowAPIController oWorkflowAPI;

        public OrderBlotterController()
        {
            oWorkflowAPI = new WorkflowAPIController();
        }

        // GET: Workflow
        public ActionResult Load(string id, string PaymentStatus, int? page)
        {
            try
            {
                OrderBlotterViewModel oOrderBlotterViewModel = GetOrderBlotterViewModel(id, PaymentStatus ?? "All", page);
                oOrderBlotterViewModel.RefID = id;
                oOrderBlotterViewModel.PaymentStatus = PaymentStatus;

                return View(oOrderBlotterViewModel);
            }
            catch (Exception ex)
            {
                Logger.Instance().Log("Error occurred while loading the page: " + ex.ToString());
                return Content("Error occurred while loading the page.");
            }
            
        }

        //public ActionResult LoadBrewingBlotter(string id, int? page)
        //{
        //    try
        //    {
        //        OrderBlotterViewModel oWorkflowViewModel = GetOrderBlotterViewModel(id, page);

        //        ViewBag.BlotterId = 1;
        //        return View("~/Views/Workflow/Load.cshtml", oWorkflowViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.Instance().Log("Error occurred while loading the page: " + ex.ToString());
        //        return Content("Error occurred while loading the page.");
        //    }

        //}

        public OrderBlotterViewModel GetOrderBlotterViewModel(string id, string PaymentStatus, int? page)
        {
            IPagedList<vw_Order_Blotter> ovw_Order_Blotter;
            //IPagedList<vw_Brewing_Blotter> ovw_Brewing_Blotter;
            OrderBlotterViewModel oWorkflowViewModel = new OrderBlotterViewModel();

            if ((id != null && id != "") || (PaymentStatus != "All"))
            {
                ovw_Order_Blotter = oWorkflowAPI.GetOrderWorkflowDetailUsingRefId(Convert.ToInt32(id), PaymentStatus, page, oWorkflowViewModel.RecordPerPage);
                //ovw_Brewing_Blotter = oWorkflowAPI.GetBrewingWorkflowDetailUsingRefId(Convert.ToInt32(id), page, oWorkflowViewModel.RecordPerPage);
                oWorkflowViewModel.RefID = id;
            }
            else
            {
                ovw_Order_Blotter = oWorkflowAPI.GetOrderWorkflowDetail(page, oWorkflowViewModel.RecordPerPage);
                //ovw_Brewing_Blotter = oWorkflowAPI.GetBrewingWorkflowDetail(page, oWorkflowViewModel.RecordPerPage);
            }

            oWorkflowViewModel.OrderBlotter = ovw_Order_Blotter;
            //oWorkflowViewModel.BrewingBlotter = ovw_Brewing_Blotter;

            return oWorkflowViewModel;
        }

        [HttpPost]
        public ActionResult GetRefIdDetails(OrderBlotterViewModel oWorkflow)
        {
            //IEnumerable<vw_Order_Blotter> ovw_Order_Blotter;
            //IEnumerable<vw_Brewing_Blotter> ovw_Brewing_Blotter;

            //if (oWorkflow.Blotter.Equals(Blotter.Order))
            //{
            //    ovw_Order_Blotter = oWorkflowAPI.GetOrderWorkflowDetailUsingRefId(Convert.ToInt32(oWorkflow.RefID));
            //    ovw_Brewing_Blotter = oWorkflowAPI.GetBrewingWorkflowDetail();
            //}
            //else {
            //    ovw_Order_Blotter = oWorkflowAPI.GetOrderWorkflowDetail();
            //    ovw_Brewing_Blotter = oWorkflowAPI.GetBrewingWorkflowDetailUsingRefId(Convert.ToInt32(oWorkflow.RefID));
            //}

            //WorkflowViewModel oWorkflowViewModel = new WorkflowViewModel();
            //oWorkflowViewModel.OrderBlotter = ovw_Order_Blotter;
            //oWorkflowViewModel.BrewingBlotter = ovw_Brewing_Blotter;

            return RedirectToAction("Load", new { id = oWorkflow.RefID, PaymentStatus = oWorkflow.PaymentStatus });
        }

    }
}