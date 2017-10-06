using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using RPG.Models;

namespace RPG.Controllers
{
    public class ItemController : Controller
    {
        private RPGContext db = new RPGContext();
        public IActionResult Index()
        {
            return View(db.Items.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisItem = db.Items.FirstOrDefault(item => item.id == id);

            return View(thisItem);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.ItemCategories, "id", "type");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisItem = db.Items.FirstOrDefault(item => item.id == id);
            return View(thisItem);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = db.Items.FirstOrDefault(item => item.id == id);
            db.Items.Remove(thisItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisItem = db.Items.FirstOrDefault(item => item.id == id);
            return View(thisItem);
        }
        [HttpPost]
        public IActionResult Edit(Item item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}