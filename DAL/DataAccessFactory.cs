using DAL.EF;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<admin,int,bool> AdminDataAccess()
        {
            return new AdminRepo();
        }
        public static IRepo<user, int, bool> UserDataAccess()
        {
            return new UseRepo();
        }
        public static IRepo<police, int, bool> PoliceDataAccess()
        {
            return new PoliceRepo();
        }
        public static IRepo<hospital, int, bool> HospitalDataAccess()
        {
            return new HospitalRepo();
        }
        public static IRepo<fireservice, int, bool> FireDataAccess()
        {
            return new FireRepo();
        }
        public static IRepo<ambulance, int, bool> AmbulanceDataAccess()
        {
            return new AmbulanceRepo();
        }
        public static IRepo<towservice, int, bool> TowDataAccess()
        {
            return new TowRepo();
        }
        public static IRepo<coastguard, int, bool> CoastDataAccess()
        {
            return new CoastRepo();
        }
        public static IRepo<bombdisposal, int, bool> BombDataAccess()
        {
            return new BombRepo();
        }
    }
}
