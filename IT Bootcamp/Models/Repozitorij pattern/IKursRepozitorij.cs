using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models.Repozitorij_pattern
{
    public interface IKursRepozitorij
    {
        IEnumerable<Kurs> Kursevi { get; }
        Kurs GetKursById(int kursId);
    }
}
