using Microsoft.AspNetCore.Mvc;
using System;
using TBLW04CRRUD.Models.Entities;
using TBLW04CRRUD.Services;

namespace TBLW04CRRUD.Controllers
{
    public class BookController : Controller
    {
        public readonly IBookrepository _bookRepo;
        public BookController(IBookrepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book newBook)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Create(newBook);
                return RedirectToAction("Index");
            }
            return View(newBook);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepo.Read(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var book = _bookRepo.Read(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepo.Update(book.Id, book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            var book = _bookRepo.Read(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bookRepo.Delete(id);
            return RedirectToAction("Index");
        }



        public IActionResult Index()
        {
            var model = _bookRepo.ReadAll();
            return View(model);
        }
    }
}
