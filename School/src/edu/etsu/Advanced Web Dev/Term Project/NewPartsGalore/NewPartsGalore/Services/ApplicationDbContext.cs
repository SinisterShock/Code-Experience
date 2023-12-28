using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Models.Entities;

namespace NewPartsGalore.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bundle> Bundles => Set<Bundle>();
        public DbSet<Vendor> Vendors => Set<Vendor>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductBundle> ProductBundles => Set<ProductBundle>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Inventory> Inventory => Set<Inventory>();

    }
}