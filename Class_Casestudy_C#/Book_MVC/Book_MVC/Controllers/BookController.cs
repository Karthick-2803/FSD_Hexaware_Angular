using Book_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_MVC.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View(Book.BookList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (Book.BookList.Any(b => b.Isbn == book.Isbn))
            {
                ModelState.AddModelError("Isbn", "ISBN must be unique");
            }

            if (ModelState.IsValid)
            {
                Book.BookList.Add(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}
