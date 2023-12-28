using JavaScriptLecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JavaScriptLecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JavaScript()
        {
            return View();
        }
        public IActionResult JavaScript2()
        {
            return View();
        }

        public IActionResult UsingJavaScript()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}