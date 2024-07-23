﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //public CustomerController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public async Task<ViewResult> CustomerForm()
        {
            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            CustomerFormViewModel viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.ID == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(x => x.ID == customer.ID);
                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribed = customer.IsSubscribed;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Customer
        public async Task<ViewResult> Index()
        {
            var customers = await _context.Customers.Include(c => c.MembershipType).ToListAsync();

            return View(customers);
        }

        public async Task<ActionResult> Details(int? id)
        {
            var customer = await _context.Customers.Include(c => c.MembershipType).SingleOrDefaultAsync(x => x.ID == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _context.Customers.Include(c => c.MembershipType).SingleOrDefaultAsync(x => x.ID == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}