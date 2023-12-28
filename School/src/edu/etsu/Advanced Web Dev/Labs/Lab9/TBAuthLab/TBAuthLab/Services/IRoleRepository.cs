//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
namespace TBAuthLab.Services
{
    public interface IRoleRepository
    {
        IQueryable<IdentityRole> ReadAll();

    }
}
