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
    public class AmbulanceController : ApiController
    {
        [Route("api/ambulances")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = AmbulanceService.GetAmbulance();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/ambulances/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = AmbulanceService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/ambulances/add")]
        [HttpPost]
        public HttpResponseMessage Post(AmbulanceDTO Ambulance)
        {
            var resp = AmbulanceService.Add(Ambulance);
            if (resp)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = resp });
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [HttpPost]
        [Route("api/ambulances/delete/{Id}")]
        public HttpResponseMessage DeleteAmbulance(int Id)
        {
            var isreq = AmbulanceService.Delete(Id);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Ambulance deleted!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "failed!");
        }

        [HttpPost]
        [Route("api/ambulances/update")]
        public HttpResponseMessage Update(AmbulanceDTO obj)
        {
            var isreq = AmbulanceService.Update(obj);
            if (isreq) { return Request.CreateResponse(HttpStatusCode.OK, "Data updated!"); }
            return Request.CreateResponse(HttpStatusCode.OK, "Update failed!");
        }
    }
}
