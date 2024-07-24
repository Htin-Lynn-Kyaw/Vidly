using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        [HttpPut]
        public void UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(x => x.Id == Id);

            if (customerInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDB.Name = customer.Name;
            customerInDB.BirthDate = customer.BirthDate;
            customerInDB.IsSubscribed = customer.IsSubscribed;
            customerInDB.MembershipTypeID = customer.MembershipTypeID;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDB = _context.Customers.SingleOrDefault(x => x.Id == Id);

            if (customerInDB == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();
        }
    }
}
