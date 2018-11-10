using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntiqueStore.Models;
using AntiqueStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AntiqueStore.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService db;

        public CustomerController(CustomerService db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.GetAll());
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            return View(db.GetAll());
        }

        [HttpPost("/add")]
        public IActionResult AddNew(Customer customer)
        {
            db.AddCustomer(customer);
            return RedirectToAction("Index");
        }
    }
}