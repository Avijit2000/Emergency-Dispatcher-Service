using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AmbulanceRepo : Repo, IRepo<ambulance, int, bool>
    {
        public bool Add(ambulance obj)
        {
            db.ambulances.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.ambulances.Find(id);
            db.ambulances.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<ambulance> Get()
        {
            return db.ambulances.ToList();
        }

        public ambulance Get(int id)
        {
            return db.ambulances.Find(id);
        }

        public bool Update(ambulance obj)
        {
            var d = db.ambulances.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.address = obj.address;
            return db.SaveChanges() > 0;
        }
    }
}
