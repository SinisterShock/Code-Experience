using CRUDLecW04.Models.Entities;

namespace CRUDLecW04.Services;

public interface IPersonRepository
{
    Person Create(Person newPerson);
    Person? Read(int id);
    ICollection<Person> ReadAll();
    void Update(int oldID, Person person);
    void Delete(int id);
}
