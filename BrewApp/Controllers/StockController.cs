using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrewApp.ViewModel;

namespace BrewApp.Controllers
{
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Load()
        {
            var objAPI = new BrewApp.Controllers.API.StockAPIController();
            IEnumerable<StockMasterDTO> Stock = objAPI.GetStockDetail();
            List<StockMasterDTO> lstStock = new List<StockMasterDTO>(Stock.Count());
            
            foreach (var item in Stock)
            {
                if (item.Quantity.Contains(","))
                {
                    string[] strQuantity = item.Quantity.Split(',');
                    string[] strPrice = item.Price.Split(',');
                    item.multiArrayQuantity = strQuantity.OfType<string>().ToList();
                    item.multiArrayPrice = strPrice.OfType<string>().ToList();
                }
                lstStock.Add(item);
            }
            
            StockViewModel StockViewModel = new StockViewModel();

            StockViewModel.StockMasterDto = lstStock;
            return View("Load", StockViewModel);
        }

        [HttpPost]
        public ActionResult Add(StockViewModel viewModel)
        {
            var objAPI = new BrewApp.Controllers.API.StockAPIController();
               
            if(!ModelState.IsValid)
            {
                IEnumerable<StockMasterDTO> Stock = objAPI.GetStockDetail();
                List<StockMasterDTO> lstStock = new List<StockMasterDTO>(Stock.Count());
                foreach (var item in Stock)
                {
                    if (item.Quantity.Contains(","))
                    {
                        string[] strQuantity = item.Quantity.Split(',');
                        string[] strPrice = item.Price.Split(',');
                        item.multiArrayQuantity = strQuantity.OfType<string>().ToList();
                        item.multiArrayPrice = strPrice.OfType<string>().ToList();
                    }
                    lstStock.Add(item);
                }
                viewModel.StockMasterDto = lstStock;
                return View("Load", viewModel);
            }

            StockMasterDTO stockDTO = new StockMasterDTO();
            stockDTO.Price = viewModel.Price.ToString();
            //if (stockDTO.Ingredient_Name == "Malt" || stockDTO.Ingredient_Name == "Yeast" || stockDTO.Ingredient_Name == "Hops")
            if (viewModel.Id == 1 || viewModel.Id == 2 || viewModel.Id == 3)
            {
                stockDTO.Quantity = viewModel.IngredientType + ":" + viewModel.Quantity.ToString();
            }
            else {
                stockDTO.Quantity = viewModel.Quantity.ToString();
            }

            stockDTO.Id = viewModel.Id;

            objAPI.UpdateStocks(stockDTO);

            return RedirectToAction("Load");
        }
    }
}