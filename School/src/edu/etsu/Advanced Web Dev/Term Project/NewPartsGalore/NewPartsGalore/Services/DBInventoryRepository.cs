using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public class DBInventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILocationRepository _locationRepo;
        public DBInventoryRepository(ApplicationDbContext db, ILocationRepository locationRepository)
        {
            _db = db;
            _locationRepo = locationRepository;
        }

        public async Task<Inventory> CreateAsync(int locationId)
        {
            var location = await _locationRepo.ReadAsync(locationId);
            if (location == null)
            {
                // location was null
                return null;
            }
            var inventoryCreate = new Inventory
            {
                LocationId = locationId
            };
            location.LocationInventories!.Add(inventoryCreate);
            await _db.SaveChangesAsync();
            return inventoryCreate;
        }

        public async Task DeleteAsync(int inventoryId, int locationId)
        {
            var location = await _locationRepo.ReadAsync(locationId);
            if (location != null)
            {
                var inv = location.LocationInventories
                    .FirstOrDefault(i => i.Id == inventoryId);
                if (inv != null)
                {
                    location.LocationInventories.Remove(inv);
                    await _db.SaveChangesAsync();
                }
            }
        }

        public async Task<ICollection<Inventory>> ReadAllAsync()
        {
            return await _db.Inventory.ToListAsync();
        }

        public async Task<Inventory?> ReadAsync(int inventoryId)
        {
            var inventory = await _db.Inventory.FindAsync(inventoryId);

            if (inventory != null)
            {
                _db.Entry(inventory)
                    .Collection(i => i.Products)
                    .Load();
            }
            return inventory;
        }

        
    }
}
