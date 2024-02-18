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
    public class FireController : ApiController
    {
        [Route("api/fires")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = FireService.GetFire();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/fires/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = FireService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/fires/add")]
        [HttpPost]
        public HttpResponseMessage Post(FireDTO Fire)
        {
            var resp = FireService.Add(Fire);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("api/fires/delete/{Id}")]
        public HttpResponseMessage DeleteFire(int Id)
        {
            var isreq = FireService.Delete(Id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Fire Service deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed!");
        }

        [HttpPost]
        [Route("api/fires/update")]
        public HttpResponseMessage Update(FireDTO obj)
        {
            var isreq = FireService.Update(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }
    }
}
