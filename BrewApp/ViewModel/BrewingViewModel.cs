using BrewApp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrewApp.ViewModel
{
    public class BrewingViewModel
    {
        public RecipeViewModel RecipeModel { get; set; }

        public BrewingMasterDTO BrewingModel { get; set; }

    }
}