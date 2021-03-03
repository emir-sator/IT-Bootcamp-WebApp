using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;

namespace RS1SeminarskiRad2020.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly ApplicationDbContext db;

      public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
      {
         _logger = logger;
         db = _db;
      }

      public IActionResult Index()
      {
         //Proslijedi 3 zadnja kursa
         List<Kurs> najnovijiKursevi = db.Kursevi.Select(_k => new Kurs
         {
            KursID = _k.KursID,
            Naziv = _k.Naziv,
            Opis = _k.Opis,
            DatumPocetka = _k.DatumPocetka
         }).ToList();
         najnovijiKursevi.Sort((x, y) => DateTime.Compare(x.DatumPocetka, y.DatumPocetka));
         if (najnovijiKursevi.Count > 6)
            najnovijiKursevi.RemoveRange(0, najnovijiKursevi.Count - 6 - 1);
         najnovijiKursevi.Reverse();
         for (int i = 0; i < najnovijiKursevi.Count; i++)
         {
            if(najnovijiKursevi[i].Opis.Length > 100)
            {
               string newOpis = najnovijiKursevi[i].Opis.Substring(0, 100);
               najnovijiKursevi[i].Opis = newOpis + "...";
            }
         }
         ViewData["najnovijiKursevi"] = najnovijiKursevi;
         return View();
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
