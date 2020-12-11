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
    public class IncomeStatementAPIController : ApiController
    {
        private ApplicationDbContext _context;

        public IncomeStatementAPIController()
         {
            _context = new ApplicationDbContext();
         }
    }
}
