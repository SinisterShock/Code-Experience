using CRUDLecW04.Models.Entities;
using System.Security.Cryptography;

namespace CRUDLecW04.Services
{
    public class DbPersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _db;

        public DbPersonRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            Person? personToDelete = Read(id);
            if (personToDelete != null)
            {
                _db.People.Remove(personToDelete);
                _db.SaveChanges();
            }
        }

        public Person Create(Person newPerson)
        {
            _db.People.Add(newPerson);
            _db.SaveChanges();
            return newPerson;
        }

        public Person? Read(int id)
        {
            return _db.People.Find(id);
        }

        public void Update(int oldID, Person person)
        {
            Person? personToUpdate = Read(oldID);
            if (personToUpdate != null)
            {
                personToUpdate.FirstName = person.FirstName;
                personToUpdate.MiddleName = person.MiddleName;
                personToUpdate.LastName = person.LastName;
                personToUpdate.DateOfBirth = person.DateOfBirth;
                _db.SaveChanges();
            }
        }

        ICollection<Person> IPersonRepository.ReadAll()
        {
            return _db.People.ToList();
        }


    }
}
