using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrewApp.ViewModel
{
    public class StockViewModel
    {
        public StockViewModel()
        {
            lstIngredientType = new List<IndgredientType>(6);
            lstIngredientType.Add(new IndgredientType { ID = "1", Value = "1" });
            lstIngredientType.Add(new IndgredientType { ID = "2", Value = "2" });
            lstIngredientType.Add(new IndgredientType { ID = "3", Value = "3" });
            lstIngredientType.Add(new IndgredientType { ID = "4", Value = "4" });
            lstIngredientType.Add(new IndgredientType { ID = "5", Value = "5" });
            lstIngredientType.Add(new IndgredientType { ID = "6", Value = "6" });
        }

        [Required(ErrorMessage="This field is required.")]
        public int Id { get; set; }

        public IEnumerable<StockMasterDTO> StockMasterDto {get; set;}

        //[Required]
        [Display(Name = "Ingredient Type")]
        public string IngredientType { get; set; }

        public List<IndgredientType> lstIngredientType { get; set; }

        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Please enter a value bigger than 0.")]
        [Display(Name = "Quantity (in g, kg, mL or L)")]
        public Decimal Quantity { get; set; }

        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Please enter a value bigger than 0.")]
        [Display(Name = "Price (per g, kg, mL or L)")]
        public Decimal Price {get; set;}
    }
}