using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class AuthController : ApiController
    {
        private eCommerceEntities context = new eCommerceEntities();

        [Route("api/Auth/Login")]
        public IHttpActionResult GetClientAuth(string l, string m)
        {
            var q = context.Clients.Where(s => s.Login == l)
                                   .Where(s => s.MotDePasse == m)
                                   .FirstOrDefault<Client>();
            if(q == null)
                return NotFound();

            return Ok(q);
        }


        [Route("api/Auth/Inscription")]
        public HttpResponseMessage GetClientInscription([FromUri]Client c)
        {
            try
            {
                context.Clients.Add(c);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
