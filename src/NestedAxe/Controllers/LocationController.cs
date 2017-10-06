using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestedAxe.Models;

namespace NestedAxe.Controllers
{
    public class LocationController : Controller
    {
        private NestedAxeContext db = new NestedAxeContext();
        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(loc => loc.id == id);

            return View(thisLocation);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisLoc = db.Locations.FirstOrDefault(loc => loc.id == id);
            return View(thisLoc);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLoc = db.Locations.FirstOrDefault(loc => loc.id == id);
            db.Locations.Remove(thisLoc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisLoc = db.Locations.FirstOrDefault(loc => loc.id == id);
            return View(thisLoc);
        }
        [HttpPost]
        public IActionResult Edit(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}