using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Operations;
using System.Collections.Generic;

namespace RS1SeminarskiRad2020.Models
{
    
    public class Korisnik:IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public byte[] Slika { get; set; }
        public string Grad { get; set; }
        public ICollection<KorisnikKurs> KorisnikKurs { get; set; }
        public virtual Polaznik Polaznik { get; set; }
    }
}
