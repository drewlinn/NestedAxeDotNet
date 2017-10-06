using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NestedAxe.Models;
using System;


namespace NestedAxe.Controllers
{
    public class NPCController : Controller
    {
        private NestedAxeContext db = new NestedAxeContext();
        public IActionResult Index()
        {
            return View(db.NPCs.ToList());
        }

        public IActionResult Details(int id)
        {
            var thisNPC = db.NPCs.FirstOrDefault(npc => npc.id == id);

            return View(thisNPC);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NPC npc)
        {
            db.NPCs.Add(npc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisNPC = db.NPCs.FirstOrDefault(npc => npc.id == id);
            return View(thisNPC);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisNPC = db.NPCs.FirstOrDefault(npc => npc.id == id);
            db.NPCs.Remove(thisNPC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var thisNPC = db.NPCs.FirstOrDefault(npc => npc.id == id);
            return View(thisNPC);
        }
        [HttpPost]
        public IActionResult Edit(NPC npc)
        {
            db.Entry(npc).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}