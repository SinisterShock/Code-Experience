using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public interface IProductBundleRepository
    {
        Task<ProductBundle> CreateAsync(int productId, int bundleId);
        Task DeleteAsync(int productId, int bundleId);
        Task<ICollection<ProductBundle?>> ReadAllAsync();
        Task<ProductBundle?> ReadAsync(int Id);
    }
}
