using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TBLW05ConsumeWebAPI.Models;
using TBLW05ConsumeWebAPI.Models.Entities;
using TBLW05ConsumeWebAPI.Services;

namespace TBLW05ConsumeWebAPI.Controllers;

public class HomeController : Controller
{
    private readonly IBookrepository _bookRepo;
	public HomeController(IBookrepository bookRepo)
	{
		_bookRepo= bookRepo;
	}

	public async Task<IActionResult> Index()
	{
		var books = await _bookRepo.ReadAllAsync();
		return View(books);
	}
}