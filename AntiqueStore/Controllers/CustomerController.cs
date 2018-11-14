using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntiqueStore.Models;
using AntiqueStore.Services;
using AntiqueStore.ViewModel;
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
            return View(db.GetAllCustomer());
        }

        [HttpGet("/customer/add")]
        public IActionResult Add()
        {
            return View(db.GetAllCustomer());
        }

        [HttpPost("/customer/add")]
        public IActionResult AddNew(Customer customer)
        {
            db.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        [HttpGet("/customer/edit/{id}")]
        public IActionResult Edit(int id)
        {
            CustomerViewModel customerToEdit = db.GetAllCustomer();
            customerToEdit.SelectedCustomer = db.GetCustomerById(id);
            return View(customerToEdit);
        }

        [HttpPost("/customer/edit/{id}")]
        public IActionResult Edit(int id, Customer customer)
        {
            customer.Id = id;
            db.EditCustomer(customer);
            return RedirectToAction("Index");
        }

        [HttpGet("/customer/view/{id}")]
        public IActionResult View(int id, Customer customer)
        {
            return View();
        }
    }
}