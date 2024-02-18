using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emergency_Dispatcher_Service.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/users")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = UserService.GetUser();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/users/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/users/add")]
        [HttpPost]
        public HttpResponseMessage Add(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                var data = UserService.Add(user);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
            }
           
        }
        [HttpPost]
        [Route("api/users/delete/{Id}")]
        public HttpResponseMessage DeleteUser(int Id)
        {
            var isreq = UserService.Delete(Id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "User deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed!");
        }

        [HttpPost]
        [Route("api/users/update")]
        public HttpResponseMessage Update(UserDTO obj)
        {
            var isreq = UserService.Update(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }

    }
}
