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
    public class IncomeStatementController : Controller
    {
        private IncomeStatementAPIController oIncomeStatementAPI;

        public IncomeStatementController()
        {
            oIncomeStatementAPI = new IncomeStatementAPIController();
        }

        public ActionResult Load()
        {
            return View();
        }
    }
}