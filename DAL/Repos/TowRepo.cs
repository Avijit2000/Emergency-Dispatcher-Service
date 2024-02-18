using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TowRepo : Repo, IRepo<towservice, int, bool>
    {
        public bool Add(towservice obj)
        {
            db.towservices.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.towservices.Find(id);
            db.towservices.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<towservice> Get()
        {
            return db.towservices.ToList();
        }

        public towservice Get(int id)
        {
            return db.towservices.Find(id);
        }

        public bool Update(towservice obj)
        {
            var d = db.towservices.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.address = obj.address;
            return db.SaveChanges() > 0;
        }
    }
}
