using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public interface IBundleRepository
    {
        Task<ICollection<Bundle?>> ReadAllAsync();
        Task<Bundle?> ReadAsync(int bundleId);
        Task<Bundle> CreateAsync(Bundle bundle);
        Task UpdateAsync(int oldBundleId, Bundle bundle);
        Task DeleteAsync(int bundleId);
    }
}
