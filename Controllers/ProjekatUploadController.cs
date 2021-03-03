using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using RS1SeminarskiRad2020.ViewModels.ProjekatUploadVM;

namespace RS1SeminarskiRad2020.Controllers
{
    public class ProjekatUploadController : Controller
    {

        private readonly ApplicationDbContext db;

        public ProjekatUploadController(ApplicationDbContext _db)
        {
            db = _db;
        }

        private async Task<ProjekatUpload> LoadAllFiles()
        {
            var viewModel = new ProjekatUpload();
            viewModel.FajloviBaza = await db.ProjekatBaza.ToListAsync();

            return viewModel;
        }

        public async Task<IActionResult> Index()
        {
            var fileuploadViewModel = await LoadAllFiles();
            ViewBag.Message = TempData["Message"];
            return View(fileuploadViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UploadToDatabase(List<IFormFile> files, string description)
        {
            foreach (var file in files)
            {
                var user = User.Identity.Name;
                var korisnikProjekta = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extension = Path.GetExtension(file.FileName);
                var fileModel = new ProjekatBaza
                {

                    Naziv = fileName,
                    Opis = description,
                    TipFajla = file.ContentType,
                    DatumUploada = DateTime.Now
                };
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    fileModel.fajl = dataStream.ToArray();
                }
                db.ProjekatBaza.Add(fileModel);
                db.SaveChanges();
            }
            TempData["Message"] = "Uspješno ste učitali fajl!";
            return RedirectToAction("Index");
        }
       
    }
}
