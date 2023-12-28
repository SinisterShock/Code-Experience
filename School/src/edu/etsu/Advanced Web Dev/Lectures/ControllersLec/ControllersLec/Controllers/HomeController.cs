using ControllersLec.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;

namespace ControllersLec.Controllers;

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

    public IActionResult FourSegments(string code, string idNumber)
    {
        var safeCode = HttpUtility.HtmlEncode(code);
        var safeID = HttpUtility.HtmlEncode(idNumber);
        return Content($"code={safeCode} id={safeID}");
    }

    public IActionResult MyJson()
    {
        var o = new { id = 1, name = "Tyler", type = "Person" };
        return Json(o);
    }
    public IActionResult MyFile()
    {
        return File("Tyler Burleson Resume Fall 2023 2.0.pdf", "application/pdf");
    }

    public IActionResult BindDemo([Bind(Prefix = "id")]string name)
    {
        return Content($"name = {name}");
    }

    public IActionResult Details(string enumber)
    {
        return Content($"enumber = {enumber}");
    }

    public IActionResult Process(string name, string values)
    {
        var results = $"name = {name} value = {values}";
        var itemarr = values.Split('/');
        var itemString = String.Join(" ", itemarr);
        return Content($"result = {results} itemStr = {itemString}");
    }

    public IActionResult InputAgeForm()
    {
        return View();
    }
    [HttpPost]
    public IActionResult FormProcessor(int age)
    {
        return RedirectToAction("Parameter", new {id =$"Your age is {age}"});
    }

    public IActionResult Parameter(string id)
    {
        return Content(id);
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