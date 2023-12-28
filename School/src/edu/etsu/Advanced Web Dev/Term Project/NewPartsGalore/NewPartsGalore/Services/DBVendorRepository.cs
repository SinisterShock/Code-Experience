using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Models.Entities;
using System.Security.Cryptography;

namespace NewPartsGalore.Services
{
    public class DBVendorRepository : IVendorRepository
    {
        private readonly ApplicationDbContext _db;
        public DBVendorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Vendor> CreateAsync(Vendor vendor)
        {
            await _db.Vendors.AddAsync(vendor);
            await _db.SaveChangesAsync();
            return vendor;
        }

        public async Task DeleteAsync(int vendorId)
        {
            Vendor? vendorToDelete = await ReadAsync(vendorId);
            if (vendorToDelete != null)
            {
                _db.Vendors.Remove(vendorToDelete);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Vendor>> ReadAllAsync()
        {
            return await _db.Vendors.ToListAsync();
        }

        public async Task<Vendor?> ReadAsync(int vendorId)
        {
            var vendor = await _db.Vendors.FindAsync(vendorId);

            if (vendor != null)
            {
                _db.Entry(vendor)
                    .Collection(v => v.Products)
                    .Load();
            }
            return vendor;
        }

        public async Task UpdateAsync(int oldVendorId, Vendor vendor)
        {
            Vendor? vendorToUpdate = await ReadAsync(oldVendorId);
            if (vendorToUpdate != null)
            {
                vendorToUpdate.Representative = vendor.Representative;
                vendorToUpdate.State = vendor.State;
                vendorToUpdate.Address = vendor.Address;
                vendorToUpdate.City = vendor.City;
                vendorToUpdate.Name = vendor.Name;
                vendorToUpdate.PhoneNumber = vendor.PhoneNumber;
                vendorToUpdate.Zip = vendor.Zip;
                await _db.SaveChangesAsync();
            }
        }
    }
}
