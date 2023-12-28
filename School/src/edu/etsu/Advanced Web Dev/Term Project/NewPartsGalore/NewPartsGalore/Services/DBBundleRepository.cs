using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public class DBBundleRepository : IBundleRepository
    {
        private readonly ApplicationDbContext _db;
        public DBBundleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<Bundle> CreateAsync(Bundle bundle)
        {
            await _db.Bundles.AddAsync(bundle);
            await _db.SaveChangesAsync();
            return bundle;
        }

        public async Task DeleteAsync(int bundleId)
        {
            Bundle? bundleToDelete = await ReadAsync(bundleId);
            if (bundleToDelete != null)
            {
                _db.Bundles.Remove(bundleToDelete);
                _db.SaveChanges();
            }
        }

        public async Task<ICollection<Bundle?>> ReadAllAsync()
        {
            return await _db.Bundles
                .Include(b => b.ProductBundles)
                .ThenInclude(pb => pb.Product)
                .ToListAsync();
        }

        public async Task<Bundle?> ReadAsync(int bundleId)
        {
            return await _db.Bundles
                .Include(b => b.ProductBundles)
                .ThenInclude(pb => pb.Product)
                .FirstOrDefaultAsync(b => b.Id == bundleId);
        }

        public async Task UpdateAsync(int oldBundleId, Bundle bundle)
        {
            Bundle? bundleToUpdate = await ReadAsync(oldBundleId);
            if (bundleToUpdate != null)
            {
                bundleToUpdate.SerialNumber = bundle.SerialNumber;
                bundleToUpdate.Price = bundle.Price;
                bundleToUpdate.Description = bundle.Description;
                bundleToUpdate.Name = bundle.Name;
                await _db.SaveChangesAsync();
            }
        }
    }
}
