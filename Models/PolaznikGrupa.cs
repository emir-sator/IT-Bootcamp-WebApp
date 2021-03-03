using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
    public class PolaznikGrupa
    {
        
        public int GrupaID { get; set; }
        public Grupa Grupa { get; set; }
        
        public int KursID { get; set; }
        public Kurs Kurs { get; set; }
       
        public string KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
        
      

    }
}
