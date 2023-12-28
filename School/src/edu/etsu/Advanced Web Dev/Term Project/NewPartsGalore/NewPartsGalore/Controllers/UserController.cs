using Microsoft.AspNetCore.Mvc;

namespace NewPartsGalore.Controllers
{
    /// <summary>
    /// Controller for the REST api and JS/AJAX
    /// </summary>
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
