using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BrewApp.Models
{
    public class ExpenseMaster
    {
        public int Id { get; set; }

        [Display(Name = "Expense Name")]
        public string ExpenseName { get; set; }

        public double Price { get; set; }
    }
}