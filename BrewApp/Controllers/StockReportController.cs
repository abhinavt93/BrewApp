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
using System.IO;
using HiQPdf;

namespace BrewApp.Controllers
{
    public class StockReportController : Controller
    {
        private StockReportAPIController oStockReportAPI;

        public StockReportController()
        {
            oStockReportAPI = new StockReportAPIController();
        }

        public ActionResult Load(string id, int? page)
        {
            IPagedList<vw_Stock_Report> vw_Stock_Report;
            StockReportViewModel oStockReportViewModel = new StockReportViewModel();

            if (id != null && id != "" )
            {
                vw_Stock_Report = oStockReportAPI.GetStockReportUsingRefId(Convert.ToInt32(id),page, oStockReportViewModel.RecordPerPage);
                oStockReportViewModel.RefID = id;
            }
            else {
                vw_Stock_Report = oStockReportAPI.GetStockReport(page, oStockReportViewModel.RecordPerPage);
            }

            oStockReportViewModel.StockReport = vw_Stock_Report;

            return View(oStockReportViewModel);
        }

        [HttpPost]
        public ActionResult GetRefIdDetails(StockReportViewModel oStockReport)
        {

            return RedirectToAction("Load", new { id = oStockReport.RefID });
        }

        [HttpPost]
        public ActionResult ConvertPageToPdf()
        {
            IPagedList<vw_Stock_Report> vw_Stock_Report;
            StockReportViewModel oStockReportViewModel = new StockReportViewModel();

            vw_Stock_Report = oStockReportAPI.GetStockReport(1, oStockReportViewModel.RecordPerPage);
            oStockReportViewModel.StockReport = vw_Stock_Report;

            string htmlToConvert = RenderViewAsString("Load", oStockReportViewModel);
            String thisPageUrl = this.ControllerContext.HttpContext.Request.Url.AbsoluteUri;
            String baseUrl = thisPageUrl.Substring(0, thisPageUrl.Length - "StockReport/ConvertThisPageToPdf".Length);
            HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

            // hide the dom elements in the created PDF
            //htmlToPdfConverter.HiddenHtmlElements = new string[] { "#convertThisPageButtonDiv" };

            byte[] pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlToConvert, baseUrl);
            FileResult fileResult = new FileContentResult(pdfBuffer, "application/pdf");
            fileResult.FileDownloadName = "StockReport.pdf";
            return fileResult;
        }

        public string RenderViewAsString(string viewName, object model)
        {
            StringWriter stringWriter = new StringWriter();
            ViewEngineResult viewResult = ViewEngines.Engines.FindView(ControllerContext, viewName, null);
           
            ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    new ViewDataDictionary(model),
                    new TempDataDictionary(),
                    stringWriter
                    );

            viewResult.View.Render(viewContext, stringWriter);
            return stringWriter.ToString();
        }
    }
}