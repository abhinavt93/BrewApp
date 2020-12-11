using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BrewApp.Models;
using BrewApp.DTOs;
using AutoMapper;

namespace BrewApp.Controllers.API
{
    public class EmployeesAPIController : ApiController
    {
        private ApplicationDbContext _context;

        
        public EmployeesAPIController()
        {
            _context = new ApplicationDbContext();
        }

        //[HttpGet]
        //public IEnumerable<EmployeeDTO> GetEmployees()
        //{
        //    return _context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDTO>);
        //}

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            return Ok(_context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDTO>));

        }

        //[HttpGet]
        //public IHttpActionResult GetEmployee(int EmployeeID)
        //{
        //    var employee = _context.Employees.SingleOrDefault(e => e.EmployeeID == EmployeeID);

        //    if (employee == null)
        //        NotFound();

        //    return Ok(Mapper.Map<Employee, EmployeeDTO>(employee));
        //}

        

        [HttpGet]
        public EmployeeDTO GetEmployee(int EmployeeID)
        {
            var employee = _context.Employees.SingleOrDefault(e => e.EmployeeID == EmployeeID);

            if (employee == null)
                NotFound();

            return Mapper.Map<Employee, EmployeeDTO>(employee);
        }

        [HttpPost]
        public int CreateEmployee(EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);

            _context.Employees.Add(employee);
            _context.SaveChanges();

            employeeDTO.EmployeeID = employee.EmployeeID;

            return employee.EmployeeID;
        }

        //[HttpPost]
        //public IHttpActionResult CreateEmployee(EmployeeDTO employeeDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var employee = Mapper.Map<EmployeeDTO, Employee>(employeeDTO);

        //    _context.Employees.Add(employee);
        //    _context.SaveChanges();

        //    employeeDTO.EmployeeID = employee.EmployeeID;

        //    return Created(new Uri(Request.RequestUri + "/" + employee.EmployeeID), employeeDTO);
        //}

        [AcceptVerbs("PUT","DELETE")]
        [HttpPut]
        public void UpdateEmployee(int id,EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var EmployeeinDB = _context.Employees.SingleOrDefault(c => c.EmployeeID == id);

            if (EmployeeinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            employeeDTO.EmployeeID = id;

            Mapper.Map(employeeDTO, EmployeeinDB);

            _context.SaveChanges();
        }

        [HttpDelete, Route("{id}")]
        public void DeleteEmployee(int id)
        {
            var EmployeeinDB = _context.Employees.SingleOrDefault(c => c.EmployeeID == id);

            if (EmployeeinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Employees.Remove(EmployeeinDB);

            _context.SaveChanges();

        }
    }
}
