using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.PolaznikGrupaVM
{
    public class GrupePrikazVM
    {
        public int KursID { get; set; }
        public List<SelectListItem> Kursevi { get; set; }
        public int GrupaID { get; set; }
        public List<SelectListItem> Grupe { get; set; }
        public List<Red> Redovi { get; set; }
        public class Red
        {
            public string KorisnikId { get; set; }
            public int KursID { get; set; }
            public int GrupaID { get; set; }
            public string ImePrezime { get; set; }
            public string NazivKursa { get; set; }
            public string NazivGrupe { get; set; }

        }
     

    }
}
