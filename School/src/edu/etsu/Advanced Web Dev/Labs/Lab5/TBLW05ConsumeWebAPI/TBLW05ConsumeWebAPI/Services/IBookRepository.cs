using TBLW05ConsumeWebAPI.Models.Entities;

namespace TBLW05ConsumeWebAPI.Services;

public interface IBookrepository
{
    Task<ICollection<Book>> ReadAllAsync();
}
