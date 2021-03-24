using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
    public class Grad
    {
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public string PTT { get; set; }
        public int DrzavaID { get; set; }
        public Drzava Drzava { get; set; }
        
    }
}
