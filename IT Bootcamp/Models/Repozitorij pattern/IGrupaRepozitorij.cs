using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models.Repozitorij_pattern
{
    public interface IGrupaRepozitorij
    {
        IEnumerable<Grupa> Grupe { get; }
        Grupa GetGrupaById(int grupaID);
        void DeleteGrupaById(int grupaID);
    }
}
