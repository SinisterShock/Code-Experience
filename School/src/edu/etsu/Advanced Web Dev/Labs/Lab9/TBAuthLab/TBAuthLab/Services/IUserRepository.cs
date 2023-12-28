using TBAuthLab.Models.Entities;

namespace TBAuthLab.Services
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> ReadByUsernameAsync(string username);
        Task<ApplicationUser> CreateAsync(ApplicationUser user, string password);
        Task AssignUserToRoleAsync(string userName, string roleName);
        Task<IQueryable<ApplicationUser>> ReadAllAsync();
        Task<bool>AssignRoleAsync(string userName, string roleName);
    }
}
