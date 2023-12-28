using Microsoft.AspNetCore.Mvc;
using NewPartsGalore.Models.Entities;
using NewPartsGalore.Services;

namespace NewPartsGalore.Controllers
{
    public class BundleController : Controller
    {
        private readonly IBundleRepository _bundleRepo;
        private readonly IProductRepository _productRepo;
        public BundleController(IBundleRepository bundleRepository, IProductRepository productRepo)
        {
            _bundleRepo = bundleRepository;
            _productRepo = productRepo;
        }
        /// <summary>
        /// Displays the list of all bundles
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var allBundles = await _bundleRepo.ReadAllAsync();
            var model = allBundles.ToList();
            return View(model);
        }

        /// <summary>
        /// Uses the Read function to display the details of a bundle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var bundle = await _bundleRepo.ReadAsync(id);

            if (bundle != null)
            {
                return View(bundle);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays a form to create a bundle
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            return View();
        }

        /// <summary>
        /// Checks if the model is correct the uses the Create function to add the record to the database
        /// </summary>
        /// <param name="newBundle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Bundle newBundle)
        {
            if (ModelState.IsValid)
            {
                await _bundleRepo.CreateAsync(newBundle);
                return RedirectToAction("Index", "Bundle");
            }
            return View(newBundle);
        }

        /// <summary>
        /// Displays a an edittable form to alter a current bundle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            var bundle = await _bundleRepo.ReadAsync(id);
            if (bundle == null)
            {
                return RedirectToAction("Index");
            }
            return View(bundle);
        }
        /// <summary>
        /// Checks the model of the bundle and uses the update function to make the user's desired changes
        /// </summary>
        /// <param name="bundle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Bundle bundle)
        {
            if (ModelState.IsValid)
            {
                await _bundleRepo.UpdateAsync(bundle.Id, bundle);
                return RedirectToAction("Index");
            }
            return View(bundle);
        }

        /// <summary>
        /// handles the delete function to remove the bundle from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bundleRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Landing page to assign a product to a bundle using a many-many relationship
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AsignBundle(
        [Bind(Prefix = "id")] int productId)
        {
            var product = await _productRepo.ReadAsync(productId);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            var allBundles = await _bundleRepo.ReadAllAsync();
            var bundlesWithProducts = product.ProductBundles
            .Select(pb => pb.Bundle).ToList();
            var bundleNotWithProducts = allBundles.Except(bundlesWithProducts);
            ViewData["Product"] = product;
            return View(bundleNotWithProducts);
        }
    }
}
