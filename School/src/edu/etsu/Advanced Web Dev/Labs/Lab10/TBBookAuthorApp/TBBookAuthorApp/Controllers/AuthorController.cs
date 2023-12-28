using Microsoft.AspNetCore.Mvc;
using TBBookAuthorApp.Models.Entities;
using TBBookAuthorApp.Models.ViewModels;
using TBBookAuthorApp.Services;

namespace TBBookAuthorApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookRepository _bookRepo;
        public AuthorController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public async Task<IActionResult> CreateAuthor([Bind(Prefix ="id")] int bookId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            ViewData["Book"] = book;
            if (book != null)
            {

                return View();
            }
            return RedirectToAction("Book", "Index");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAuthorVM(int bookId, CreateAuthorVM authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = authorVM.GetPersonInstance();
                await _bookRepo.CreateAuthorAsync(bookId, author);
                return RedirectToAction("Details", "Book", $"id={bookId}");
            }
            ViewData["Book"] = await  _bookRepo.ReadAsync(bookId);
            return View(authorVM);
        }

        public async Task<IActionResult> Edit([Bind(Prefix = "id")] int bookId, int authorId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            ViewData["Book"] = book;
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }
            var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null)
            {
                return RedirectToAction("Details", "Book", $"id={bookId}");
            }
            var model = new EditAuthorVM
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Book = book
            };
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAuthor(int bookId, EditAuthorVM authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = authorVM.GetPersonInstance();
                await _bookRepo.UpdateAuthorAsync(bookId, author);
                return RedirectToAction("Details", "Book", $"id={bookId}");
            }
            authorVM.Book = await _bookRepo.ReadAsync(bookId);
            return View(authorVM);
        }

        public async Task<IActionResult> DeleteGet([Bind(Prefix = "id")] int bookId, int authorId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }
            var author = book.Authors.FirstOrDefault(a => a.Id == authorId);
            if (author == null)
            {
                return RedirectToAction("Details", "Book", $"id={bookId}");
            }
            var model = new DeleteAuthorVm
            {
                    BookDelete = book,
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName

            };
            ViewData["Book"] = book;
            return View(model);
        }


        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int bookId, int authorId)
        {
            await _bookRepo.DeleteAuthorAsync(bookId, authorId);
            return RedirectToAction("Details", "Book", $"id={bookId}");
        }

    }
}
