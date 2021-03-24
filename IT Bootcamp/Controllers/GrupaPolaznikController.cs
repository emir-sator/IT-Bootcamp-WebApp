using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using RS1SeminarskiRad2020.ViewModels.GrupaVM;
using RS1SeminarskiRad2020.ViewModels.PolaznikGrupaVM;

namespace RS1SeminarskiRad2020.Controllers
{
    public class GrupaPolaznikController : Controller
    {
        private readonly ApplicationDbContext db;

        public GrupaPolaznikController(ApplicationDbContext _db)
        {
            db = _db;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            var model = new PolaznikGrupaIndexVM
            {
                Kursevi = db.Kursevi.Select(k => new SelectListItem
                {
                    Text = k.Naziv,
                    Value = k.KursID.ToString()
                }).ToList(),
                Polaznici = db.Studenti.Select(u => new SelectListItem
                {
                    Text = u.Korisnik.Ime,
                    Value = u.Korisnik.Id,
                }).ToList(),
                Grupe = db.Grupa.Select(g => new SelectListItem
                {
                    Text = g.Naziv,
                    Value = g.GrupaID.ToString()
                }).ToList()

            };

            return View(model);
        }
        public IActionResult Snimi(PolaznikGrupaIndexVM VM)
        {

            var grupe = new PolaznikGrupa
            {
                GrupaID = VM.GrupaID,
                KursID = VM.KursID,
                KorisnikId = VM.KorisnikId

            };
            db.PolaznikGrupa.Add(grupe);
            db.SaveChanges();
            return Redirect("/Administrator/Crud");
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult PrikazGrupa(int KursID = 0, int GrupaID = 0)
        {

            GrupePrikazVM model;
            if (KursID != 0 && GrupaID != 0)
            {

                model = new GrupePrikazVM
                {
                    GrupaID = GrupaID,
                    Grupe = db.Grupa.Select(g => new SelectListItem
                    {
                        Text = g.Naziv,
                        Value = g.GrupaID.ToString()
                    }).ToList(),
                    KursID = KursID,
                    Kursevi = db.Kursevi.Select(k => new SelectListItem
                    {
                        Text = k.Naziv,
                        Value = k.KursID.ToString()
                    }).ToList(),
                    Redovi = db.PolaznikGrupa.Where(g => g.GrupaID == GrupaID && g.KursID == KursID).Select(pg => new GrupePrikazVM.Red
                    {
                        KursID=pg.KursID,
                        KorisnikId=pg.KorisnikId,
                        GrupaID=pg.GrupaID,
                        NazivKursa = pg.Kurs.Naziv,
                        NazivGrupe = pg.Grupa.Naziv,
                        ImePrezime = pg.Korisnik.Ime + " " + pg.Korisnik.Prezime

                    }).ToList()
                };
            }
            else if (KursID != 0 && GrupaID == 0)
            {

                model = new GrupePrikazVM
                {
                    GrupaID = GrupaID,
                    Grupe = db.Grupa.Select(g => new SelectListItem
                    {
                        Text = g.Naziv,
                        Value = g.GrupaID.ToString()
                    }).ToList(),
                    KursID = KursID,
                    Kursevi = db.Kursevi.Select(k => new SelectListItem
                    {
                        Text = k.Naziv,
                        Value = k.KursID.ToString()
                    }).ToList(),
                    Redovi = db.PolaznikGrupa.Where(g => g.KursID == KursID).Select(pg => new GrupePrikazVM.Red
                    {
                        KursID = pg.KursID,
                        KorisnikId = pg.KorisnikId,
                        GrupaID = pg.GrupaID,
                        NazivKursa = pg.Kurs.Naziv,
                        NazivGrupe = pg.Grupa.Naziv,
                        ImePrezime = pg.Korisnik.Ime + " " + pg.Korisnik.Prezime

                    }).ToList()
                };
            }
            else if (KursID == 0 && GrupaID != 0)
            {

                model = new GrupePrikazVM
                {
                    GrupaID = GrupaID,
                    Grupe = db.Grupa.Select(g => new SelectListItem
                    {
                        Text = g.Naziv,
                        Value = g.GrupaID.ToString()
                    }).ToList(),
                    KursID = KursID,
                    Kursevi = db.Kursevi.Select(k => new SelectListItem
                    {
                        Text = k.Naziv,
                        Value = k.KursID.ToString()
                    }).ToList(),
                    Redovi = db.PolaznikGrupa.Where(g => g.GrupaID == GrupaID).Select(pg => new GrupePrikazVM.Red
                    {
                        KursID = pg.KursID,
                        KorisnikId = pg.KorisnikId,
                        GrupaID = pg.GrupaID,
                        NazivKursa = pg.Kurs.Naziv,
                        NazivGrupe = pg.Grupa.Naziv,
                        ImePrezime = pg.Korisnik.Ime + " " + pg.Korisnik.Prezime

                    }).ToList()
                };
            }
            else
            {

                model = new GrupePrikazVM
                {
                    GrupaID = GrupaID,
                    Grupe = db.Grupa.Select(g => new SelectListItem
                    {
                        Text = g.Naziv,
                        Value = g.GrupaID.ToString()
                    }).ToList(),
                    KursID = KursID,
                    Kursevi = db.Kursevi.Select(k => new SelectListItem
                    {
                        Text = k.Naziv,
                        Value = k.KursID.ToString()
                    }).ToList(),
                    Redovi = db.PolaznikGrupa.Select(pg => new GrupePrikazVM.Red
                    {
                        KursID = pg.KursID,
                        KorisnikId = pg.KorisnikId,
                        GrupaID = pg.GrupaID,
                        NazivKursa = pg.Kurs.Naziv,
                        NazivGrupe = pg.Grupa.Naziv,
                        ImePrezime = pg.Korisnik.Ime + " " + pg.Korisnik.Prezime

                    }).ToList()
                };
            }
            return View(model);
        }


    }
}
