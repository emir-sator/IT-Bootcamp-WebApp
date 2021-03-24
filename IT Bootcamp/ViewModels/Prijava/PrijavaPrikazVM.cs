using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.Prijava
{
    public class PrijavaPrikazVM
    {
        public int KursID { get; set; }
        public List<SelectListItem> Kursevi { get; set; }
        public List<Red> Redovi { get; set; }
        public class Red
        {
            public int Id { get; set; }
            public int KursID { get; set; }
            public string NazivKurs { get; set; }
            public string UserID { get; set; }
            public string ImePrezime { get; set; }
            public DateTime DatumPrijave { get; set; }
            public bool Polozio { get; set; }

           

        }
    }
}
