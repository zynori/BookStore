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
        private BookViewModel bookDTO;

        public BookController(BookService db, BookViewModel bookDTO)
        {
            this.db = db;
            this.bookDTO = bookDTO;
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
        public IActionResult Edit(Book book)
        {
            db.Edit(book);
            return RedirectToAction("Index");
        }

        [HttpGet("/delete/{id}")]
        public IActionResult Remove(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}