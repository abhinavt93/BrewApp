using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrewApp.DTOs
{
    public class ExpenseMasterDTO
    {
        public int Id { get; set; }

        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }

        public double Price { get; set; }
    }
}