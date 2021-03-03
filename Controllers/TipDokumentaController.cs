using Microsoft.AspNetCore.Mvc;
using RS1SeminarskiRad2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS1SeminarskiRad2020.Models;

namespace RS1SeminarskiRad2020.Controllers
{
   public class TipDokumentaController: Controller
   {
      private readonly ApplicationDbContext db;
      public TipDokumentaController(ApplicationDbContext _db) {
         db = _db;
      }
      public IActionResult Index() {
         List<TipDokumenta> TipDokumenata = db.TipDokumenta.Select(td => new TipDokumenta {
            TipDokumentaID = td.TipDokumentaID,
            Naziv = td.Naziv,
            Dokumenti = td.Dokumenti
         }).ToList();
         ViewData["tipoviDokumenata"] = TipDokumenata;
         return View();
      }
      public IActionResult Delete(int id) {
         var tipDokumenata = db.TipDokumenta.Find(id);
         db.Remove(tipDokumenata);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
      public IActionResult Save(TipDokumenta _td) {
         db.Add(_td);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
}
