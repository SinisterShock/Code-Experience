using NewPartsUsers.Models.Entities;

namespace NewPartsUsers.Services
{
    public class DbUserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public DbUserRepository(ApplicationDbContext applicationDb)
        {
            _db= applicationDb;
        }
        public User Create(User newUser)
        {
            _db.PartUsers.Add(newUser);
            _db.SaveChanges();
            return newUser;
        }

        public void Delete(int id)
        {
            User? userToDelete = Read(id);
            if (userToDelete != null)
            {
                _db.PartUsers.Remove(userToDelete);
                _db.SaveChanges();
            }
        }

        public User? Read(int id)
        {
            return _db.PartUsers.Find(id);
        }

        public ICollection<User> ReadAll()
        {
            return _db.PartUsers.ToList();
        }

        public void Update(int oldId, User user)
        {
            User? userToUpdate = Read(oldId);
            if (userToUpdate != null)
            {
                userToUpdate.Title = user.Title;
                userToUpdate.Email = user.Email;
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;


                _db.SaveChanges();
            }
        }
    }
}
