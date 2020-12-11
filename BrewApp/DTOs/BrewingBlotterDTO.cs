using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class BrewingBlotterDTO
    {
        public int BrewingId { get; set; }
        public int Recipeid { get; set; }
        public string RecipeName { get; set; }
        public double Quantity { get; set; }
        public double ProductionPrice { get; set; }
        public System.DateTime BrewingTime { get; set; }
        public string Processed_YN { get; set; }
    }
}