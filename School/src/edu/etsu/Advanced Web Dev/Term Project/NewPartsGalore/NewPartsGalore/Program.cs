using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NewPartsGalore.Services;
using NewPartsGalore.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVendorRepository, DBVendorRepository>();
builder.Services.AddScoped<IProductRepository, DBProductRepository>();
builder.Services.AddScoped<IProductBundleRepository, DBProductBundleRepository>();
builder.Services.AddScoped<IBundleRepository, DBBundleRepository>();
builder.Services.AddScoped<IInventoryRepository, DBInventoryRepository>();
builder.Services.AddScoped<ILocationRepository, DBLocationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{bundleId?}");
app.MapRazorPages();

app.Run();
