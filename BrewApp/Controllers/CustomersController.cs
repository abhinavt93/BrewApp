using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewApp.Models;
using BrewApp.Controllers.API;
using BrewApp.DTOs;

namespace BrewApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Load()
        {
            //var objAPI = new BrewApp.Controllers.API.CustomersAPIController();
            //IEnumerable<CustomerDTO> Customers = objAPI.GetCustomers();

            return View();
        }

        public ActionResult UpdateOrAdd(string id)
        {
            if (id != null)
            { 
                var objAPI = new BrewApp.Controllers.API.CustomersAPIController();
                CustomerDTO customer = objAPI.GetCustomer(Convert.ToInt16(id));
                return View(customer);
            }
            else
            {
                return View(new CustomerDTO());
            }
        }

        [HttpPost]
        public ActionResult UpdateDB(string id, CustomerDTO customer)
        {
            var objAPI = new BrewApp.Controllers.API.CustomersAPIController();
            if(id != "0")
            { 
                objAPI.UpdateCustomer(Convert.ToInt16(id), customer);
            }
            else
            {
                objAPI.CreateCustomer(customer);
            }
            return RedirectToAction("Load");
        }
    }
}