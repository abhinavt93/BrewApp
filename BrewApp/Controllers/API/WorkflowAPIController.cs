using AutoMapper;
using BrewApp.DTOs;
using BrewApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PagedList;
using PagedList.Mvc;

namespace BrewApp.Controllers.API
{
    public class WorkflowAPIController : ApiController
    {
         private ApplicationDbContext _context;


         public WorkflowAPIController()
         {
            _context = new ApplicationDbContext();
         }

         [HttpGet]
         public IPagedList<vw_Order_Blotter> GetOrderWorkflowDetail(int? page, int recordperPage)
         {
             CommonDBEntities7 _blotterContext = new CommonDBEntities7();
             return _blotterContext.vw_Order_Blotter.ToList().ToPagedList(page ?? 1, recordperPage); 
         }

         [HttpGet]
         public IPagedList<vw_Brewing_Blotter> GetBrewingWorkflowDetail(int? page, int recordperPage)
         {
             CommonDBEntities7 _blotterContext = new CommonDBEntities7();
             return _blotterContext.vw_Brewing_Blotter.ToList().ToPagedList(page ?? 1, recordperPage); ;
         }

         [HttpGet]
         public IPagedList<vw_Order_Blotter> GetOrderWorkflowDetailUsingRefId(int RefId, string PaymentStatus,int? page, int recordperPage)
         {
             CommonDBEntities7 _blotterContext = new CommonDBEntities7();
             if (PaymentStatus != "All" && RefId != 0)
             {
                 if (PaymentStatus == "Pending")
                     return _blotterContext.vw_Order_Blotter.Where(c => c.OrderId == RefId && c.Remaining_Amount > 0).ToList().ToPagedList(page ?? 1, recordperPage);
                 else
                     return _blotterContext.vw_Order_Blotter.Where(c => c.OrderId == RefId && c.Remaining_Amount == 0).ToList().ToPagedList(page ?? 1, recordperPage);
             }
             else if (PaymentStatus != "All")
             {
                 if (PaymentStatus == "Pending")
                     return _blotterContext.vw_Order_Blotter.Where(c => c.Remaining_Amount > 0).ToList().ToPagedList(page ?? 1, recordperPage);
                 else
                     return _blotterContext.vw_Order_Blotter.Where(c => c.Remaining_Amount == 0).ToList().ToPagedList(page ?? 1, recordperPage);
             }
             else
                 return _blotterContext.vw_Order_Blotter.Where(c => c.OrderId == RefId).ToList().ToPagedList(page ?? 1, recordperPage);

         }

         [HttpGet]
         public IPagedList<vw_Brewing_Blotter> GetBrewingWorkflowDetailUsingRefId(int RefId, string processedYN, int? page, int recordperPage)
         {
             CommonDBEntities7 _blotterContext = new CommonDBEntities7();
             if (processedYN != "All" && RefId != 0)
                 return _blotterContext.vw_Brewing_Blotter.Where(c => c.BrewingId == RefId && c.Processed_YN == processedYN).ToList().ToPagedList(page ?? 1, recordperPage);
             else if (processedYN != "All")
                 return _blotterContext.vw_Brewing_Blotter.Where(c => c.Processed_YN == processedYN).ToList().ToPagedList(page ?? 1, recordperPage);
             else
                 return _blotterContext.vw_Brewing_Blotter.Where(c => c.BrewingId == RefId).ToList().ToPagedList(page ?? 1, recordperPage);
         }
        
    }
}
