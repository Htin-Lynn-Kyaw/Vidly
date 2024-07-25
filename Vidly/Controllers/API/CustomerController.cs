using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.Controllers.API
{
    [Authorize(Roles = SystemRoles.ADMIN)]
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        [AllowAnonymous]
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customerQuery = _context.Customers.Include(x => x.MembershipType);

            if (!string.IsNullOrEmpty(query))
            {
                customerQuery = customerQuery.Where(c => c.Name.Contains(query));
            }

            var customerDto = customerQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDto);
        }

        public IHttpActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);

            if (customer == null) return NotFound();

            Mapper.Map(customerDto, customer);

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(x => x.Id == Id);

            if (customerInDB == null) return NotFound();

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();

            return Ok();
        }
    }
}
