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
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Load()
        {
            //var objAPI = new BrewApp.Controllers.API.EmployeesAPIController();
            //IEnumerable<EmployeeDTO> employees = objAPI.GetEmployees();

            return View();
        }

        public ActionResult UpdateOrAdd(string id)
        {
            if (id != null)
            { 
                var objAPI = new BrewApp.Controllers.API.EmployeesAPIController();
                EmployeeDTO employee = objAPI.GetEmployee(Convert.ToInt16(id));
                return View(employee);
            }
            else
            {
                return View(new EmployeeDTO());
            }
        }

        [HttpPost]
        public ActionResult UpdateDB(string id, EmployeeDTO employee)
        {
            var objAPI = new BrewApp.Controllers.API.EmployeesAPIController();
            if(id != "0")
            { 
                objAPI.UpdateEmployee(Convert.ToInt16(id), employee);
            }
            else
            {
                objAPI.CreateEmployee(employee);
            }
            return RedirectToAction("Load");
        }
    }
}