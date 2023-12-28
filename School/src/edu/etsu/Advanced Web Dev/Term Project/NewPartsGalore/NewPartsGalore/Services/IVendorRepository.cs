using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public interface IVendorRepository
    {
        Task<ICollection<Vendor>> ReadAllAsync();
        Task<Vendor?> ReadAsync(int vendorId);
        Task<Vendor> CreateAsync(Vendor vendor);
        Task UpdateAsync(int oldVendorId, Vendor vendor);
        Task DeleteAsync(int vendorId);
    }
}
