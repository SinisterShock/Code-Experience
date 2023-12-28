using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Models.Entities;
using System.Net;

namespace NewPartsGalore.Services
{
    public class DBProductBundleRepository : IProductBundleRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IProductRepository _productRepo;
        private readonly IBundleRepository _bundleRepo;
        public DBProductBundleRepository(ApplicationDbContext db, IProductRepository productRepo, IBundleRepository bundleRepo)
        {
            _db = db;
            _productRepo = productRepo;
            _bundleRepo = bundleRepo;
        }

        public async Task<ProductBundle> CreateAsync(int productId, int bundleId)
        {
            var product = await _productRepo.ReadAsync(productId);
            if (product == null)
            {
                // product not found
                return null;
            }
            var bundle = await _bundleRepo.ReadAsync(bundleId);
            if (bundle == null)
            {
                // bundle wasn't found
                return null;
            }
            var productBundle = new ProductBundle
            {
                ProductId = productId,
                BundleId = bundleId,
                Product = product,
                Bundle = bundle
            };
            product.ProductBundles!.Add(productBundle);
            bundle.ProductBundles.Add(productBundle);
            await _db.SaveChangesAsync();
            return productBundle;
        }

        public async Task DeleteAsync(int productId, int productBundleId)
        {
            var product = await _productRepo.ReadAsync(productId);
            var productBundle = product!.ProductBundles
                .FirstOrDefault(pd => pd.Id == productBundleId);
            var bundle = productBundle!.Bundle;
            product!.ProductBundles.Remove(productBundle);
            bundle!.ProductBundles.Remove(productBundle);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductBundle> ReadAsync(int Id)
        {
            return _db.ProductBundles
                .Include(pb => pb.Product)
                .Include(pb => pb.Bundle)
                .FirstOrDefault(pb => pb.Id == Id);
        }


        public async Task<ICollection<ProductBundle?>> ReadAllAsync()
        {
            return await _db.ProductBundles
                .Include(pb => pb.Product)
                .Include(pb => pb.Bundle)
                .ToListAsync();
        }
    }
}
