using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;

namespace RS1SeminarskiRad2020.Controllers
{
   public class CiklusController: Controller
   {
      private readonly ApplicationDbContext db;
      public CiklusController(ApplicationDbContext _db) {
         db = _db;
      }
      public IActionResult Index() {
         List<Ciklus> ciklusi = db.Ciklus.Select(c => new Ciklus {
            CiklusID = c.CiklusID,
            Naziv = c.Naziv
         }).ToList();
         ViewData["ciklusi"] = ciklusi;
         return View();
      }
      public IActionResult Delete(int id) {
         var ciklus = db.Ciklus.Find(id);
         db.Remove(ciklus);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
      public IActionResult Save(Ciklus _c) {
         db.Add(_c);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
}
