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
    public class BookController : Controller
    {
        private BookService db;

        public BookController(BookService db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.ReadAll());
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("/add")]
        public IActionResult AddNew(Book book)
        {
            db.Add(book);
            return RedirectToAction("Index");
        }

        [HttpGet("/edit/{id}")]
        public IActionResult Edit(int id)
        {
            var bookToEdit = db.GetElementById(id);
            return View(bookToEdit);
        }

        [HttpPost("/edit/{id}")]
        public IActionResult Edit(int id, Book book)
        {
            book.BookId = id;
            db.Edit(book);
            return RedirectToAction("Index");
        }

        [HttpGet("/delete/{id}")]
        public IActionResult Remove(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet("/sell/{id}")]
        public IActionResult Sell(int id)
        {
            db.Sell(id);
            return RedirectToAction("Index");
        }

        [HttpPost("/list")]
        public IActionResult Search(string input, bool inStock)
        {
            return View("Index", db.Search(input, inStock));
        }

        [HttpGet("/forsale")]
        public IActionResult ForSale()
        {
            return View();
        }

        [HttpPost("/forsale")]
        public IActionResult ForSale(Book book)
        {
            db.Add(book);
            return RedirectToAction("Index", ForSale());
        }
    }
}