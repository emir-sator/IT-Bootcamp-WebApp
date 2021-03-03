using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using RS1SeminarskiRad2020.ViewModels.Prijava;

namespace RS1SeminarskiRad2020.Controllers
{
    public class PrijavaController : Controller
    {
        private readonly ApplicationDbContext db;

        public PrijavaController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index(int KursID = 0)
        {

            PrijavaPrikazVM model;

            if (KursID != 0)
            {
                model = new PrijavaPrikazVM
                {
                    KursID = KursID,
                    Kursevi = db.Kursevi.Select(i => new SelectListItem
                    {
                        Value = i.KursID.ToString(),
                        Text = i.Naziv
                    }).ToList(),
                    Redovi = db.KorisnikKurs.Where(kk => kk.KursID == KursID).Select(p => new PrijavaPrikazVM.Red
                    {
                        Id=p.PrijavaID,
                        KursID = p.KursID,
                        NazivKurs = p.Kurs.Naziv,
                        UserID = p.KorisnikId,
                        ImePrezime = p.Korisnik.Ime + " " +p.Korisnik.Prezime,
                        DatumPrijave=p.DatumPrijave,
                        Polozio = p.Polozio,
                    }).ToList()


                };
            }
            else
            {
                model = new PrijavaPrikazVM
                {
                    KursID = KursID,

                    Kursevi = db.Kursevi.Select(i => new SelectListItem
                    {
                        Value = i.KursID.ToString(),
                        Text = i.Naziv
                    }).ToList(),
                    Redovi = db.KorisnikKurs.Select(p => new PrijavaPrikazVM.Red
                    {
                        Id = p.PrijavaID,
                        KursID = p.KursID,
                        NazivKurs = p.Kurs.Naziv,
                        UserID = p.KorisnikId,
                        ImePrezime = p.Korisnik.Ime + " " + p.Korisnik.Prezime,
                        DatumPrijave = p.DatumPrijave,
                        Polozio = p.Polozio,
                    }).ToList()


                };
            }
            return View(model);
        }

  
        public IActionResult IsPolozio(int id)
        {
            var Polaznik = db.KorisnikKurs.Where(i => i.PrijavaID == id).FirstOrDefault();
            Polaznik.Polozio = !Polaznik.Polozio;
            db.SaveChanges();

            return Redirect("/Prijava/Index/" + Polaznik.PrijavaID);
        }
        
    }
}
