using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.ViewModel
{
    public class OrderEntryViewModel
    {
        public RecipeViewModel OrderRecipeModel { get; set; }

        public OrderEntryDTO OrderEntry { get; set; }

        public IEnumerable<EmployeeDTO> Employee { get; set; }

        public IEnumerable<CustomerDTO> Customer { get; set; }

    }
}