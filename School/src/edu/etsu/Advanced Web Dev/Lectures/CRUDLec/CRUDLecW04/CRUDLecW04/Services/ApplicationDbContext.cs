using CRUDLecW04.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDLecW04.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> People => Set<Person>();
    }
    
}
