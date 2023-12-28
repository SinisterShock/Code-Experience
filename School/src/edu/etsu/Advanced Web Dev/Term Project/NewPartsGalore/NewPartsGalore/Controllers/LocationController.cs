using Microsoft.AspNetCore.Mvc;
using NewPartsGalore.Models.Entities;
using NewPartsGalore.Services;

namespace NewPartsGalore.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepo;
        private readonly IInventoryRepository _inventoryRepo;
        public LocationController(ILocationRepository locationRepository, IInventoryRepository inventoryRepository)
        {
               _locationRepo= locationRepository;
            _inventoryRepo= inventoryRepository;
        }
        /// <summary>
        /// Displays a list of all locations using the Read All function
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var allLocations = await _locationRepo.ReadAllAsync();
            var model = allLocations.ToList();
            return View(model);
        }
        /// <summary>
        /// Using the Read function, this controller displays info on a selected location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<IActionResult> Details(int id)
        {
            var location = await _locationRepo.ReadAsync(id);
            
            var inventory = location.LocationInventories
                .FirstOrDefault(li => li.LocationId == id);
            
            ViewData["Inventory"] = inventory;
            if (location != null)
            {
                return View(location);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Displays a form to create a location
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            return View();
        }

        /// <summary>
        /// Post method, checks the model of the submitted location then uses the create function to add it to the database
        /// </summary>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Location newLocation)
        {
            if (ModelState.IsValid)
            {
                await _locationRepo.CreateAsync(newLocation);
                await _inventoryRepo.CreateAsync(newLocation.Id);
                return RedirectToAction("Index", "Location");
            }
            return View(newLocation);
        }
        /// <summary>
        /// displays a form for the user to alter data in an existing record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            var location = await _locationRepo.ReadAsync(id);
            if (location == null)
            {
                return RedirectToAction("Index");
            }
            return View(location);
        }

        /// <summary>
        /// checks the model and updates the entered location's record
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                await _locationRepo.UpdateAsync(location.Id, location);
                return RedirectToAction("Index");
            }
            return View(location);
        }
        /// <summary>
        /// deletes the given record when provided an id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _locationRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
