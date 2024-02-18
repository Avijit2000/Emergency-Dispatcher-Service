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
    public class PoliceController : ApiController
    {
        [Route("api/polices")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = PoliceService.GetPolice();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/polices/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = PoliceService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/polices/add")]
        [HttpPost]
        public HttpResponseMessage Add(PoliceDTO police)
        {
            if (ModelState.IsValid)
            {
                var data = PoliceService.Add(police);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }

        [HttpPost]
        [Route("api/polices/delete/{Id}")]
        public HttpResponseMessage DeletePolice(int Id)
        {
            var isreq = PoliceService.Delete(Id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Police deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed!");
        }

        [HttpPost]
        [Route("api/polices/update")]
        public HttpResponseMessage Update(PoliceDTO obj)
        {
            var isreq = PoliceService.Update(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }
    }
}
