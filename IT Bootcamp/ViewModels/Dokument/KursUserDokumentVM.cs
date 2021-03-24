using RS1SeminarskiRad2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.Dokument
{
   public class KursUserDokumentVM
   {
      public int kursID { get; set; }
      public string userID { get; set; }
      public List<TipDokumenta> TipDokumenata { get; set; }
   }
}
