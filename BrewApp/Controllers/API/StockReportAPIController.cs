﻿using AutoMapper;
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
    public class StockReportAPIController : ApiController
    {
        private ApplicationDbContext _context;

        public StockReportAPIController()
         {
            _context = new ApplicationDbContext();
         }

         [HttpGet]
         public IPagedList<vw_Stock_Report> GetStockReport(int? page, int recordperPage)
         {
             CommonDBEntities7 _blotterContext = new CommonDBEntities7();
             return _blotterContext.vw_Stock_Report.ToList().ToPagedList(page ?? 1, recordperPage); 
         }

        [HttpGet]
         public IPagedList<vw_Stock_Report> GetStockReportUsingRefId(int RefId, int? page, int recordperPage)
         {
             CommonDBEntities7 _blotterContext = new CommonDBEntities7();

             return _blotterContext.vw_Stock_Report.Where(c => c.Ingredient_Id == RefId).ToList().ToPagedList(page ?? 1, recordperPage);

         }
    }
}
