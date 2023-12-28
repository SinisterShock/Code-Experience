using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBLW04CRRUD.Models.Entities;
using TBLW04CRRUD.Services;

namespace TBLW05RestAPI.Controllers;

[EnableCors]
[Route("api/book")]
[ApiController]
public class BookAPIController : ControllerBase
{
	private readonly IBookrepository _bookRepo;
	public BookAPIController(IBookrepository bookRepo)
	{
		_bookRepo = bookRepo;
	}

	[HttpGet("all")]
	public IActionResult Get()
	{
		return Ok(_bookRepo.ReadAll());
	}

	[HttpGet("one/{id}")]
	public IActionResult Get(int id)
	{
		var book = _bookRepo.Read(id);
		if (book == null)
		{
			return NotFound();
		}
		return Ok(book);
	}

	[HttpPost("create")]
	public IActionResult Post([FromForm] Book book)
	{
		_bookRepo.Create(book);
		return CreatedAtAction("Get", new { id = book.Id }, book);

	}

	[HttpPut("update")]
	public IActionResult Put([FromForm] Book book)
	{
		_bookRepo.Update(book.Id, book);
		return NoContent();
	}

	[HttpDelete("delete/{id}")]
	public IActionResult Delete(int id)
	{
		_bookRepo.Delete(id);
		return NoContent();
	}
}
