using NewPartsUsers.Models.Entities;

namespace NewPartsUsers.Services
{
    public interface IUserRepository
    {
        ICollection<User> ReadAll();
        User Create(User newUser);
        User? Read(int id);
        void Update(int oldId, User user);
        void Delete(int id);
    }
}
