using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.Dokument
{
   public class TipDokumentaVM
   {
      public int DokumentID { get; set; }
      public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> Departments { get; set; }
   }
}
