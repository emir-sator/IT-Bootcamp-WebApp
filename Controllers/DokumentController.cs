using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RS1SeminarskiRad2020.Models;
using RS1SeminarskiRad2020.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using RS1SeminarskiRad2020.ViewModels.Dokument;
using System.Security.Claims;

namespace RS1SeminarskiRad2020.Controllers
{
   public class DokumentController : Controller
   {
      private readonly ApplicationDbContext db;
      public DokumentController(ApplicationDbContext _db)
      {
         db = _db;
      }
      public IActionResult Index(int kursID)
      {
         if (kursID == 0)
         {
            List<Dokument> Dokumenti = db.Dokument.Select(d => new Dokument
            {
               DokumentID = d.DokumentID,
               Naslov = d.Naslov,
               Ekstenzija = d.Ekstenzija,
               DatumObjavljivanja = d.DatumObjavljivanja,
               SatnicaObjavljivanja = d.SatnicaObjavljivanja,
               TipDokumentaID = d.TipDokumentaID,
               TipDokumenta = db.TipDokumenta.Where(_td => _td.TipDokumentaID == d.TipDokumentaID).FirstOrDefault(),
               KorisnikId = d.KorisnikId,
               KursID = d.KursID,
               Kurs = db.Kursevi.Where(_k => _k.KursID == d.KursID).FirstOrDefault()
            }).ToList();
            ViewData["dokumenti"] = Dokumenti;
         }
         else
         {
            List<Dokument> Dokumenti = db.Dokument.Where(doc => doc.KursID == kursID).Select(d => new Dokument
            {
               DokumentID = d.DokumentID,
               Naslov = d.Naslov,
               Ekstenzija = d.Ekstenzija,
               DatumObjavljivanja = d.DatumObjavljivanja,
               SatnicaObjavljivanja = d.SatnicaObjavljivanja,
               TipDokumentaID = d.TipDokumentaID,
               TipDokumenta = db.TipDokumenta.Where(_td => _td.TipDokumentaID == d.TipDokumentaID).FirstOrDefault(),
               KorisnikId = d.KorisnikId,
               KursID = d.KursID,
               Kurs = db.Kursevi.Where(_k => _k.KursID == d.KursID).FirstOrDefault()
            }).ToList();
            ViewData["dokumenti"] = Dokumenti;
         }
         return View();
      }
      public IActionResult Dodaj(int idKursa, string idUser)
      {
         List<TipDokumenta> TipDokumenata = db.TipDokumenta.Select(td => new TipDokumenta
         {
            TipDokumentaID = td.TipDokumentaID,
            Naziv = td.Naziv,
            Dokumenti = td.Dokumenti
         }).ToList();
         KursUserDokumentVM viewM = new KursUserDokumentVM { kursID = idKursa, userID = idUser, TipDokumenata = TipDokumenata };
         ViewData["DodajDokumentData"] = viewM;
         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Upload(IFormFile file, Dokument df, int IdKursa)
      {
         var IdUser= User.FindFirstValue(ClaimTypes.NameIdentifier);
         df.TipDokumenta = db.TipDokumenta.Where(td => td.TipDokumentaID == df.TipDokumentaID).FirstOrDefault();
         //df.Ekstenzija = Path.GetExtension(file.FileName);

         //var fileName = Path.GetFileNameWithoutExtension(file.FileName);
         //var extension = Path.GetExtension(file.FileName);
         var fileModel = new Dokument
         {
            DokumentID = df.DokumentID,
            Naslov = df.Naslov,
            //Ekstenzija = df.Ekstenzija,
            DatumObjavljivanja = DateTime.UtcNow.Date,
            SatnicaObjavljivanja = DateTime.UtcNow.TimeOfDay,
            TipDokumentaID = df.TipDokumentaID,
            KorisnikId = IdUser,
            KursID = IdKursa
         };
         using (var dataStream = new MemoryStream())
         {
            await file.CopyToAsync(dataStream);
            fileModel.Data = dataStream.ToArray();
         }
         db.Dokument.Add(fileModel);
         db.SaveChanges();
         return RedirectToAction("Index");
      }
   }
}
