using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
    public abstract class Projekat
    {
        public int ProjekatID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public string TipFajla { get; set; }
        public DateTime DatumUploada { get; set; }
     
    }
}
