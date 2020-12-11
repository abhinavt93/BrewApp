using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.Models
{
    public class StockMaster
    {
        public int Id { get; set; }

        public string Ingredient_Name { get; set; }

        public string Quantity { get; set; }

        public string Price { get; set; }
    }
}