using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public class DBProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IInventoryRepository _invRepo;
        private readonly ILocationRepository _locRepo;
        public DBProductRepository(ApplicationDbContext db, IInventoryRepository inventoryRepository, ILocationRepository locRepo)
        {
            _db = db;
            _invRepo = inventoryRepository;
            _locRepo = locRepo;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _db.Products.AddAsync(product);
            var inv = await _invRepo.ReadAsync(product.InventoryId);
            inv!.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int productId)
        {
            Product? productToDelete = await ReadAsync(productId);
            if (productToDelete != null)
            {
                _db.Products.Remove(productToDelete);
                await _db.SaveChangesAsync();
            }
        } 

        public async Task<ICollection<Product?>> ReadAllAsync()
        {
            return await _db.Products
                .Include(p => p.ProductBundles)
                .ThenInclude(pb => pb.Bundle)
                .ToListAsync();
        }

        public async Task<Product> ReadAsync(int productId)
        {
            return _db.Products
                .Include(p => p.ProductBundles)
                .ThenInclude(pb => pb.Bundle)
                .FirstOrDefault(p => p.Id == productId);
        }

        public async Task UpdateAsync(int oldProductId, Product product)
        {
            Product? productToUpdate = await ReadAsync(oldProductId);
            if (productToUpdate != null)
            {
                productToUpdate.SerialNumber = product.SerialNumber;
                productToUpdate.Price = product.Price;
                productToUpdate.VendorId = product.VendorId;
                productToUpdate.InventoryId = product.InventoryId;
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                await _db.SaveChangesAsync();
            }
        }
    }
}
