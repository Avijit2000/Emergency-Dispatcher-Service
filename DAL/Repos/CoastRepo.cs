using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CoastRepo : Repo, IRepo<coastguard, int, bool>
    {
        public bool Add(coastguard obj)
        {
            db.coastguards.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.coastguards.Find(id);
            db.coastguards.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<coastguard> Get()
        {
            return db.coastguards.ToList();
        }

        public coastguard Get(int id)
        {
            return db.coastguards.Find(id);
        }

        public bool Update(coastguard obj)
        {
            var d = db.coastguards.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.address = obj.address;
            return db.SaveChanges() > 0;
        }
    }
}
