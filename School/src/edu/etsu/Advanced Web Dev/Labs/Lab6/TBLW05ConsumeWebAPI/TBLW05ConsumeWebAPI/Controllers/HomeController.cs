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

	public async Task<IActionResult> Details(int id)
	{
		var book = await _bookRepo.ReadAsync(id);
		if (book == null)
		{
			return RedirectToAction("Index");
		}
		return View(book);
	}

	public async Task<IActionResult> Edit(int id)
	{
		var book = await _bookRepo.ReadAsync(id);
		if (book == null)
		{
			return RedirectToAction("Index");
		}
		return View(book);
	}


	public async Task<IActionResult> Delete(int id)
	{
		var book = await _bookRepo.ReadAsync(id);
		if (book == null)
		{
			return RedirectToAction("Index");
		}
		return View(book);
	}

	[HttpPost, ActionName("Delete")]
	public async Task<IActionResult> DeleteConfirmed(int id)
	{
		await _bookRepo.DeleteAsync(id);
		return RedirectToAction("Index");
	}

	[HttpPost]
	public async Task<IActionResult> Edit(Book book)
	{
		if (ModelState.IsValid)
		{
			await _bookRepo.UpdateAsync(book.Id, book);
			return RedirectToAction("Index");
		}
		return View(book);
	}

	public IActionResult Create()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Create(Book book)
	{
		if (ModelState.IsValid)
		{
			await _bookRepo.CreateAsync(book);
			return RedirectToAction("Index");
		}
		return View(book);
	}
	public async Task<IActionResult> Index()
	{
		var books = await _bookRepo.ReadAllAsync();
		return View(books);
	}
}