using RS1SeminarskiRad2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.Prijava
{
    public class PrijavaVM
    {
        public int PrijavaID { get; set; }
        public string UserID { get; set; }
        public Korisnik Korisnik { get; set; }
        public string ImePrezime { get; set; }
        public int KursID { get; set; }
        public Kurs Kurs { get; set; }
        public string NazivKursa { get; set; }
        public DateTime DatumPrijave { get; set; }
        public bool Polozio { get; set; }





    }
} 
