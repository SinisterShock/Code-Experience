using Microsoft.AspNetCore.Mvc;

namespace ControllersLec.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Details(int id)
    {
        return Content($"ID = {id}");
    }
    
}
