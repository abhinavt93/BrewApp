using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrewApp.ViewModel
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
            lstIngredientType = new List<IndgredientType>(6);
            lstIngredientType.Add(new IndgredientType { ID = "1", Value = "1" });
            lstIngredientType.Add(new IndgredientType { ID = "2", Value = "2" });
            lstIngredientType.Add(new IndgredientType { ID = "3", Value = "3" });
            lstIngredientType.Add(new IndgredientType { ID = "4", Value = "4" });
            lstIngredientType.Add(new IndgredientType { ID = "5", Value = "5" });
            lstIngredientType.Add(new IndgredientType { ID = "6", Value = "6" });
        }

        public List<IndgredientType> lstIngredientType {get; set;}

        public string Mode { get; set; }

        public IEnumerable<RecipeMasterDTO> oRecipeMasterDTO { get; set; }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        [Display(Name = "Malt (kg)")]
        public double Malt { get; set; }

        [Required]
        [Display(Name = "Malt Type")]
        public string MaltType { get; set; }

        [Display(Name = "Hops (g)")]
        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        public double Hops { get; set; }

        [Required]
        [Display(Name = "Hops Type")]
        public string HopsType { get; set; }

        [Display(Name = "Yeast (g)")]
        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        public double Yeast { get; set; }

        [Required]
        [Display(Name = "Yeast Type")]
        public string YeastType { get; set; }

        [Display(Name = "Water (L)")]
        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        public double Water { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        [Display(Name="Orange Peels (g)")]
        public double OrangePeels { get; set; }

        [Display(Name = "Coriander (g)")]
        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        public double Coriander { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        [Display(Name = "Filter Sheets (g)")]
        public double FilterSheets { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        [Display(Name = "Wash Chem. (L)")]
        public double CleaningChemicals { get; set; }

        [Display(Name = "Iodine (mL)")]
        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        public double Iodine { get; set; }

        [Display(Name = "Enzymes (mL)")]
        [Range(0, double.MaxValue, ErrorMessage = "Value should be positive.")]
        public double Enzymes { get; set; }

        [Display(Name = "Production Cost")]
        public double ProductionPrice { get; set; }
        

    }

    public class IndgredientType
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
}