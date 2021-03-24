using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.KursVM
{
   public class DodajKursVM
   {
      public int KursID { get; set; }
      public string Naziv { get; set; }
      public string Oznaka { get; set; }
      public int Cijena { get; set; }
      public DateTime DatumPocetka { get; set; }
      public DateTime DatumZavrsetka { get; set; }
      public string Opis { get; set; }
      public bool Aktivan { get; set; }
      public string UserID { get; set; }
   }
}
