using BrewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrewApp.DTOs;
using AutoMapper;
using System.Text;

namespace BrewApp.Controllers.API
{
    public class StockAPIController : ApiController
    {
        private ApplicationDbContext _context;


        public StockAPIController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<StockMasterDTO> GetStockDetail()
        {
            return _context.StockMaster.ToList().Select(Mapper.Map<StockMaster, StockMasterDTO>);
        }

        [HttpPut]
        public void UpdateStocks(StockMasterDTO stock)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var stockinDB = _context.StockMaster.SingleOrDefault(c => c.Id == stock.Id);

            if (stockinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //stock.Ingredient_Name = stockinDB.Ingredient_Name;

            if (stock.Quantity.Contains(':'))
            {
                if (stockinDB.Quantity == "" || !stockinDB.Quantity.Contains(':') || stockinDB.Price == "" || !stockinDB.Price.Contains(':'))
                {
                    stockinDB.Quantity = "1:0,2:0,3:0,4:0,5:0,6:0";
                    stockinDB.Price = "1:0,2:0,3:0,4:0,5:0,6:0";
                }

                Dictionary<string, Decimal> dicQuantity = csvToDictionary(stockinDB.Quantity);
                Dictionary<string, Decimal> dicPrice = csvToDictionary(stockinDB.Price);

                Dictionary<string, Decimal> dicTemp = new Dictionary<string, Decimal>(dicQuantity);

                foreach (var item in dicTemp)
                {
                    if (item.Key == stock.Quantity.Split(':')[0])
                    {
                        if (dicQuantity[item.Key] == 0m)
                        {
                            dicPrice[item.Key] = Convert.ToDecimal(stock.Price);
                        }
                        else
                        {
                            dicPrice[item.Key] = ((Convert.ToDecimal(dicPrice[item.Key]) * Convert.ToDecimal(dicQuantity[item.Key]) + Convert.ToDecimal(stock.Price) * Convert.ToDecimal(stock.Quantity.Split(':')[1])) / (Convert.ToDecimal(stock.Quantity.Split(':')[1]) + Convert.ToDecimal(dicQuantity[item.Key])));
                        }

                        dicQuantity[item.Key] = item.Value + Convert.ToDecimal(stock.Quantity.Split(':')[1]);
                    }
                }
                stockinDB.Quantity = DictionaryTocsv(dicQuantity);
                stockinDB.Price = DictionaryTocsv(dicPrice);
            }
            else 
            {
                if (stockinDB.Quantity != "")
                {
                    stockinDB.Price = ((Convert.ToDecimal(stockinDB.Price) * Convert.ToDecimal(stockinDB.Quantity) + Convert.ToDecimal(stock.Price) * Convert.ToDecimal(stock.Quantity)) / (Convert.ToDecimal(stock.Quantity) + Convert.ToDecimal(stockinDB.Quantity))).ToString();
                }
                else
                {
                    stockinDB.Price = stock.Price;
                }

                stockinDB.Quantity = (Convert.ToDecimal(stock.Quantity) + Convert.ToDecimal(stockinDB.Quantity)).ToString();

                
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
