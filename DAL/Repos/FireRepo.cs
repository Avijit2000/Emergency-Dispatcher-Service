using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class FireRepo : Repo, IRepo<fireservice, int, bool>
    {
        public bool Add(fireservice obj)
        {
            db.fireservices.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.fireservices.Find(id);
            db.fireservices.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<fireservice> Get()
        {
            return db.fireservices.ToList();
        }

        public fireservice Get(int id)
        {
            return db.fireservices.Find(id);
        }

        public bool Update(fireservice obj)
        {
            var d = db.fireservices.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.address = obj.address;
            return db.SaveChanges() > 0;
        }
    }
}
