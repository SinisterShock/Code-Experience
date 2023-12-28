using BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorApp.Services
{
    public class DbAuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;

        public DbAuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Author>> ReadAllAsync()
        {
            return await _db.Author
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .ToListAsync();
        }
        public async Task<Author?> ReadAsync(int authorId)
        {
            return await _db.Author
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefaultAsync(a => a.Id == authorId);
        }
    }
}
