using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public interface ILocationRepository
    {
        Task<ICollection<Location>> ReadAllAsync();
        Task<Location?> ReadAsync(int locationId);
        Task<Location> CreateAsync(Location location);
        Task UpdateAsync(int oldLocationId, Location location);
        Task DeleteAsync(int locationId);

    }
}
