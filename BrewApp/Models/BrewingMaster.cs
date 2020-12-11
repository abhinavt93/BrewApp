using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrewApp.Models
{
    public class BrewingMaster
    {
        [Key]
        public int id { get; set; }

        public int Recipeid { get; set; }
        public RecipeMaster RecipeMaster { get; set; }
        
        public string RecipeName { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }

        [Required]
        [Display(Name = "Brewing Time")]
        public DateTime BrewingTime { get; set; }

        [Display(Name = "Production Cost")]
        public double ProductionCost { get; set; }

        public string Processed_YN { get; set; }
    }
}