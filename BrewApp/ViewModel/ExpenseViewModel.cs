using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrewApp.ViewModel
{
    public class ExpenseViewModel
    {
        
        public IEnumerable<ExpenseMasterDTO> ExpenseMaster { get; set; }

        [Display(Name = "Ingredient Type")]
        public string IngredientType { get; set; }

        [Required]
        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }

        [Required]
        [RequiredGreaterThanZero(ErrorMessage = "Please enter a value bigger than 0.")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        public string Mode { get; set; }

        public int Id { get; set; }
    }
}