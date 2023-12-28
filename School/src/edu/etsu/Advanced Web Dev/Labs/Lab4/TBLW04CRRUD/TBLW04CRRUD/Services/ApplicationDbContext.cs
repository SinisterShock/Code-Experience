using Microsoft.EntityFrameworkCore;
using TBLW04CRRUD.Models.Entities;

namespace TBLW04CRRUD.Services;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions options) : base(options)
	{

	}
	public DbSet<Book> Books => Set<Book>();
}
