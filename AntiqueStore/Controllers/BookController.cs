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
            return View(db.GetAll());
        }

        [HttpGet("/add")]
        public IActionResult Add()
        {
            return View(db.GetAll());
        }

        [HttpPost("/add")]
        public IActionResult AddNew(Book book)
        {
            db.AddBook(book);
            return RedirectToAction("Index");
        }

        [HttpGet("/edit/{id}")]
        public IActionResult Edit(int id)
        {
            BookViewModel bookToEdit = db.GetAll();
            bookToEdit.SelectedBook = db.GetBookById(id);
            return View(bookToEdit);
        }

        [HttpPost("/edit/{id}")]
        public IActionResult Edit(int id, Book book)
        {
            book.Id = id;
            db.EditBook(book);
            return RedirectToAction("Index");
        }

        [HttpGet("/delete/{id}")]
        public IActionResult Remove(int id)
        {
            db.DeleteBook(id);
            return RedirectToAction("Index");
        }

        [HttpGet("/sell/{id}")]
        public IActionResult Sell(int id)
        {
            db.SellBook(id);
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
            db.ForSale(book);

            return RedirectToAction("View", book.Id);
        }

        [HttpGet("/view/{id}")]
        public IActionResult View(int id, Book book)
        {
            book.Id = id;
            Book bookDetail = db.GetBookById(id);
            return View(bookDetail);
        }
    }
}