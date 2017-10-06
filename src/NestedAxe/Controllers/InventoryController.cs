using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPG.Models;
using System;


namespace RPG.Controllers
{
    public class InventoryController : Controller
    {
        private RPGContext db = new RPGContext();
        public IActionResult Index()
        {
            return View(db.Inventories.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisInventory = db.Inventories.FirstOrDefault(inv => inv.id == id);

            return View(thisInventory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Inventory inventory)
        {
            db.Inventories.Add(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisInv = db.Inventories.FirstOrDefault(inv => inv.id == id);
            return View(thisInv);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisInv = db.Inventories.FirstOrDefault(inv => inv.id == id);
            db.Inventories.Remove(thisInv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisInv = db.Inventories.FirstOrDefault(inv => inv.id == id);
            return View(thisInv);
        }
        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            db.Entry(inventory).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}