using BrewApp.Controllers.API;
using BrewApp.DTOs;
using BrewApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrewApp.Controllers
{
    public class RecipeController : Controller
    {
        private RecipeAPIController oAPI;
        // GET: Recipe

        public RecipeController()
        {
            oAPI = new RecipeAPIController();
        }

        public ActionResult Load(int? id)
        {
            IEnumerable<RecipeMasterDTO> oRecipeMasterDTO;
            oRecipeMasterDTO = oAPI.GetRecipes();
            RecipeViewModel oRecipeViewModel = new RecipeViewModel();
            oRecipeViewModel.oRecipeMasterDTO = oRecipeMasterDTO;
            oRecipeViewModel.Mode = "Add";
            if (id != null)
            {
                RecipeMasterDTO objTemp = oRecipeMasterDTO.SingleOrDefault(r => r.id == id);
                oRecipeViewModel.Mode = "Update";
                oRecipeViewModel.Id = (int)id;
                oRecipeViewModel.RecipeName = objTemp.RecipeName;
                oRecipeViewModel.Malt = Convert.ToDouble(objTemp.Malt.Split(':')[1]);
                oRecipeViewModel.MaltType = objTemp.Malt.Split(':')[0];
                oRecipeViewModel.Hops = Convert.ToDouble(objTemp.Hops.Split(':')[1]);
                oRecipeViewModel.HopsType = objTemp.Hops.Split(':')[0];
                oRecipeViewModel.Yeast = Convert.ToDouble(objTemp.Yeast.Split(':')[1]);
                oRecipeViewModel.YeastType = objTemp.Yeast.Split(':')[0];
                oRecipeViewModel.Water = objTemp.Water;
                oRecipeViewModel.OrangePeels = objTemp.OrangePeels;
                oRecipeViewModel.Coriander = objTemp.Coriander;
                oRecipeViewModel.FilterSheets = objTemp.FilterSheets;
                oRecipeViewModel.CleaningChemicals = objTemp.CleaningChemicals;
                oRecipeViewModel.Iodine = objTemp.Iodine;
                oRecipeViewModel.Enzymes = objTemp.Enzymes;

            }
            
            return View(oRecipeViewModel);
        }

        [HttpPost]
        public ActionResult Add(RecipeViewModel oRecipeViewModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<RecipeMasterDTO> Recipe = oAPI.GetRecipes();
                oRecipeViewModel.oRecipeMasterDTO = Recipe;
                return View("Load", oRecipeViewModel);
            }

            RecipeMasterDTO oRecipeMasterDTO = new RecipeMasterDTO();
            oRecipeMasterDTO.RecipeName = oRecipeViewModel.RecipeName;
            oRecipeMasterDTO.Malt = oRecipeViewModel.MaltType +":"+ oRecipeViewModel.Malt.ToString();
            oRecipeMasterDTO.Hops = oRecipeViewModel.HopsType +":"+ oRecipeViewModel.Hops.ToString();
            oRecipeMasterDTO.Yeast = oRecipeViewModel.YeastType +":"+ oRecipeViewModel.Yeast.ToString();
            oRecipeMasterDTO.Water = oRecipeViewModel.Water;
            oRecipeMasterDTO.OrangePeels = oRecipeViewModel.OrangePeels;
            oRecipeMasterDTO.Coriander = oRecipeViewModel.Coriander;
            oRecipeMasterDTO.FilterSheets = oRecipeViewModel.FilterSheets;
            oRecipeMasterDTO.CleaningChemicals = oRecipeViewModel.CleaningChemicals;
            oRecipeMasterDTO.Iodine = oRecipeViewModel.Iodine;
            oRecipeMasterDTO.Enzymes = oRecipeViewModel.Enzymes;
            oRecipeMasterDTO.id = oRecipeViewModel.Id;

            if (oRecipeMasterDTO.id == 0)
                oAPI.AddRecipe(oRecipeMasterDTO);
            else
                oAPI.UpdateRecipe(oRecipeMasterDTO);

            return RedirectToAction("Load");
        }
    }
}