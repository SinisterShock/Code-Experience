using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookAuthorApp.Controllers
{
    public class BookAuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IBookAuthorRepository _bookAuthorRepo;
        public BookAuthorController(IBookRepository bookRepo, IAuthorRepository authorRepo, IBookAuthorRepository bookAuthorRepo)
        {
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
            _bookAuthorRepo = bookAuthorRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AssignAuthor([Bind(Prefix = "id")] int bookId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            ViewData["Book"] = book;

            var allAuthors = await _authorRepo.ReadAllAsync();
            var registeredBookAuthors = book.BookAuthors
                .Select(ba => ba.Author).ToList();
            //var registeredBookAuthors = book.BookAuthors
            //    .Select(author =>
            //new AuthorDetailsVM
            //{
            //    Id = author.Id,
            //    FirstName = author.FirstName,
            //    LastName = author.LastName,
            //    NumberOfBooks = author.BookAuthors.Count,
            //    BookAuthors = author.BookAuthors

            //}).ToList();
            var allOtherModels = allAuthors.Except(registeredBookAuthors);
            return View(allOtherModels);
            
        }
        // [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignToBook([Bind(Prefix = "id")]  int bookId, int authorId)
        {
            await _bookAuthorRepo.CreateAsync(bookId, authorId);
            return RedirectToAction("Index", "Book");
        }

        public async Task<IActionResult> AssignBook([Bind(Prefix = "id")] int authorId)
        {
            var author = await _authorRepo.ReadAsync(authorId);
            ViewData["Author"] = author;

            var allBooks = await _bookRepo.ReadAllAsync();
            var registeredBookAuthors = author!.BookAuthors
                .Select(ba => ba.Book).ToList();

            var allOtherModels = allBooks.Except(registeredBookAuthors);
            return View(allOtherModels);
        }

        public async Task<IActionResult> AssignToAuthor([Bind(Prefix = "id")] int bookId, int authorId)
        {
            await _bookAuthorRepo.CreateAsync(bookId, authorId);
            return RedirectToAction("Index", "Author");
        }
    }
}
