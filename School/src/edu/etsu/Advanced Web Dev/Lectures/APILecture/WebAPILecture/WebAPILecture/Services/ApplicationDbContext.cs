using Microsoft.EntityFrameworkCore;
using WebAPILecture.Models.Entities;

namespace WebAPILecture.Services;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Pet> Pets => Set<Pet>();
}

