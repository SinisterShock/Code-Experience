using BookAuthorApp.Models.Entities;
using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorApp.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookRepository _bookRepo;

		public BookController(IBookRepository bookRepo)
		{
			_bookRepo = bookRepo;
		}

		public async Task<IActionResult> Index()
		{
            var allBooks = await _bookRepo.ReadAllAsync();
            var model = allBooks.Select(book =>
            new BookDetailsVM
            {
                Id = book.Id,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
                NumberOfAuthors = book.BookAuthors.Count,
                BookAuthors = book.BookAuthors

            }) ;
            return View(model);
        }
        
       /* public async Task<IActionResult> Details(int id)
        {
            
            var book = await _bookRepo.ReadAsync(id);

            
            if (book == null)
            {
                
                return RedirectToAction("Index");
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
        }*/

    }
}
