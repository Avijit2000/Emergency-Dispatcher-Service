using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AdminRepo : Repo, IRepo<admin, int, bool>
    {
        public bool Add(admin obj)
        {
            db.admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ext = db.admins.Find(id);
            db.admins.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<admin> Get()
        {
            return db.admins.ToList();
        }

        public admin Get(int id)
        {
            return db.admins.Find(id);
        }

        public bool Update(admin obj)
        {
            var d = db.admins.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.pass = obj.pass;
            return db.SaveChanges() > 0;
        }
    }
}
