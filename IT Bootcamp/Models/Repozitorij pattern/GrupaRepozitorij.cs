using RS1SeminarskiRad2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models.Repozitorij_pattern
{
    public class GrupaRepozitorij : IGrupaRepozitorij
    {
        public readonly ApplicationDbContext db;
        public GrupaRepozitorij(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IEnumerable<Grupa> Grupe
        {
            get
            {
                return db.Grupa;
            }
        }
        public Grupa GetGrupaById(int grupaId)
        {
            return db.Grupa.FirstOrDefault(g => g.GrupaID == grupaId);
        }
        public void DeleteGrupaById(int grupaId)
        {

            var pronadjena = GetGrupaById(grupaId);
            db.Remove(pronadjena);
            db.SaveChanges();
        }
    }
}
