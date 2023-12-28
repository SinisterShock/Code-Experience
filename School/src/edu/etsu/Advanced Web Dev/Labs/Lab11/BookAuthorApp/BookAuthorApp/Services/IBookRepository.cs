using BookAuthorApp.Models.Entities;

namespace BookAuthorApp.Services
{
	public interface IBookRepository
	{
        Task<IEnumerable<Book>> ReadAllAsync();
        Task<Book> ReadAsync(int bookId);
        /*Task<Author>? CreateAuthorAsync(int bookId, Author author);
        Task UpdateAuthorAsync(int bookId, Author author);
        Task DeleteAuthorAsync(int bookId, int authorId);*/
    }
}
