using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UseRepo : Repo, IRepo<user, int, bool>
    {
        public bool Add(user obj)
        {
            db.users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool/*void*/ Delete(int id)
        {
            var ext = db.users.Find(id);
            db.users.Remove(ext);
            return db.SaveChanges() > 0;
        }

        public List<user> Get()
        {
            return db.users.ToList();
        }

        public user Get(int id)
        {
            return db.users.Find(id);
        }

        public bool Update(user obj)
        {
            var d = db.users.FirstOrDefault(x => x.id == obj.id);
            d.name = obj.name;
            d.pass = obj.pass;
            return db.SaveChanges() > 0;
        }
    }
}
