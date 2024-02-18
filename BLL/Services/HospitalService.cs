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
    public class HospitalService
    {
        public static List<HospitalDTO> GetHospital()
        {
            var data = DataAccessFactory.HospitalDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<hospital, HospitalDTO>());
            var mapper = new Mapper(config);
            var Hospitals = mapper.Map<List<HospitalDTO>>(data);
            return Hospitals;
        }
        public static HospitalDTO Get(int id)
        {
            var data = DataAccessFactory.HospitalDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<hospital, HospitalDTO>());
            var mapper = new Mapper(config);
            var Hospital = mapper.Map<HospitalDTO>(data);
            return Hospital;
        }
        public static bool Add(HospitalDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<HospitalDTO, hospital>();
                cfg.CreateMap<hospital, HospitalDTO>();
            });
            var mapper = new Mapper(config);
            var Hospital = mapper.Map<hospital>(dto);
            var result = DataAccessFactory.HospitalDataAccess().Add(Hospital);
            return result;
        }

        public static bool Delete(int Id)
        {
            bool flag = false;
            flag = DataAccessFactory.HospitalDataAccess().Delete(Id);
            return flag;
        }

        public static bool Update(HospitalDTO obj)
        {
            var r = new hospital();
            r.id = obj.Id;
            r.name = obj.Name;
            r.address = obj.Address;
            var flag = DataAccessFactory.HospitalDataAccess().Update(r);
            return flag;
        }
    }
}
