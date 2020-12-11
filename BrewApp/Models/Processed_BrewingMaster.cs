using BrewApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrewApp.Models
{
    public class Processed_BrewingMaster
    {
        [Key]
        public int id { get; set; }

        public int Recipeid { get; set; }
        public RecipeMaster RecipeMaster { get; set; }

        public string RecipeName { get; set; }

        public double Quantity { get; set; }

        public double ProductionPrice { get; set; }

    }
}