using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
    public class Polaznik
    {
        [Key]
        [ForeignKey("Korisnik")]
        public string KorisnikId { get; set; }
        public string Fakultet { get; set; }
        public virtual Korisnik Korisnik { get; set; }
    }
}
