using BookAuthorApp.Models.Entities;

namespace BookAuthorApp.Services
{
    public interface IAuthorRepository 
    {
        Task<IEnumerable<Author>> ReadAllAsync();
        Task<Author?> ReadAsync(int authorId);
    }
}
