using AutoMapper;
using BrewApp.DTOs;
using BrewApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BrewApp.Controllers.API
{
    public class ExpenseAPIController : ApiController
    {
        private ApplicationDbContext _context;

        public ExpenseAPIController()
         {
            _context = new ApplicationDbContext();
         }

        [HttpGet]
        public IEnumerable<ExpenseMasterDTO> GetExpenseDetail()
        {
            return _context.ExpenseMaster.ToList().Select(Mapper.Map<ExpenseMaster, ExpenseMasterDTO>);
        }

        [HttpPost]
        public int SaveExpense(ExpenseMasterDTO expenseDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var expense = Mapper.Map<ExpenseMasterDTO, ExpenseMaster>(expenseDTO);

            _context.ExpenseMaster.Add(expense);

            _context.SaveChanges();

            expenseDTO.Id = expense.Id;

            return expense.Id;
        }

        [AcceptVerbs("PUT", "DELETE")]
        [HttpPut]
        public void UpdateExpense(ExpenseMasterDTO expenseDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ExpenseinDB = _context.ExpenseMaster.SingleOrDefault(c => c.Id == expenseDTO.Id);

            if (ExpenseinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(expenseDTO, ExpenseinDB);

            _context.SaveChanges();
        }
    }
}
