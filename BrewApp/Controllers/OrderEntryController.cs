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
    public class OrderEntryController : Controller
    {
        private RecipeAPIController oRecipeAPI;
        private OrderEntryAPIController oOrderEntryAPI;

        public OrderEntryController()
        {
            oRecipeAPI = new RecipeAPIController();
            oOrderEntryAPI = new OrderEntryAPIController();
        }

        // GET: OrderEntry
        public ActionResult Load(int? Id)
        {
            if (Id == null)
            {
                IEnumerable<RecipeMasterDTO> oRecipeMasterDTO;
                oRecipeMasterDTO = oRecipeAPI.GetRecipes();
                RecipeViewModel oRecipeViewModel = new RecipeViewModel();
                oRecipeViewModel.oRecipeMasterDTO = oRecipeMasterDTO;

                OrderEntryViewModel oOrderEntryViewModel = new OrderEntryViewModel();
                oOrderEntryViewModel.OrderRecipeModel = oRecipeViewModel;
                oOrderEntryViewModel.OrderEntry = new OrderEntryDTO();
                oOrderEntryViewModel.OrderEntry.id = 0;
                oOrderEntryViewModel.Employee = oOrderEntryAPI.GetEmployeesList();
                oOrderEntryViewModel.Customer = oOrderEntryAPI.GetCustomersList();

                return View(oOrderEntryViewModel);
            }
            else 
            {
                IEnumerable<RecipeMasterDTO> oRecipeMasterDTO;
                oRecipeMasterDTO = oRecipeAPI.GetRecipes();
                RecipeViewModel oRecipeViewModel = new RecipeViewModel();
                oRecipeViewModel.oRecipeMasterDTO = oRecipeMasterDTO;

                OrderEntryViewModel oOrderEntryViewModel = new OrderEntryViewModel();
                oOrderEntryViewModel.OrderRecipeModel = oRecipeViewModel;
                oOrderEntryViewModel.OrderEntry = oOrderEntryAPI.GetOrderDetails((int)Id);

                oOrderEntryViewModel.Employee = oOrderEntryAPI.GetEmployeesList();
                oOrderEntryViewModel.Customer = oOrderEntryAPI.GetCustomersList();

                return View(oOrderEntryViewModel);
            }
        }

        [HttpPost]
        public JsonResult GetRecipeDetails(int Id)
        {
            IEnumerable<RecipeMasterDTO> oRecipeMasterDTO;
            oRecipeMasterDTO = oRecipeAPI.GetRecipes();
            RecipeViewModel oRecipeViewModel = new RecipeViewModel();
            oRecipeViewModel.oRecipeMasterDTO = oRecipeMasterDTO;

            oRecipeViewModel.ProductionPrice = oOrderEntryAPI.GetProductionPriceRecipe(Id);

            RecipeMasterDTO recipe = oRecipeMasterDTO.SingleOrDefault(r => r.id == Id);

                oRecipeViewModel.Id = (int)Id;
                oRecipeViewModel.RecipeName = recipe.RecipeName;

            return Json(oRecipeViewModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(OrderEntryViewModel oOrderEntryModel)
        {

            OrderEntryDTO oOrderEntryDTO = new OrderEntryDTO();

            oOrderEntryDTO.Recipeid = oOrderEntryModel.OrderEntry.Recipeid;
            oOrderEntryDTO.RecipeName = oOrderEntryModel.OrderEntry.RecipeName;
            oOrderEntryDTO.Order_Quantity = oOrderEntryModel.OrderEntry.Order_Quantity;
            oOrderEntryDTO.Production_Price = oOrderEntryModel.OrderEntry.Production_Price;
            oOrderEntryDTO.Production_Cost = oOrderEntryModel.OrderEntry.Production_Cost;
            oOrderEntryDTO.Customer_Price = oOrderEntryModel.OrderEntry.Customer_Price;
            oOrderEntryDTO.Customer_Cost = oOrderEntryModel.OrderEntry.Customer_Cost;
            oOrderEntryDTO.GST = oOrderEntryModel.OrderEntry.GST;
            oOrderEntryDTO.Margin = oOrderEntryModel.OrderEntry.Margin;
            oOrderEntryDTO.Margin_Amount = oOrderEntryModel.OrderEntry.Margin_Amount;
            oOrderEntryDTO.Trasportation_Cost = oOrderEntryModel.OrderEntry.Trasportation_Cost;
            oOrderEntryDTO.Sales_Person = oOrderEntryModel.OrderEntry.Sales_Person;
            oOrderEntryDTO.Customer_Restaurant_Details = oOrderEntryModel.OrderEntry.Customer_Restaurant_Details;
            oOrderEntryDTO.Remark = oOrderEntryModel.OrderEntry.Remark;
            oOrderEntryDTO.IsBlack = oOrderEntryModel.OrderEntry.IsBlack;
            oOrderEntryDTO.Amount_Paid = oOrderEntryModel.OrderEntry.Amount_Paid;
            oOrderEntryDTO.Remaining_Amount = oOrderEntryModel.OrderEntry.Remaining_Amount;
            oOrderEntryDTO.Created_At = DateTime.Now;
            oOrderEntryDTO.Created_By = "System";
            if(oOrderEntryModel.OrderEntry.id == 0)
            {
                int Id = oOrderEntryAPI.AddNewOrder(oOrderEntryDTO);
                return RedirectToAction("Load", new { id = Id });
            }
            else
            {
                oOrderEntryAPI.UpdateOrder(oOrderEntryModel.OrderEntry.id, oOrderEntryDTO);
                return RedirectToAction("Load", new { id = oOrderEntryModel.OrderEntry.id });
            }


            
        }
    }
}