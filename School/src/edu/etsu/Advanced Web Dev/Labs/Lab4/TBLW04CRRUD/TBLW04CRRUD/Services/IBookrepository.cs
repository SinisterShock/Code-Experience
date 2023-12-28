using TBLW04CRRUD.Models.Entities;

namespace TBLW04CRRUD.Services;

public interface IBookrepository
{
    ICollection<Book> ReadAll();
    Book Create(Book newBook);
    Book? Read(int id);
    void Update(int oldId, Book book);
    void Delete(int id);
}
