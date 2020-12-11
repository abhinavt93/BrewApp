using AutoMapper;
using BrewApp.DTOs;
using BrewApp.Models;
using BrewApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace BrewApp.Controllers.API
{
    public class OrderEntryAPIController : ApiController
    {
        private ApplicationDbContext _context;

        public OrderEntryAPIController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<EmployeeDTO> GetEmployeesList()
        {
            return _context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDTO>);
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomersList()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        [HttpPut]
        public double UpdateProcessedBrewingMaster(int recipeId)
        {
            IEnumerable<BrewingMaster> oBrewingData = _context.BrewingMaster.Where(c => c.Recipeid == recipeId).ToList();

            double Quantity = 0.0;
            double ProductionPrice = 0.0;
            string RecipeName = "";
            Boolean flag = false;

            //foreach (var brewData in oBrewingData)
            //{
            //    if(brewData.Processed_YN == "N" && DateTime.Compare(brewData.BrewingTime, DateTime.Now) < 0)
            //    {
            //        Quantity = Quantity + brewData.Quantity;
            //        ProductionPrice = ProductionPrice + (brewData.Quantity * brewData.ProductionPrice);
            //        RecipeName = brewData.RecipeName;

            //        brewData.Processed_YN = "Y";
            //        flag = true;
            //    }
            //}

            if (flag == true)
            {
                ProductionPrice = ProductionPrice / Quantity;

                var RecipeinDB = _context.Processed_BrewingMaster.SingleOrDefault(c => c.Recipeid == recipeId);

                Processed_BrewingMaster oProcessedBrewingMaster = new Processed_BrewingMaster();

                if (RecipeinDB == null)
                {
                    oProcessedBrewingMaster.Recipeid = recipeId;
                    oProcessedBrewingMaster.RecipeName = RecipeName;
                    oProcessedBrewingMaster.Quantity = Quantity;
                    oProcessedBrewingMaster.ProductionPrice = ProductionPrice;

                    _context.Processed_BrewingMaster.Add(oProcessedBrewingMaster);
                }
                else
                {
                    RecipeinDB.Quantity = RecipeinDB.Quantity + Quantity;
                    RecipeinDB.ProductionPrice = RecipeinDB.ProductionPrice + ProductionPrice;
                }
                //_context.SaveChanges();
            }

            //var Recipe = _context.Processed_BrewingMaster.SingleOrDefault(c => c.Recipeid == recipeId);

            return 0;

        }

        [HttpPost]
        public int AddNewOrder(OrderEntryDTO orderDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var order = Mapper.Map<OrderEntryDTO, OrderEntry>(orderDTO);

            _context.OrderEntry.Add(order);

            //var Recipe = _context.Processed_BrewingMaster.SingleOrDefault(c => c.Recipeid == orderDTO.Recipeid);

            //if (Recipe == null)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);

            //Recipe.Quantity = Recipe.Quantity - orderDTO.Order_Quantity;

            _context.SaveChanges();

            orderDTO.id = order.id;

            return orderDTO.id;
        }

        [HttpPost]
        public void UpdateOrder(int id, OrderEntryDTO orderDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var order = _context.OrderEntry.SingleOrDefault(c => c.id == id);

            if (order == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            orderDTO.id = id;

            Mapper.Map(orderDTO, order);

            _context.SaveChanges();
        }

        [HttpGet]
        public OrderEntryDTO GetOrderDetails(int orderId)
        {
            OrderEntry OrderDetails;
            OrderDetails = _context.OrderEntry.SingleOrDefault(e => e.id == orderId);

            if (OrderDetails == null)
                NotFound();

            return Mapper.Map<OrderEntry, OrderEntryDTO>(OrderDetails);
        }

        [HttpGet]
        public double GetProductionPriceRecipe(int recipeId)
        {
            CommonDBEntities7 _blotterContext = new CommonDBEntities7();
            var RecipeDetails = _blotterContext.vw_Recipe_Report.SingleOrDefault(c => c.Recipeid == recipeId);
            return RecipeDetails.ProductionPrice;
        }
    }


}