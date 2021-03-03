using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.PolaznikGrupaVM
{
    public class PolaznikGrupaIndexVM
    {
        public int KursID { get; set; }
        public List<SelectListItem> Kursevi { get; set; }

        public string KorisnikId { get; set;}
        public List<SelectListItem> Polaznici { get; set;}
        public int GrupaID { get; set; }
        public List<SelectListItem> Grupe { get; set; }

    }
}
