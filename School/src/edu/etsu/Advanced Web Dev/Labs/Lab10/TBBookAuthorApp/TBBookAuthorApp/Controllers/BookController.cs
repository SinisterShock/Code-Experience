using Microsoft.AspNetCore.Mvc;
using TBBookAuthorApp.Models.ViewModels;
using TBBookAuthorApp.Services;

namespace TBBookAuthorApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allBooks = await _bookRepo.ReadAllAsync();
            var model = allBooks.Select(b =>
            new BookDetailsVM
            {
                Id = b.Id,
                Title = b.Title,
                PublicationYear = b.PublicationYear,
                NumberOfAuthors = b.Authors.Count
            });
            return View(model);
        }

        public async Task<IActionResult> Details(int id) 
        {
            var book = await _bookRepo.ReadAsync(id);
            if (book == null)
            {
                return RedirectToAction("index");

            }
            var model = new BookDetailsVM
            {
                Id = book.Id,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
                NumberOfAuthors = book.Authors.Count,
                Authors = book.Authors
            };
            return View(model);
        }

    }
}
