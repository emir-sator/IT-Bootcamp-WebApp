using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
   public class Predavanje
   {
      public int PredavanjeID { get; set; }
      public string Naziv { get; set; }
      public DateTime Datum { get; set; }
      public TimeSpan SatnicaPocetka { get; set; }
      public TimeSpan SatnicaZavrsetka { get; set; }
      public int KursID { get; set; }
      public Kurs Kurs { get; set; }
      public string KorisnikId { get; set; }
      public Korisnik Korisnik { get; set; }
      public int KabinetID { get; set; }
      public Kabinet Kabinet { get; set; }
        
   }
}
