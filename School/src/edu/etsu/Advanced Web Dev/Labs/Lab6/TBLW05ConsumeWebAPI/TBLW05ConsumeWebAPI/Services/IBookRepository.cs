using TBLW05ConsumeWebAPI.Models.Entities;

namespace TBLW05ConsumeWebAPI.Services;

public interface IBookrepository
{
    Task<ICollection<Book>> ReadAllAsync();
    Task<Book?> ReadAsync(int id);
    Task<Book?> CreateAsync(Book book);
    Task UpdateAsync(int oldID,Book book);
    Task DeleteAsync(int id);
}
