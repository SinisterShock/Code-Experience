using LabW02TB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LabW02TB.Controllers
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


        public IActionResult Experiment1()
        {
            return View();
        }

        public IActionResult Experiment2()
        {
            return View();
        }

        public IActionResult Experiment3()
        {
            return View();
        }

        public IActionResult Experiment4() 
        {
            Random random = new Random();
            var num = random.Next(0, 101);
            ViewBag.Key1 = num;

            Random random2 = new Random();  
            var num2 = random2.Next(100, 1001);
            ViewData["Key2"] = num2;
            return View();
        }
        public IActionResult Experiment5()
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