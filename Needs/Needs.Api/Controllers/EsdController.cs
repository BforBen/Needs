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
using MongoDB.Bson;

namespace Needs.Api.Controllers
{
    [RoutePrefix("{type:values(_test|benefits|channels|duties|functions|interactions|life-events|needs|powers|processes|services|subjects)}")]
    public class EsdController : ApiController
    {
        IMongoDatabase mdb = new MongoClient("mongodb://api:Guildford1@ds034198.mongolab.com:34198/gbc-needs").GetDatabase("gbc-needs");
        
        [Route("{id:int?}")]
        [HttpGet]
        [ResponseType(typeof(IList<EsdEntry>))]
        public async Task<IHttpActionResult> List(string type, int? id = null)
        {
            FilterDefinition<EsdEntry> filter = Builders<EsdEntry>.Filter.Empty;

            if (id.HasValue)
            {
                filter = Builders<EsdEntry>.Filter.Eq<int>("id", id.Value);
            }

            var data = await mdb.GetCollection<EsdEntry>(type).FindAsync(filter);
            return Ok(await data.ToListAsync());
        }
    }
}
