using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Needs.Api.Models;

using MongoDB.Driver;

namespace Needs.Api.Controllers
{
    //[RoutePrefix("{type}")]
    public class EsdController : ApiController
    {
        IMongoDatabase mdb = new MongoClient("mongodb://api:Guildford1@ds034198.mongolab.com:34198").GetDatabase("gbc-needs");
        
        [Route("{type:values(needs|services|functions)}", Order = 5)]
        [HttpGet]
        [ResponseType(typeof(IList<EsdEntry>))]
        public async Task<IHttpActionResult> List(string type)
        {
            var data = await mdb.GetCollection<EsdEntry>(type).AsQueryable().ToListAsync();
            return Ok(data);
        }
    }
}
