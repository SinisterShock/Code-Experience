using Microsoft.AspNetCore.Mvc;

namespace QuotesApp.Controllers
{
    public class QuoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
