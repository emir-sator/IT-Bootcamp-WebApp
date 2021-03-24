using RS1SeminarskiRad2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models.Repozitorij_pattern
{
    public class KursRepozitorij:IKursRepozitorij
    {
        private readonly ApplicationDbContext db;

        public KursRepozitorij(ApplicationDbContext _db)
        {
            db = _db;
        }

        public IEnumerable<Kurs> Kursevi
        {
            get
            {
                return db.Kursevi;
            }
        }
        public Kurs GetKursById(int kursId)
        {
            return db.Kursevi.FirstOrDefault(k => k.KursID == kursId);
        }

    }
}
