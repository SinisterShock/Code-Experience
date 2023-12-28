using BookAuthorApp.Models.Entities;

namespace BookAuthorApp.Services
{
    public class DbBookAuthorRepository : IBookAuthorRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookRepository _bookRepo;

        public DbBookAuthorRepository(ApplicationDbContext db, IAuthorRepository authorRepo, IBookRepository bookRepo)
        {
            _db = db;
            _authorRepo = authorRepo;
            _bookRepo = bookRepo;
        }

        public async Task<BookAuthor?> CreateAsync(int bookId, int authorId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            if (book == null)
            {
                // book not found
                return null;
            }
            var author = await _authorRepo.ReadAsync(authorId);
            if (author == null)
            {
                // author wasn't found
                return null;
            }
            var bookAuthor = new BookAuthor
            {
                AuthorId = authorId,
                BookId = bookId,
                Book = book,
                Author = author
            };
            book.BookAuthors!.Add(bookAuthor);
            author.BookAuthors.Add(bookAuthor);
            _db.SaveChanges();
            return bookAuthor;
        }
    }
}
