using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Needs.Api.Models;

namespace Needs.Api.Controllers
{
    [RoutePrefix("{type}")]
    public class EsdController : ApiController
    {
        [Route]
        [HttpGet]
        public IHttpActionResult List(string Type)
        {
            return Ok(DocumentDBRepository<EsdEntry>.GetItems(e => e.Type == Type));
        }
    }
}
