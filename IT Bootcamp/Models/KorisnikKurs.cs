using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
    public class KorisnikKurs
    {
        public int PrijavaID { get; set; }
        public int KursID { get; set; }
        public  Kurs Kurs { get; set; }
        public string KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public DateTime DatumPrijave { get; set; }
        public bool Polozio { get; set; }

     }
}
