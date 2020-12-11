using AutoMapper;
using BrewApp.DTOs;
using BrewApp.Models;
using BrewApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BrewApp.Controllers.API
{
    public class BrewingAPIController : ApiController
    {
        private ApplicationDbContext _context;

        public BrewingAPIController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public BrewingMasterDTO GetBrewDetail(int BrewID)
        {
            BrewingMaster BrewDetails;
            BrewDetails = _context.BrewingMaster.SingleOrDefault(e => e.id == BrewID);

            if (BrewDetails == null)
                NotFound();

            return Mapper.Map<BrewingMaster, BrewingMasterDTO>(BrewDetails);
        }

        [HttpPost]
        public int AddBrewing(BrewingMasterDTO BrewingDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var Brewing = Mapper.Map<BrewingMasterDTO, BrewingMaster>(BrewingDTO);

            _context.BrewingMaster.Add(Brewing);
            _context.SaveChanges();

            BrewingDTO.id = Brewing.id;

            return BrewingDTO.id;
        }

        [HttpPost]
        public void UpdateBrewing(int id,BrewingMasterDTO BrewingDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var Brewing = _context.BrewingMaster.SingleOrDefault(c => c.id == id);

            if (Brewing == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            BrewingDTO.id = id;

            Mapper.Map(BrewingDTO, Brewing);

            _context.SaveChanges();
        }

        [HttpGet]
        public double GetProductionCostForRecipe(RecipeViewModel recipe)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var stockinDB = _context.StockMaster;

            if (stockinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            decimal ProductionCost = 0;

            foreach (var stock in stockinDB)
            {
                if (stock.Ingredient_Name == "Malt")
                {
                    Dictionary<string, Decimal> dicQuantity = csvToDictionary(stock.Price);

                    foreach (var item in dicQuantity)
                    {
                        if (item.Key == recipe.MaltType)
                        {
                            ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.Malt) * Convert.ToDecimal(item.Value));
                            break;
                        }
                    }
                }
                else if (stock.Ingredient_Name == "Hops")
                {
                    Dictionary<string, Decimal> dicQuantity = csvToDictionary(stock.Price);

                    foreach (var item in dicQuantity)
                    {
                        if (item.Key == recipe.HopsType)
                        {
                            ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.Hops) * Convert.ToDecimal(item.Value));
                            break;
                        }
                    }
                }
                else if (stock.Ingredient_Name == "Yeast")
                {
                    Dictionary<string, Decimal> dicQuantity = csvToDictionary(stock.Price);

                    foreach (var item in dicQuantity)
                    {
                        if (item.Key == recipe.YeastType)
                        {
                            ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.Yeast) * Convert.ToDecimal(item.Value));
                            break;
                        }
                    }
                }
                else if (stock.Ingredient_Name == "Water")
                {
                    ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.Water) * Convert.ToDecimal(stock.Price));
                }
                else if (stock.Ingredient_Name == "OrangePeels")
                {
                    ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.OrangePeels) * Convert.ToDecimal(stock.Price));
                }
                else if (stock.Ingredient_Name == "Coriander")
                {
                    ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.Coriander) * Convert.ToDecimal(stock.Price));
                }
                else if (stock.Ingredient_Name == "FilterSheets")
                {
                    ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.FilterSheets) * Convert.ToDecimal(stock.Price));
                }
                else if (stock.Ingredient_Name == "CleaningChemicals")
                {
                    ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.CleaningChemicals) * Convert.ToDecimal(stock.Price));
                }
                else if (stock.Ingredient_Name == "Iodine")
                {
                    ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.Iodine) * Convert.ToDecimal(stock.Price));
                }
                else if (stock.Ingredient_Name == "Enzymes")
                {
                    ProductionCost = ProductionCost + (Convert.ToDecimal(recipe.Enzymes) * Convert.ToDecimal(stock.Price));
                }
            }
            return Convert.ToDouble(ProductionCost);
        }

        [HttpPut]
        public void UpdateStockForBrewing(RecipeViewModel recipe)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var stockinDB = _context.StockMaster;

            if (stockinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            foreach (var stock in stockinDB)
            {
                if (stock.Ingredient_Name == "Malt")
                {
                    Dictionary<string, Decimal> dicQuantity = csvToDictionary(stock.Quantity);

                    foreach (var item in dicQuantity)
                    {
                        if (item.Key == recipe.MaltType)
                        {
                            dicQuantity[item.Key] = Convert.ToDecimal(item.Value) - Convert.ToDecimal(recipe.Malt);
                            break;
                        }
                    }
                    stock.Quantity = DictionaryTocsv(dicQuantity);
                }
                else if (stock.Ingredient_Name == "Hops")
                {
                    Dictionary<string, Decimal> dicQuantity = csvToDictionary(stock.Quantity);

                    foreach (var item in dicQuantity)
                    {
                        if (item.Key == recipe.HopsType)
                        {
                            dicQuantity[item.Key] = Convert.ToDecimal(item.Value) - Convert.ToDecimal(recipe.Hops);
                            break;
                        }
                    }
                    stock.Quantity = DictionaryTocsv(dicQuantity);
                }
                else if (stock.Ingredient_Name == "Yeast")
                {
                    Dictionary<string, Decimal> dicQuantity = csvToDictionary(stock.Quantity);

                    foreach (var item in dicQuantity)
                    {
                        if (item.Key == recipe.YeastType)
                        {
                            dicQuantity[item.Key] = Convert.ToDecimal(item.Value) - Convert.ToDecimal(recipe.Yeast);
                            break;
                        }
                    }
                    stock.Quantity = DictionaryTocsv(dicQuantity);
                }
                else if (stock.Ingredient_Name == "Water")
                {
                    stock.Quantity = Convert.ToString(Convert.ToDecimal(stock.Quantity) - Convert.ToDecimal(recipe.Water));
                }
                else if (stock.Ingredient_Name == "OrangePeels")
                {
                    stock.Quantity = Convert.ToString(Convert.ToDecimal(stock.Quantity) - Convert.ToDecimal(recipe.OrangePeels));
                }
                else if (stock.Ingredient_Name == "Coriander")
                {
                    stock.Quantity = Convert.ToString(Convert.ToDecimal(stock.Quantity) - Convert.ToDecimal(recipe.Coriander));
                }
                else if (stock.Ingredient_Name == "FilterSheets")
                {
                    stock.Quantity = Convert.ToString(Convert.ToDecimal(stock.Quantity) - Convert.ToDecimal(recipe.FilterSheets));
                }
                else if (stock.Ingredient_Name == "CleaningChemicals")
                {
                    stock.Quantity = Convert.ToString(Convert.ToDecimal(stock.Quantity) - Convert.ToDecimal(recipe.CleaningChemicals));
                }
                else if (stock.Ingredient_Name == "Iodine")
                {
                    stock.Quantity = Convert.ToString(Convert.ToDecimal(stock.Quantity) - Convert.ToDecimal(recipe.Iodine));
                }
                else if (stock.Ingredient_Name == "Enzymes")
                {
                    stock.Quantity = Convert.ToString(Convert.ToDecimal(stock.Quantity) - Convert.ToDecimal(recipe.Enzymes));
                }
            }
            
            _context.SaveChanges();

            
        }


        private Dictionary<string, Decimal> csvToDictionary(string strCSV)
        {
            Dictionary<string, Decimal> dicTemp = new Dictionary<string, Decimal>();
            string[] strArr = strCSV.Split(',');

            for (int iCount = 0; iCount < strArr.Length; iCount++)
                dicTemp.Add(strArr[iCount].Split(':')[0], Convert.ToDecimal(strArr[iCount].Split(':')[1]));

            return dicTemp;
        }

        private string DictionaryTocsv(Dictionary<string, Decimal> dicTemp)
        {
            StringBuilder strCSV = new StringBuilder();

            foreach (var item in dicTemp)
                strCSV.Append(item.Key).Append(":").Append(item.Value).Append(",");

            strCSV = strCSV.Remove(strCSV.Length - 1, 1);

            return strCSV.ToString();
        }
    }
}
