using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.ViewModels.KursVM
{
    public class PolozenikurseviVM
    {
        public string KorisnikId { get; set; }
        public List<Red> Redovi { get; set; }

        public class Red
        {
            public int KursID { get; set; }
            public string KorisnikId { get; set; }
            public string NazivKursa { get; set; }
            public string DatumPocetka { get; set; }
            public string DatumZavrsetka { get; set; }
            public string Opis { get; set; }

        }
       


    }
}
