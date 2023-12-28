using BookAuthorApp.Models.Entities;

namespace BookAuthorApp.Services
{
    public interface IBookAuthorRepository
    {
        Task<BookAuthor?> CreateAsync(int bookId, int authorId);
    }
}
