using Microsoft.EntityFrameworkCore;
using TBBookAuthorApp.Models.Entities;

namespace TBBookAuthorApp.Services
{
    public class DbBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;   
        public DbBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Author> CreateAuthorAsync(int bookId, Author author)
        {
            var book = await ReadAsync(bookId);
            if (book != null)
            {
                book.Authors.Add(author);
                author.Book= book;
                await _db.SaveChangesAsync();
            }
            return author;
        }

        public async Task DeleteAuthorAsync(int bookId, int authorId)
        {
            var book = await ReadAsync(bookId);
            if (book != null)
            {
                var authorToDelete = book.Authors.FirstOrDefault(a => a.Id == authorId);
                if (authorToDelete != null)
                {
                    book.Authors.Remove(authorToDelete);
                    await _db.SaveChangesAsync();
                }
            }
        }

        public async Task<ICollection<Book>> ReadAllAsync()
        {
            return await _db.Books
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public async Task<Book?> ReadAsync(int id)
        {
            var book = await _db.Books.FindAsync(id);

            if (book != null)
            {
                _db.Entry(book)
                    .Collection(b => b.Authors)
                    .Load();
            }
            return book;
        }

        public async Task UpdateAuthorAsync(int bookId, Author updatedAuthor)
        {
            var book = await ReadAsync(bookId);
            if (book != null )
            {
                var authorToUpdate = book.Authors.FirstOrDefault(a => a.Id == updatedAuthor.Id);
                if (authorToUpdate != null)
                {
                    authorToUpdate.FirstName = updatedAuthor.FirstName;
                    authorToUpdate.LastName = updatedAuthor.LastName;
                    await _db.SaveChangesAsync();
                }
            }
        }
    }
}
