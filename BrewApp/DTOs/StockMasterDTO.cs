using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class StockMasterDTO
    {
        public int Id { get; set; }

        [Display(Name = "Ingredient Name")]
        public string Ingredient_Name { get; set; }

        public string Quantity { get; set; }


        public List<string> multiArrayQuantity {get; set;}

        public List<string> multiArrayPrice { get; set; }

        public string Price { get; set; }

    }
}