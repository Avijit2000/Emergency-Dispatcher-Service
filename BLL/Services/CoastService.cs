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
    public class CoastService
    {
        public static List<CoastDTO> GetCoast()
        {
            var data = DataAccessFactory.CoastDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<coastguard, CoastDTO>());
            var mapper = new Mapper(config);
            var Coasts = mapper.Map<List<CoastDTO>>(data);
            return Coasts;
        }
        public static CoastDTO Get(int id)
        {
            var data = DataAccessFactory.CoastDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<coastguard, CoastDTO>());
            var mapper = new Mapper(config);
            var Coast = mapper.Map<CoastDTO>(data);
            return Coast;
        }
        public static bool Add(CoastDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<CoastDTO, coastguard>();
                cfg.CreateMap<coastguard, CoastDTO>();
            });
            var mapper = new Mapper(config);
            var Coast = mapper.Map<coastguard>(dto);
            var result = DataAccessFactory.CoastDataAccess().Add(Coast);
            return result;
        }

        public static bool Delete(int Id)
        {
            bool flag = false;
            flag = DataAccessFactory.CoastDataAccess().Delete(Id);
            return flag;
        }

        public static bool Update(CoastDTO obj)
        {
            var r = new coastguard();
            r.id = obj.Id;
            r.name = obj.Name;
            r.address = obj.Address;
            var flag = DataAccessFactory.CoastDataAccess().Update(r);
            return flag;
        }
    }
}
