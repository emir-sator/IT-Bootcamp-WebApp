using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RS1SeminarskiRad2020.Data;
using RS1SeminarskiRad2020.Models;
using RS1SeminarskiRad2020.ViewModels.GrupaVM;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace RS1SeminarskiRad2020.Controllers
{
    public class GrupaController : Controller
    {
        private readonly ApplicationDbContext db;
        public GrupaController(ApplicationDbContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            List<Grupa> grupe = db.Grupa.Select(d => new Grupa
            {
                GrupaID = d.GrupaID,
                Naziv = d.Naziv
            }).ToList();
            ViewData["grupe"] = grupe;
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var grupa = db.Grupa.Find(id);
            db.Remove(grupa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Save(Grupa grupa)
        {
            db.Add(grupa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
