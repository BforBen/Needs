using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Needs.Api.Models;
using System.Linq;
using MongoDB.Driver;

namespace Needs.Api.Controllers
{
    [RoutePrefix("{type:values(_test|benefits|channels|duties|functions|interactions|life-events|needs|powers|processes|services|subjects)}")]
    public class EsdController : ApiController
    {
        IMongoDatabase mdb = new MongoClient("mongodb://api:Guildford1@ds034198.mongolab.com:34198/gbc-needs").GetDatabase("gbc-needs");
        
        [Route]
        [HttpGet]
        [ResponseType(typeof(IList<EsdEntry>))]
        public async Task<IHttpActionResult> List(string type)
        {
            FilterDefinition<EsdEntry> filter = Builders<EsdEntry>.Filter.Empty;

            var data = await mdb.GetCollection<EsdEntry>(type).FindAsync(filter);

            return Ok(await data.ToListAsync());
        }

        [Route("{id:long}", Name = "EsdDetails")]
        [HttpGet]
        [ResponseType(typeof(EsdEntry))]
        public async Task<IHttpActionResult> Detail(string type, long id)
        {
            FilterDefinition<EsdEntry> filter = Builders<EsdEntry>.Filter.Eq<long>("_id", id);

            var data = await mdb.GetCollection<EsdEntry>(type).FindAsync(filter);

            var list = await data.ToListAsync();

            return Ok(list.FirstOrDefault());
        }

        [Route]
        [HttpPost]
        [ResponseType(typeof(EsdEntry))]
        public async Task<IHttpActionResult> New(string type, EsdEntry entry)
        {
            await mdb.GetCollection<EsdEntry>(type).InsertOneAsync(entry);
            return Created(Url.Link("EsdDetails", new { id = entry.Id, type = type }), entry);
        }

        [Route("{id:long}")]
        [HttpPost]
        [ResponseType(typeof(EsdEntry))]
        public async Task<IHttpActionResult> Edit(string type, long id, Newtonsoft.Json.Linq.JObject entry)
        {
            FilterDefinition<EsdEntry> filter =  Builders<EsdEntry>.Filter.Eq<long>("_id", id);

            UpdateDefinition<EsdEntry> update = null;

            foreach(var j in entry)
            {
                if (j.Key != "id")
                {
                    update.Set(j.Key, j.Value);
                }
            }
            
            if (update == null)
            {
                return BadRequest();
            }

            var data = await mdb.GetCollection<EsdEntry>(type).FindOneAndUpdateAsync(filter, update);

            return Ok(data);
        }

        [Route("{id:int}")]
        [HttpDelete]
        [ResponseType(typeof(bool))]
        public async Task<IHttpActionResult> Delete(string type, long id)
        {
            FilterDefinition<EsdEntry> filter = Builders<EsdEntry>.Filter.Eq<long>("_id", id);

            var data = await mdb.GetCollection<EsdEntry>(type).DeleteOneAsync(filter);

            return Ok(data.IsAcknowledged);
        }
    }
}
