using Microsoft.AspNetCore.Mvc;
using NewPartsGalore.Models.Entities;
using NewPartsGalore.Services;

namespace NewPartsGalore.Controllers
{
    public class ProductBundleController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IBundleRepository _bundleRepo;
        private readonly IProductBundleRepository _productBundleRepo;
        public ProductBundleController(IBundleRepository bundleRepo, IProductBundleRepository productBundleRepo, IProductRepository productRepository)
        {
            _bundleRepo = bundleRepo;
            _productBundleRepo = productBundleRepo;
            _productRepo = productRepository;
        }
        /// <summary>
        /// not used
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// when given a productId( id ) and bundleId, this action will use the create function to create a new linking table record.
        /// This then creates a many-many relation ship with product and bundle.
        /// Then redirect the user to bundle details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateConfirmedBundle(int id, int bundleId)
        {
            await _productBundleRepo.CreateAsync(id, bundleId);
            return RedirectToAction("Details", "Bundle", new { id = bundleId });
        }
        /// <summary>
        /// when given a productId( id ) and bundleId, this action will use the create function to create a new linking table record.
        /// This then creates a many-many relation ship with product and bundle.
        /// Then redirects the user to the product details
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> CreateConfirmedProduct(int id, int bundleId)
        {
            await _productBundleRepo.CreateAsync(id, bundleId);
            return RedirectToAction("Details", "Product", new { id = id });
        }

        /// <summary>
        /// displays a page for the user to select a link to remove
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> Remove([Bind(Prefix = "id")] int id, int bundleId)
        {
            var product = await _productRepo.ReadAsync(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            var productBundle = product.ProductBundles
            .FirstOrDefault(pb => pb.BundleId == bundleId);
            if (productBundle == null)
            {
                return RedirectToAction("Details", "Product", new { id = id });
            }
            return View(productBundle);
        }
        /// <summary>
        /// the confirmation action that uses the delete function to remove the ProductBundle record from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productBundleId"></param>
        /// <returns></returns>

        [HttpPost, ActionName("Remove")]
        public async Task<IActionResult> RemoveConfirmed(
        int id, int productBundleId)
        {
            await _productBundleRepo.DeleteAsync(id, productBundleId);
            return RedirectToAction("Details", "Product", new { id = id });
        }

        /// <summary>
        /// displays a page for the user to select a link to remove
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        public async Task<IActionResult> RemoveProduct([Bind(Prefix = "id")] int id, int bundleId)
        {
            var product = await _productRepo.ReadAsync(id);
            if (product == null)
            {
                return RedirectToAction("Index", "Product");
            }
            var productBundle = product.ProductBundles
            .FirstOrDefault(pb => pb.BundleId == bundleId);
            if (productBundle == null)
            {
                return RedirectToAction("Details", "Product", new { id = id });
            }
            return View(productBundle);
        }

        /// <summary>
        /// Same as the 'remove' action, just redirects back to the bundle instead of the product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bundleId"></param>
        /// <returns></returns>
        [HttpPost, ActionName("RemoveProduct")]
        public async Task<IActionResult> RemoveProductConfirmed(
        int id, int productBundleId, int bundleId)
        {
            await _productBundleRepo.DeleteAsync(id, productBundleId);
            return RedirectToAction("Details", "Bundle", new { id = bundleId });
        }
    }
}
