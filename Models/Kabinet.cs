using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
   public class Kabinet
   {
      public int KabinetID { get; set; }
      public string Naziv { get; set; }
      public int Kapacitet { get; set; }
      public List<Predavanje> Predavanja { get; set; }
   }
}
