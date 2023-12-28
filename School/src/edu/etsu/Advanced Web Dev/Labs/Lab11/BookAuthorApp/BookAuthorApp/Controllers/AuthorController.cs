using BookAuthorApp.Models.Entities;
using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }
        public async Task<IActionResult> Index()
        {
            var allAuthors = await _authorRepo.ReadAllAsync();
            var model = allAuthors.Select(author =>
            new AuthorDetailsVM
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                NumberOfBooks = author.BookAuthors.Count,
                BookAuthors = author.BookAuthors

            });
            return View(model);
        }
        /*public async Task<IActionResult> Create([Bind(Prefix = "id")] int bookId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Details", "Book", $"id={bookId}");
            }

            var createAuthorVM = new CreateAuthorVM
            {
                Book = book,

            };
            ViewData["Book"] = book;
            return View(createAuthorVM);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        int bookId, CreateAuthorVM authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = authorVM.GetAuthorInstance();
                await _bookRepo.CreateAuthorAsync(bookId, author);
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var book = await _bookRepo.ReadAsync(bookId);
            authorVM.Book = book;
            ViewData["Book"] = book;
            return View(authorVM);
        }*/

        /*public async Task<IActionResult> Edit([Bind(Prefix = "id")] int bookId, int authorId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var author =
           // book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null)
            {
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var model = new EditAuthorVM
            {
                Book = book,
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BookId = book.Id
            };
            ViewData["Book"] = book;
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
         int bookId, EditAuthorVM authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = authorVM.GetAuthorInstance();
                await _bookRepo.UpdateAuthorAsync(bookId, author);
                return RedirectToAction("Details", "Book", new { id = bookId });

            }
            authorVM.Book = await _bookRepo.ReadAsync(bookId);
            return View(authorVM);
        }*/

        /*public async Task<IActionResult> Delete(
        [Bind(Prefix = "id")] int bookId, int authorId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Details", "Book", new { id = bookId });
            }
            var author =
            book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null)
            {
                return RedirectToAction(
                "Details", "Book", new { id = bookId });
            }
            var model = new DeleteAuthorVM
            {
                Book = book,
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return View(model);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, int bookId)
        {
            await _bookRepo.DeleteAuthorAsync(bookId, id);
            return RedirectToAction("Details", "Book", new { id = bookId });
        }*/
    }
}

