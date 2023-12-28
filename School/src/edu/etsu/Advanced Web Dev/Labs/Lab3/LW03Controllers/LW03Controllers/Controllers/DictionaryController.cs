
using LW03Controllers.Models;
using LW03Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace LW03Controllers.Controllers;

public class DictionaryController : Controller
{   
    public IActionResult Index()
    {
       
        return View(_dictionary.GetWords());
    }
    public IActionResult AddWord()
    {
        return View();
    }
    
    private readonly IWordService _dictionary;

    public DictionaryController(IWordService dictionary)
    {
        _dictionary = dictionary;
    }

    public IActionResult AddNewWord(string word, string meaning)
    {
        var safeWord = HttpUtility.HtmlEncode(word);
        var safeMeaning = HttpUtility.HtmlEncode(meaning);

        _dictionary.AddWord(safeWord, safeMeaning);
        return RedirectToAction("Index");

    }
        
    
}
