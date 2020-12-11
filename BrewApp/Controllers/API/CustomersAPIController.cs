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
    public class CustomersAPIController : ApiController
    {
        private ApplicationDbContext _context;

        
        public CustomersAPIController()
        {
            _context = new ApplicationDbContext();
        }

        //[HttpGet]
        //public IEnumerable<CustomerDTO> GetCustomers()
        //{
        //    return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        //}

        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>));

        }

        //[HttpGet]
        //public IHttpActionResult GetCustomer(int CustomerID)
        //{
        //    var customer = _context.Customers.SingleOrDefault(e => e.CustomerID == CustomerID);

        //    if (customer == null)
        //        NotFound();

        //    return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        //}

        

        [HttpGet]
        public CustomerDTO GetCustomer(int CustomerID)
        {
            var customer = _context.Customers.SingleOrDefault(e => e.CustomerID == CustomerID);

            if (customer == null)
                NotFound();

            return Mapper.Map<Customer, CustomerDTO>(customer);
        }

        [HttpPost]
        public int CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.CustomerID = customer.CustomerID;

            return customer.CustomerID;
        }

        //[HttpPost]
        //public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest();

        //    var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

        //    _context.Customers.Add(customer);
        //    _context.SaveChanges();

        //    customerDTO.CustomerID = customer.CustomerID;

        //    return Created(new Uri(Request.RequestUri + "/" + customer.CustomerID), customerDTO);
        //}

        [AcceptVerbs("PUT","DELETE")]
        [HttpPut]
        public void UpdateCustomer(int id,CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var CustomerinDB = _context.Customers.SingleOrDefault(c => c.CustomerID == id);

            if (CustomerinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerDTO.CustomerID = id;

            Mapper.Map(customerDTO, CustomerinDB);

            _context.SaveChanges();
        }

        [HttpDelete, Route("{id}")]
        public void DeleteCustomer(int id)
        {
            var CustomerinDB = _context.Customers.SingleOrDefault(c => c.CustomerID == id);

            if (CustomerinDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(CustomerinDB);

            _context.SaveChanges();

        }
    }
}
