using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public class DBLocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _db;
        
        public DBLocationRepository(ApplicationDbContext db)
        {
            _db = db;
            
        }

        public async Task<Location> CreateAsync(Location location)
        {
            await _db.Locations.AddAsync(location);
            
            await _db.SaveChangesAsync();
            return location;
        }

        public async Task DeleteAsync(int locationId)
        {
            Location? locationToDelete = await ReadAsync(locationId);
            if (locationToDelete != null)
            {
                _db.Locations.Remove(locationToDelete);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Location>> ReadAllAsync()
        {
            return await _db.Locations.ToListAsync();
        }

        public async Task<Location> ReadAsync(int locationId)
        {
            var location = await _db.Locations.FindAsync(locationId);

            if (location != null)
            {
                _db.Entry(location)
                    .Collection(l => l.LocationInventories)
                    .Load();
            }
            return location;
        }

        public async Task UpdateAsync(int oldLocationId, Location location)
        {
            Location? locationToUpdate = await ReadAsync(oldLocationId);
            if (locationToUpdate != null)
            {
                locationToUpdate.State = location.State;
                locationToUpdate.City = location.City;
                locationToUpdate.Zip = location.Zip;
                locationToUpdate.Address = location.Address;
                locationToUpdate.Name = location.Name;
                locationToUpdate.StoreType = location.StoreType;
                await _db.SaveChangesAsync();
            }
        }
    }
}
