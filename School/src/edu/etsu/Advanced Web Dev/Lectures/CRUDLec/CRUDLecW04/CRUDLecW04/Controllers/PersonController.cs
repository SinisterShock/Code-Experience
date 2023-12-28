using CRUDLecW04.Models.Entities;
using CRUDLecW04.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDLecW04.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepo;

        public PersonController(IPersonRepository personRepo)
        {
            _personRepo = personRepo;
        }
        public IActionResult Index()
        {
            return View(_personRepo.ReadAll());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person newPerson)
        {
            if(ModelState.IsValid)
            {
                _personRepo.Create(newPerson);
                return RedirectToAction("Index");
            }
            return View(newPerson);
        }
        public IActionResult Details(int id)
        {
            var person =_personRepo.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult Edit(int id)
        {
            var person = _personRepo.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                _personRepo.Update(person.Id, person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        public IActionResult Delete(int id)
        {
            var person = _personRepo.Read(id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            return View(person);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _personRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
