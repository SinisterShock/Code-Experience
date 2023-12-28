using BookAuthorApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorApp.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Book> Books => Set<Book>();
		public DbSet<Author> Author => Set<Author>();
        public DbSet<BookAuthor> BookAuthor => Set<BookAuthor>();
    }
}