using LW03Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using System.Web;

namespace LW03Controllers.Controllers
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

        public IActionResult Toys()
        {
            Toy[] toys = new Toy[2];
            Toy toy1 = new Toy();
            Toy toy2 = new Toy();

            toy1.Name = "Bear";
            toy1.Type = "Plush";
            toy1.Price = 12.99m;
            toys[0] = toy1;

            toy2.Name = "Beyblade";
            toy2.Type = "Toy";
            toy2.Price = 6.99m;
            toys[1] = toy2;
            return View(toys);
        }

        public IActionResult BarGraph(string? values)
        {
            var safeValues = HttpUtility.HtmlEncode(values);
            var model = safeValues.Split("/");
            return View(model);
        }

        public IActionResult MyPdf()
        {
            return File("Final Resume-Burleson_Tyler.pdf", "application/pdf");
        }

        public IActionResult MyJson()
        {
            MyDictionaryEntry myDictionaryEntry = new MyDictionaryEntry { Word = "World", Meaning = "The Earth"};
            // var dJson = JsonSerializer.Serialize(myDictionaryEntry);
            return Json(myDictionaryEntry);
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