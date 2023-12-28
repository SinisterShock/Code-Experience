using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public interface IProductRepository
    {
        Task<ICollection<Product?>> ReadAllAsync();
        Task<Product?> ReadAsync(int productId);
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(int oldProductId, Product product);
        Task DeleteAsync(int productId);
    }
}
