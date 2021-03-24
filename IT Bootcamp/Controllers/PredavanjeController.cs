using Microsoft.AspNetCore.Mvc;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Controllers
{
   public class PredavanjeController : Controller
   {
      private readonly ApplicationDbContext db;
      public PredavanjeController(ApplicationDbContext _db)
      {
         db = _db;
      }
      public IActionResult Index()
      {
         List<Predavanje> Predavanja = db.Predavanje.Select(p => new Predavanje
         {
            PredavanjeID = p.PredavanjeID,
            Naziv = p.Naziv,
            Datum = p.Datum,
            SatnicaPocetka = p.SatnicaPocetka,
            SatnicaZavrsetka = p.SatnicaZavrsetka
         }).ToList();
         ViewData["predavanja"] = Predavanja;
         return View();
      }
      public IActionResult Add()
      {
         List<Kurs> Kursevi = db.Kursevi.Select(k => new Kurs
         {
            KursID = k.KursID,
            Naziv = k.Naziv
         }).ToList();

         List<Korisnik> Korisnici = db.Korisnici.Select(ko => new Korisnik
         {
            Id = ko.Id,
            Ime = ko.Ime,
            Prezime = ko.Prezime
         }).ToList();

         List<Kabinet> Kabineti = db.Kabineti.Select(ka => new Kabinet
         {
            KabinetID = ka.KabinetID,
            Naziv = ka.Naziv
         }).ToList();

         ViewData["kursevi"] = Kursevi;
         ViewData["korisnici"] = Korisnici;
         ViewData["kabineti"] = Kabineti;
         return View();
      }
      public IActionResult SavePredavanje(Predavanje predavanje)
      {
         if(predavanje.PredavanjeID == 0)
         {
            db.Add(predavanje);
            db.SaveChanges();
            return RedirectToAction("Index");
         }
         else
         {
            Predavanje p = db.Predavanje.Where(pred => pred.PredavanjeID == predavanje.PredavanjeID).SingleOrDefault();
            p.Naziv = predavanje.Naziv;
            p.Datum = predavanje.Datum;
            p.SatnicaPocetka = predavanje.SatnicaPocetka;
            p.SatnicaZavrsetka = predavanje.SatnicaZavrsetka;
            p.KursID = predavanje.KursID;
            p.KorisnikId = predavanje.KorisnikId;
            p.KabinetID = predavanje.KabinetID;
            db.SaveChanges();
            return RedirectToAction("Index");
         }
      }
      public IActionResult Edit(int id)
      {
         Predavanje p = db.Predavanje.Where(pred => pred.PredavanjeID == id).FirstOrDefault();
         return View("Add", p);
      }
      public IActionResult Delete(int id)
      {
         Predavanje p = db.Predavanje.Where(pred => pred.PredavanjeID == id).FirstOrDefault();
         db.Remove(p);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
      public IActionResult Pregled(int id)
      {
         Predavanje p = db.Predavanje.Where(pred => pred.PredavanjeID == id).FirstOrDefault();
         Kurs Kurs = db.Kursevi.Where(k => k.KursID == p.KursID).FirstOrDefault();
         Korisnik Korisnk = db.Korisnici.Where(ko => ko.Id == p.KorisnikId).FirstOrDefault();
         Kabinet Kabinet = db.Kabineti.Where(ka => ka.KabinetID == p.KabinetID).FirstOrDefault();

         ViewData["predavanje"] = p;
         ViewData["kurs"] = Kurs;
         ViewData["korisnik"] = Korisnk;
         ViewData["kabinet"] = Kabinet;
         return View();
      }
   }
}
