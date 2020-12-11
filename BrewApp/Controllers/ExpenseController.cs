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
    public class ExpenseController : Controller
    {
        private ExpenseAPIController oExpenseAPI;

        public ExpenseController()
        {
            oExpenseAPI = new ExpenseAPIController();
        }

        // GET: Expense
        public ActionResult Load(int? id)
        {
            IEnumerable<ExpenseMasterDTO> expense = oExpenseAPI.GetExpenseDetail();
            ExpenseViewModel oExpenseViewModel = new ExpenseViewModel();

            oExpenseViewModel.ExpenseMaster = expense;
            oExpenseViewModel.Mode = "Add";

            if (id != null)
            {
                ExpenseMasterDTO objTemp = expense.SingleOrDefault(r => r.Id == id);
                oExpenseViewModel.Mode = "Save";
                oExpenseViewModel.Id = (int)id;
                oExpenseViewModel.Price = objTemp.Price;
                oExpenseViewModel.ExpenseName = objTemp.ExpenseName;
            }

            return View(oExpenseViewModel);
        }

        [HttpPost]
        public ActionResult Save(ExpenseViewModel viewModel)
        {
            
            if (!ModelState.IsValid)
            {
                IEnumerable<ExpenseMasterDTO> expenses = oExpenseAPI.GetExpenseDetail();
                viewModel.ExpenseMaster = expenses;
                return View("Load", viewModel);
            }

            ExpenseMasterDTO expenseDTO = new ExpenseMasterDTO();
            expenseDTO.ExpenseName = viewModel.ExpenseName;
            expenseDTO.Price = viewModel.Price;
            expenseDTO.Id = viewModel.Id;

            if (expenseDTO.Id == 0)
                oExpenseAPI.SaveExpense(expenseDTO);
            else
                oExpenseAPI.UpdateExpense(expenseDTO);

            return RedirectToAction("Load");
        }

    }
}