using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewApp.Models;
using BrewApp.Controllers.API;
using BrewApp.DTOs;
using BrewApp.ViewModel;

namespace BrewApp.Controllers
{
    public class KegsController : Controller
    {
        // GET: Keg
        public ActionResult Load()
        {
            //var objAPI = new BrewApp.Controllers.API.KegAPIController();
            //IEnumerable<KegDTO> Keg = objAPI.GetKeg();

            return View();
        }

        public ActionResult UpdateOrAdd(string id)
        {
            if (id != null)
            { 
                var objKegAPI = new BrewApp.Controllers.API.KegsAPIController();
                var oOrderEntryAPI = new OrderEntryAPIController();
                KegViewModel kegViewModel = new KegViewModel();
                kegViewModel.Keg = objKegAPI.GetKeg(Convert.ToInt16(id));
                kegViewModel.Customers = oOrderEntryAPI.GetCustomersList();
                return View(kegViewModel);
            }
            else
            {
                var oOrderEntryAPI = new OrderEntryAPIController();
                KegViewModel kegViewModel = new KegViewModel();
                kegViewModel.Keg = new KegDTO();
                kegViewModel.Keg.KegID = 0;
                kegViewModel.Customers = oOrderEntryAPI.GetCustomersList();
                return View(kegViewModel);
            }
        }

        [HttpPost]
        public ActionResult UpdateDB(string id, KegDTO keg)
        {
            var objAPI = new BrewApp.Controllers.API.KegsAPIController();
            if(id != "0")
            {
                keg.LastUpdatedAt = DateTime.Now;
                objAPI.UpdateKeg(Convert.ToInt16(id), keg);
            }
            else
            {
                keg.LastUpdatedAt = DateTime.Now;
                keg.CreatedAt = DateTime.Now;
                objAPI.CreateKeg(keg);
            }
            return RedirectToAction("Load");
        }
    }
}