using BrewApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class BrewingMasterDTO
    {
        [Key]
        [Display(Name = "Brew ID")]
        public int id { get; set; }

        public int Recipeid { get; set; }
        public RecipeMaster RecipeMaster { get; set; }

        public string RecipeName { get; set; }

        [Required]
        [Display(Name = "Quantity (L)")]
        public double Quantity { get; set; }

        [Required]
        [Display(Name = "Brew Time")]
        public double BrewingTimeInHrs { get; set; }

        public DateTime BrewingTime { get; set; }

        [Display(Name = "Prod. Cost")]
        public double ProductionCost { get; set; }

        public string Processed_YN { get; set; }
    }
}