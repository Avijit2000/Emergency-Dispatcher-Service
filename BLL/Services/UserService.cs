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
    public class UserService
    {
        public static List<UserDTO> GetUser()
        {
            var data = DataAccessFactory.UserDataAccess().Get();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<user, UserDTO>());
            var mapper = new Mapper(config);
            var Users = mapper.Map<List<UserDTO>>(data);
            return Users;
        }
        public static UserDTO Get(int id)
        {
            var data = DataAccessFactory.UserDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<user, UserDTO>());
            var mapper = new Mapper(config);
            var User = mapper.Map<UserDTO>(data);
            return User;
        }
        /*public static UserDTO Add(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, user>();
                cfg.CreateMap<user, UserDTO>();
            });
            var mapper = new Mapper(config);
            var data = mapper.Map<user>(dto);
            var result = DataAccessFactory.UserDataAccess().Add(data);
            var redata = mapper.Map<UserDTO>(result);
            return redata;
        }*/
        public static bool Add(UserDTO dto)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UserDTO, user>();
                cfg.CreateMap<user, UserDTO>();
            });
            var mapper = new Mapper(config);
            var user = mapper.Map<user>(dto);
            var result = DataAccessFactory.UserDataAccess().Add(user);
            return result;
        }

        public static bool Delete(int Id)
        {
            bool flag = false;
            flag = DataAccessFactory.UserDataAccess().Delete(Id);
            return flag;
        }

        public static bool Update(UserDTO obj)
        {
            var r = new user();
            r.id = obj.Id;
            r.name = obj.Name;
            r.pass = obj.Pass;
            var flag = DataAccessFactory.UserDataAccess().Update(r);
            return flag;
        }

    }
}
