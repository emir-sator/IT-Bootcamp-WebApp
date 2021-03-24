using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
   public class TipDokumenta
   {
      public int TipDokumentaID { get; set; }
      public string Naziv { get; set; }
      public List<Dokument> Dokumenti { get; set; }
   }
}
