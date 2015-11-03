using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Needs.Api.Models;

using MongoDB.Driver;

namespace Needs.Api.Controllers
{
    [RoutePrefix("{type}")]
    public class EsdController : ApiController
    {
        IMongoDatabase mdb = new MongoClient("mongodb://api:Guildford1#@ds034198.mongolab.com:34198").GetDatabase("gbc-needs");

        [Route]
        [HttpGet]
        public IHttpActionResult List(string type)
        {
            return Ok(mdb.GetCollection<EsdEntry>(type));
        }
    }
}
