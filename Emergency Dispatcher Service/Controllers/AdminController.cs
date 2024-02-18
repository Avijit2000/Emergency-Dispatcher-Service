using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emergency_Dispatcher_Service.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AdminController : ApiController
    {
        [Route("api/admins")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AdminService.GetAdmin();
            return Request.CreateResponse(HttpStatusCode.OK, data); 
        }
        [Route("api/admins/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AdminService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/admins/add")]
        [HttpPost]
        public HttpResponseMessage Post(AdminDTO admin)
        {
            var resp = AdminService.Add(admin);
            if(resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new {Msg= "Inserted", data = resp});
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("api/admins/delete/{Id}")]
        public HttpResponseMessage DeleteAdmin(int Id)
        {
            var isreq = AdminService.Delete(Id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Admin deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed!");
        }

        [HttpPost]
        [Route("api/admins/update")]
        public HttpResponseMessage Update(AdminDTO obj)
        {
            var isreq = AdminService.Update(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }
    }
}
