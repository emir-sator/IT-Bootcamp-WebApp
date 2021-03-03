using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
   public class Dokument
   {
      public int DokumentID { get; set; }
      public string Naslov { get; set; }
      public string Ekstenzija {  get; set; }
      public DateTime DatumObjavljivanja { get; set; }
      public TimeSpan SatnicaObjavljivanja { get; set; }
      public string KorisnikId { get; set; }
      public Korisnik Korisnik { get; set; }
      public int KursID { get; set; }
      public Kurs Kurs { get; set; }
      public int TipDokumentaID { get; set; }
      public TipDokumenta TipDokumenta { get; set; }
      public byte[] Data { get; set; }
   }
}
