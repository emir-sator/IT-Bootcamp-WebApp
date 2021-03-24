using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.ViewModels;
using RS1SeminarskiRad2020.Models;
using System.Security.Claims;

namespace RS1SeminarskiRad2020.Controllers
{
    public class PolaznikController : Controller
    {
        public readonly ApplicationDbContext db;

        public PolaznikController(ApplicationDbContext _db)
        {
            db = _db;
        }


        public IActionResult Dodaj()
        {
            return View();
        }
        public IActionResult Snimi (PolaznikDodajVM VM)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var polaznik = new Polaznik
            {
                KorisnikId = userId,
                Fakultet = VM.Fakultet
            };
            db.Studenti.Add(polaznik);
            db.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}
