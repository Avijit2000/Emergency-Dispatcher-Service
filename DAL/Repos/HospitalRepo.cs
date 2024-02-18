using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class HospitalRepo : Repo, IRepo<hospital, int, bool>
    {
        public bool Add(hospital obj)
        {
            db.hospitals.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.hospitals.Find(id);
            db.hospitals.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<hospital> Get()
        {
            return db.hospitals.ToList();
        }

        public hospital Get(int id)
        {
            return db.hospitals.Find(id);
        }

        public bool Update(hospital obj)
        {
            var d = db.hospitals.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.address = obj.address;
            return db.SaveChanges() > 0;
        }
    }
}
