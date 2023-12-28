using Microsoft.AspNetCore.Mvc;
using NewPartsGalore.Models.Entities;
using NewPartsGalore.Services;
namespace NewPartsGalore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly ILocationRepository _locationRepo;
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IBundleRepository _bundleRepo;
        private readonly IProductBundleRepository _productBundleRepo;
        public ProductController(IProductRepository productRepository, ILocationRepository locationRepo, IInventoryRepository inventoryRepo, IBundleRepository bundleRepository, IProductBundleRepository productBundleRepo)
        {
            _productRepo = productRepository;
            _locationRepo = locationRepo;
            _inventoryRepo = inventoryRepo;
            _bundleRepo = bundleRepository;
            _productBundleRepo = productBundleRepo;
        }
        /// <summary>
        /// Displays a list of all products using the Read all function
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var allProducts = await _productRepo.ReadAllAsync();
            var model = allProducts.ToList();
            return View(model);
        }

        /// <summary>
        /// displays info about a selected product including the product details, assigned bundles, and where the product is located
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async  Task<IActionResult> Details(int id)
        {
            var product = await _productRepo.ReadAsync(id);
            var inventory = await _inventoryRepo.ReadAsync(product!.InventoryId);
            var location = await _locationRepo.ReadAsync(inventory.LocationId);
            ViewData["location"] = location;
                    
            if (product != null)
            {
                return View(product);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// displays a form for the user to create a new product
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            return View();
        }
        /// <summary>
        /// checks the model of the submitted product and uses the create function to add the record to the database
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<IActionResult> Create(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                await _productRepo.CreateAsync(newProduct);
                return RedirectToAction("Index", "Product");
            }
            return View(newProduct);
        }
        /// <summary>
        /// Displays a form for the user to edit an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.ReadAsync(id);
            
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
        /// <summary>
        /// when the editted product is submitted, it checks the model then alters the record using the update function
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productRepo.UpdateAsync(product.Id, product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        /// <summary>
        /// When the delete has been confirmed the action handles removing the record from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// displays a page to assign a product to the bundle. 
        /// </summary>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AssignProduct(
        [Bind(Prefix = "id")] int bundleId)
        {
            var bundle = await _bundleRepo.ReadAsync(bundleId);
            if (bundle == null)
            {
                return RedirectToAction("Index", "Bundle");
            }
            var allProducts = await _productRepo.ReadAllAsync();
            var productsInBundles = bundle.ProductBundles
            .Select(pb => pb.Product).ToList();
            var productsNotInBundles = allProducts.Except(productsInBundles);
            ViewData["Bundle"] = bundle;
            return View(productsNotInBundles);
        }
    }
}
