using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public interface IInventoryRepository
    {
        Task<ICollection<Inventory>> ReadAllAsync();
        Task<Inventory?> ReadAsync(int inventoryId);
        Task<Inventory> CreateAsync(int locationId);
        Task DeleteAsync(int inventoryId, int locationId);

    }
}
