using BrewApp.Controllers.API;
using BrewApp.DTOs;
using BrewApp.Models;
using BrewApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrewApp.Controllers
{
    public class BrewingController : Controller
    {
        private RecipeAPIController oRecipeAPI;
        private BrewingAPIController oBrewingAPI;
        private WorkflowAPIController oWorkflowAPI;

        public BrewingController()
        {
            oRecipeAPI = new RecipeAPIController();
            oBrewingAPI = new BrewingAPIController();
            oWorkflowAPI = new WorkflowAPIController();
        }

        // GET: Brewing
        public ActionResult Load(int? Id)
        {
            if (Id == null)
            {
                IEnumerable<RecipeMasterDTO> oRecipeMasterDTO;
                oRecipeMasterDTO = oRecipeAPI.GetRecipes();
                RecipeViewModel oRecipeViewModel = new RecipeViewModel();
                oRecipeViewModel.oRecipeMasterDTO = oRecipeMasterDTO;

                BrewingViewModel oBrewingViewModel = new BrewingViewModel();
                oBrewingViewModel.RecipeModel = oRecipeViewModel;

                oBrewingViewModel.BrewingModel = new BrewingMasterDTO();
                oBrewingViewModel.BrewingModel.Recipeid = 0;

                return View(oBrewingViewModel);
            }
            else
            {
                IEnumerable<RecipeMasterDTO> oRecipeMasterDTO;
                oRecipeMasterDTO = oRecipeAPI.GetRecipes();
                RecipeViewModel oRecipeViewModel = new RecipeViewModel();
                oRecipeViewModel.oRecipeMasterDTO = oRecipeMasterDTO;

                BrewingViewModel oBrewingViewModel = new BrewingViewModel();
                oBrewingViewModel.RecipeModel = oRecipeViewModel;

                oBrewingViewModel.BrewingModel = oBrewingAPI.GetBrewDetail((int)Id);
                
                return View(oBrewingViewModel);
            }
        }

        [HttpPost]
        public JsonResult GetRecipeDetails(int? Id)
        {
            IEnumerable<RecipeMasterDTO> oRecipeMasterDTO;
            oRecipeMasterDTO = oRecipeAPI.GetRecipes();
            RecipeViewModel oRecipeViewModel = new RecipeViewModel();
            oRecipeViewModel.oRecipeMasterDTO = oRecipeMasterDTO;

            if (Id != null)
            {
                RecipeMasterDTO objTemp = oRecipeMasterDTO.SingleOrDefault(r => r.id == Id);

                oRecipeViewModel.Id = (int)Id;
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

            oRecipeViewModel.ProductionPrice = oBrewingAPI.GetProductionCostForRecipe(oRecipeViewModel);
            //TempData["BrewingDialogBox"] = "''";
            return Json(oRecipeViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(BrewingViewModel oBrewingViewModel)
        {
            try
            {
                BrewingMasterDTO oBrewingMasterDTO = new BrewingMasterDTO();

                oBrewingMasterDTO.Recipeid = oBrewingViewModel.BrewingModel.Recipeid;
                oBrewingMasterDTO.RecipeName = oBrewingViewModel.BrewingModel.RecipeName;
                oBrewingMasterDTO.Quantity = oBrewingViewModel.BrewingModel.Quantity;
                oBrewingMasterDTO.BrewingTime = DateTime.Now.AddHours(oBrewingViewModel.BrewingModel.BrewingTimeInHrs);
                oBrewingMasterDTO.ProductionCost = oBrewingViewModel.RecipeModel.ProductionPrice;
                oBrewingMasterDTO.Processed_YN = oBrewingViewModel.BrewingModel.Processed_YN;


                if (oBrewingViewModel.BrewingModel.id == 0)
                {
                    int brewId = oBrewingAPI.AddBrewing(oBrewingMasterDTO);

                    RecipeViewModel oRecipeViewModel = new RecipeViewModel();
                    oRecipeViewModel.Malt = oBrewingViewModel.RecipeModel.Malt;
                    oRecipeViewModel.MaltType = oBrewingViewModel.RecipeModel.MaltType;
                    oRecipeViewModel.Hops = oBrewingViewModel.RecipeModel.Hops;
                    oRecipeViewModel.HopsType = oBrewingViewModel.RecipeModel.HopsType;
                    oRecipeViewModel.Yeast = oBrewingViewModel.RecipeModel.Yeast;
                    oRecipeViewModel.YeastType = oBrewingViewModel.RecipeModel.YeastType;
                    oRecipeViewModel.Water = oBrewingViewModel.RecipeModel.Water;
                    oRecipeViewModel.OrangePeels = oBrewingViewModel.RecipeModel.OrangePeels;
                    oRecipeViewModel.Coriander = oBrewingViewModel.RecipeModel.Coriander;
                    oRecipeViewModel.FilterSheets = oBrewingViewModel.RecipeModel.FilterSheets;
                    oRecipeViewModel.CleaningChemicals = oBrewingViewModel.RecipeModel.CleaningChemicals;
                    oRecipeViewModel.Iodine = oBrewingViewModel.RecipeModel.Iodine;
                    oRecipeViewModel.Enzymes = oBrewingViewModel.RecipeModel.Enzymes;
                    oBrewingAPI.UpdateStockForBrewing(oRecipeViewModel);
                    TempData["BrewingDialogBox"] = "Saved";
                    return RedirectToAction("Load", new { id = brewId });
                }
                else
                {
                    oBrewingAPI.UpdateBrewing(oBrewingViewModel.BrewingModel.id, oBrewingMasterDTO);
                    TempData["BrewingDialogBox"] = "Saved";
                    return RedirectToAction("Load", new { id = oBrewingViewModel.BrewingModel.id });
                }
            }

            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}