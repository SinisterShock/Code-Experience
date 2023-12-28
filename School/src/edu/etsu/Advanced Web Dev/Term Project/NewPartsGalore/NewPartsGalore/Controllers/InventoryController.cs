using Microsoft.AspNetCore.Mvc;
using NewPartsGalore.Services;

namespace NewPartsGalore.Controllers
{
    /// <summary>
    /// Controller for potential views for an inventory. Future updates will allow this controller to work in similar fashion to the ProductBundle controller
    /// </summary>
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepo;
        public InventoryController(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
