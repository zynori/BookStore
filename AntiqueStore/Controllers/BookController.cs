using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntiqueStore.Models;
using AntiqueStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace AntiqueStore.Controllers
{
    public class BookController : Controller
    {
        BookService db;

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
    }
}