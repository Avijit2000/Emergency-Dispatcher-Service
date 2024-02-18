using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AdminService
    {
        public static List<AdminDTO> GetAdmin()
        {
            var data = DataAccessFactory.AdminDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<admin, AdminDTO>());
            var mapper = new Mapper(config);
            var admins = mapper.Map<List<AdminDTO>>(data);
            return admins;
        }
        public static AdminDTO Get(int id)
        {
            var data = DataAccessFactory.AdminDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<admin, AdminDTO>());
            var mapper = new Mapper(config);
            var admin = mapper.Map<AdminDTO>(data);
            return admin;
        }
        public static bool Add(AdminDTO dto)
        {
            var config = new MapperConfiguration(cfg => { 
                cfg.CreateMap<AdminDTO, admin>();
                cfg.CreateMap<admin, AdminDTO>();
                });
            var mapper = new Mapper(config);
            var admin = mapper.Map<admin>(dto);
            var result = DataAccessFactory.AdminDataAccess().Add(admin);
            return result;
        }
        public static bool Delete(int Id)
        {
            bool flag = false;
            flag = DataAccessFactory.AdminDataAccess().Delete(Id);
            return flag;
        }

        public static bool Update(AdminDTO obj)
        {
            var r = new admin();
            r.id = obj.Id;
            r.name = obj.Name;
            r.pass = obj.Pass;
           var flag = DataAccessFactory.AdminDataAccess().Update(r);
            return flag;
        }
    }
}
