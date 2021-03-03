using Microsoft.AspNetCore.Mvc;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Controllers
{
   public class KabinetController : Controller
   {
      private readonly ApplicationDbContext db;
      public KabinetController(ApplicationDbContext _db)
      {
         db = _db;
      }
      public IActionResult Index()
      {
         List<Kabinet> Kabineti = db.Kabineti.Select(k => new Kabinet
         {
            KabinetID = k.KabinetID,
            Naziv = k.Naziv,
            Kapacitet = k.Kapacitet,
            Predavanja = db.Predavanje.Where(p=>p.KabinetID==k.KabinetID).Select(p => new Predavanje { 
               PredavanjeID = p.PredavanjeID,
               Naziv = p.Naziv}).ToList()
         }).ToList();
         ViewData["kabineti"] = Kabineti;
         return View();
      }
      public IActionResult PregledPredavanja(int KabID)
      {
         List<Predavanje> Predavanja = db.Predavanje.Where(p => p.KabinetID == KabID).Select(p => new Predavanje
         {
            PredavanjeID = p.PredavanjeID,
            Naziv = p.Naziv,
            Datum = p.Datum,
            SatnicaPocetka = p.SatnicaPocetka,
            SatnicaZavrsetka = p.SatnicaZavrsetka,
            Kurs = db.Kursevi.Where(k => k.KursID == p.KursID).SingleOrDefault()
         }).ToList();
         ViewData["predavanja"] = Predavanja;
         return View();
      }
      public IActionResult Delete(int id)
      {
         var Kabineti = db.Kabineti.Find(id);
         db.Remove(Kabineti);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
      public IActionResult Save(Kabinet _k)
      {
         db.Add(_k);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
}
