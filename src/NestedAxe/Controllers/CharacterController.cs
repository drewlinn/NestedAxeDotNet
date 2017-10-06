using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NestedAxe.Models;
using System;


namespace NestedAxe.Controllers
{
    public class CharacterController : Controller
    {
        private NestedAxeContext db = new NestedAxeContext();
        public IActionResult Index()
        {
            return View(db.Characters.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisCharacter = db.Characters.FirstOrDefault(cha => cha.id == id);

            return View(thisCharacter);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Character character)
        {
            db.Characters.Add(character);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisCha = db.Characters.FirstOrDefault(cha => cha.id == id);
            return View(thisCha);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisCha = db.Characters.FirstOrDefault(cha => cha.id == id);
            db.Characters.Remove(thisCha);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisCha = db.Characters.FirstOrDefault(cha => cha.id == id);
            return View(thisCha);
        }
        [HttpPost]
        public IActionResult Edit(Character character)
        {
            db.Entry(character).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}