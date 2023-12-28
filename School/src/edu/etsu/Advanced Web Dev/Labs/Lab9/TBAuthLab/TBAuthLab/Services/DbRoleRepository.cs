//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace TBAuthLab.Services
{
    public class DbRoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public DbRoleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public IQueryable<IdentityRole> ReadAll()
        {
            return _db.Roles;
        }

       
    }
}
