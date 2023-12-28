using Microsoft.AspNetCore.Mvc;
using NewPartsGalore.Models.Entities;
using NewPartsGalore.Services;

namespace NewPartsGalore.Controllers
{
    
    public class VendorController : Controller
    {
        private readonly IVendorRepository _vendorRepo;
        public VendorController(IVendorRepository vendorRepo)
        {
            _vendorRepo = vendorRepo;            
        }
        /// <summary>
        /// displays a list of vendors using the read all function
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var allVendors = await _vendorRepo.ReadAllAsync();
            var model = allVendors.ToList();
            return View(model);
        }
        /// <summary>
        /// using the read function, the action displays info about the selected vendor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int id)
        {
            var vendor = await _vendorRepo.ReadAsync(id);

            if (vendor != null)
            {
                return View(vendor);
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// displays a form for the user to create a new vendor
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            return View();
        }

        /// <summary>
        /// when the vendor is submitted, the action checks the model than creaets a new record in the database
        /// </summary>
        /// <param name="newVendor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(Vendor newVendor)
        {
            if (ModelState.IsValid)
            {
                await _vendorRepo.CreateAsync(newVendor);
                return RedirectToAction("Index", "Vendor");
            }
            return View(newVendor);
        }

        /// <summary>
        /// displays a form containing an existing vendor for the user to edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int id)
        {
            var vendor = await _vendorRepo.ReadAsync(id);
            if (vendor == null)
            {
                return RedirectToAction("Index");
            }
            return View(vendor);
        }
        /// <summary>
        /// when the editted vendor is submitted, check the model then using the update function alter the record in the database
        /// </summary>
        /// <param name="vendor"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                await _vendorRepo.UpdateAsync(vendor.Id, vendor);
                return RedirectToAction("Index");
            }
            return View(vendor);
        }
        /// <summary>
        /// when the record is confirmed to be deleted, the id is passed into the action then deleted using the delete function
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vendorRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
