using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using RS1SeminarskiRad2020.ViewModels.KursVM;
using RS1SeminarskiRad2020.ViewModels.Prijava;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using RS1SeminarskiRad2020.Models.Repozitorij_pattern;
using Microsoft.Extensions.Configuration;
using WebPush;

namespace RS1SeminarskiRad2020.Controllers
{
   public class KurseviController : Controller
   {
      private readonly ApplicationDbContext db;
      private readonly UserManager<Korisnik> korisnik;
      private readonly IKursRepozitorij kursRepozitorij;
      private readonly IConfiguration configuration;
      public KurseviController(ApplicationDbContext _db, UserManager<Korisnik> _korisnik, IKursRepozitorij _kursRepozitorij, IConfiguration _configuration)
      {
         db = _db;
         korisnik = _korisnik;
         kursRepozitorij = _kursRepozitorij;
         configuration = _configuration;
      }
 
      public IActionResult Index(string SearchString)
      {
         if(SearchString == null)
         {
            List<DodajKursVM> kursevi = db.Kursevi.Select(k => new DodajKursVM
            {
               KursID = k.KursID,
               Naziv = k.Naziv,
               Oznaka = k.Oznaka,
               Cijena = k.Cijena,
               DatumPocetka = k.DatumPocetka,
               DatumZavrsetka = k.DatumZavrsetka,
               Aktivan = k.Aktivan,
               Opis = k.Opis,
               UserID = User.FindFirstValue(ClaimTypes.NameIdentifier)
            }).ToList();
            ViewData["kursevi"] = kursevi;
         }
         else
         {
            List<DodajKursVM> kursevi = db.Kursevi.Where(ku => ku.Naziv.Contains(SearchString)).Select(k=>new DodajKursVM {
               KursID = k.KursID,
               Naziv = k.Naziv,
               Oznaka = k.Oznaka,
               Cijena = k.Cijena,
               DatumPocetka = k.DatumPocetka,
               DatumZavrsetka = k.DatumZavrsetka,
               Aktivan = k.Aktivan,
               Opis = k.Opis,
               UserID = User.FindFirstValue(ClaimTypes.NameIdentifier)
            }).ToList();
            ViewData["kursevi"] = kursevi;
         }
         return View();
      }

      public IActionResult AddKurs()
      {
         return View();
      }
      public IActionResult SnimiKurs(Kurs kurs)
      {
         //Provjerimo je li edit kursa u pitanju ili unos novog
         if (kurs.KursID == 0)
         {
            kurs.Aktivan = true;
            db.Add(kurs);
            db.SaveChanges();
            return RedirectToAction("Index");
         }
         else
         {
            Kurs k = kursRepozitorij.GetKursById(kurs.KursID);
            k.Naziv = kurs.Naziv;
            k.Oznaka = kurs.Oznaka;
            k.Cijena = kurs.Cijena;
            k.DatumPocetka = kurs.DatumPocetka;
            k.DatumZavrsetka = kurs.DatumZavrsetka;
            k.Opis = kurs.Opis;
            k.Aktivan = kurs.Aktivan;
            db.SaveChanges();
            return RedirectToAction("Index");
         }
      }
      public IActionResult EditKurs(int id)
      {
         var kurs = kursRepozitorij.GetKursById(id);
         return View("AddKurs", kurs);
      }
      public IActionResult DeleteKurs(int id)
      {
         var kurs = kursRepozitorij.GetKursById(id);
         db.Remove(kurs);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
      
      public IActionResult PrijavaPrikaz(int id)
      {
         var kurs = kursRepozitorij.GetKursById(id);
         var userId =User.FindFirstValue(ClaimTypes.NameIdentifier);
         var korisnik = db.Korisnici.Find(userId);

         var model = new PrijavaVM
         {

            KursID = kurs.KursID,
            UserID = userId,
            NazivKursa = kurs.Naziv,
            ImePrezime = korisnik.Ime + " " + korisnik.Prezime,
            DatumPrijave = DateTime.Now

         };

         return View(model);
      }
      public IActionResult SnimiPrijavu(PrijavaVM VM)
      {
         var prijava = new KorisnikKurs
         {
            PrijavaID = VM.PrijavaID,
            KorisnikId = VM.UserID,
            KursID = VM.KursID,
            DatumPrijave = VM.DatumPrijave,
            Polozio = false
         };
         db.KorisnikKurs.Add(prijava);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
      [Authorize(Roles = "Polaznik")]
      public IActionResult PolozeniKursevi(string id)
      {


         var polozen = db.KorisnikKurs.Where(kk => kk.KorisnikId == id).FirstOrDefault();
         var model = new PolozenikurseviVM

         {
            KorisnikId = id,
            Redovi = db.KorisnikKurs.Where(kk => kk.KorisnikId == id && kk.Polozio == true).Select(i => new PolozenikurseviVM.Red
            {
               KursID = i.KursID,
               NazivKursa = i.Kurs.Naziv,
               DatumPocetka = i.Kurs.DatumPocetka.ToString("dd/MM/yyyy"),
               DatumZavrsetka = i.Kurs.DatumZavrsetka.ToString("dd/MM/yyyy"),
               Opis = i.Kurs.Opis,
               KorisnikId = i.KorisnikId

            }).ToList()
         };
         return View(model);
      }

      public IActionResult SubscribeNotifications()
      {
         ViewBag.applicationServerKey = configuration["VAPID:publicKey"];
         return View();
      }
      [HttpPost]
      public IActionResult SaveSubscription(string client, string endpoint, string p256dh, string auth)
      {
         if (client == null || client == "")
         {
            return BadRequest("No client name passed");
         }
         var FoundUser = db.Subscriptions.Where(S => S.Client == client).FirstOrDefault();
         if(FoundUser != null)
         {
            return BadRequest("Client already exists");
         }
         var sub = new Subscription();
         sub.Client = client;
         sub.Endpoint = endpoint;
         sub.p256dh = p256dh;
         sub.auth = auth;
         db.Add(sub);
         db.SaveChanges();
         return View("SubscribeNotifications");
      }
   }
}
