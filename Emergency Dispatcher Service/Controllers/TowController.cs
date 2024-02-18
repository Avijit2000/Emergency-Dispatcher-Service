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
    public class TowController : ApiController
    {
        [Route("api/tows")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = TowService.GetTow();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/tows/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = TowService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/tows/add")]
        [HttpPost]
        public HttpResponseMessage Post(TowDTO Tow)
        {
            var resp = TowService.Add(Tow);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("api/tows/delete/{Id}")]
        public HttpResponseMessage DeleteTow(int Id)
        {
            var isreq = TowService.Delete(Id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Tow service deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed!");
        }

        [HttpPost]
        [Route("api/tows/update")]
        public HttpResponseMessage Update(TowDTO obj)
        {
            var isreq = TowService.Update(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }
    }
}
