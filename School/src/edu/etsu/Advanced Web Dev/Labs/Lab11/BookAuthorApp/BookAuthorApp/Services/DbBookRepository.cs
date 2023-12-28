using BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookAuthorApp.Services
{
    public class DbBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public DbBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Book>> ReadAllAsync()
        {
            return await _db.Books
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .ToListAsync();

        }
        public async Task<Book> ReadAsync(int bookId)
        {
            return _db.Books
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .FirstOrDefault(b => b.Id == bookId);
        }
        /* public async Task<Author> CreateAuthorAsync(int bookId, Author author)
         {
             var book = await ReadAsync(bookId);
             if (book != null)
             {
                 book.Authors.Add(author);
                 author.Book = book;
                 await _db.SaveChangesAsync();
             }
             return author;
         }
         public async Task UpdateAuthorAsync(
             int bookId, Author author)
         {
             var book = await ReadAsync(bookId);
             if (book != null)
             {
                 var authorToUpdate = book.Authors
                 .FirstOrDefault(a => a.Id == author.Id);
                 if (authorToUpdate != null)
                 {
                     authorToUpdate.Book = book;
                     authorToUpdate.FirstName = author.FirstName;
                     authorToUpdate.LastName = author.LastName;
                     await _db.SaveChangesAsync();
                 }
             }
         }

         public async Task DeleteAuthorAsync(int bookId, int authorId)
         {
             var book = await ReadAsync(bookId);
             if (book != null)
             {
                 var author = book.Authors
                 .FirstOrDefault(a => a.Id == authorId);
                 if (author != null)
                 {
                     book.Authors.Remove(author);
                     await _db.SaveChangesAsync();
                 }
             }*/
    }
    }


