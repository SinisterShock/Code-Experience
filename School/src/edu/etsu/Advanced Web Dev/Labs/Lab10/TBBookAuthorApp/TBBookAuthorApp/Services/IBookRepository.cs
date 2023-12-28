using TBBookAuthorApp.Models.Entities;

namespace TBBookAuthorApp.Services
{
    public interface IBookRepository
    {
        Task <ICollection<Book>> ReadAllAsync();
        Task<Book?> ReadAsync(int id);
        Task<Author> CreateAuthorAsync(int bookID, Author author);
        Task UpdateAuthorAsync(int bookId, Author updatedAuthor);
        Task DeleteAuthorAsync(int bookId, int authorId);
    }
}
