using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PoliceRepo : Repo, IRepo<police, int, bool>
    {
        public bool Add(police obj)
        {
            db.police.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.police.Find(id);
            db.police.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<police> Get()
        {
            return db.police.ToList();
        }

        public police Get(int id)
        {
            return db.police.Find(id);
        }

        public bool Update(police obj)
        {
            var d = db.police.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.address = obj.address;
            return db.SaveChanges() > 0;
        }
    }
}
