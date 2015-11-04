using System.Web.Http;

using MongoDB.Driver;

namespace Needs.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            MongoDB.Bson.Serialization.BsonClassMap.RegisterClassMap<Models.EsdEntry>();

            IMongoDatabase mdb = new MongoClient("mongodb://api:Guildford1@ds034198.mongolab.com:34198/gbc-needs").GetDatabase("gbc-needs");

            mdb.GetCollection<Models.EsdEntry>("_test").InsertOneAsync(new Models.EsdEntry { Label = "Test", Description = "Just a test at " + System.DateTime.Now.ToString() }).RunSynchronously();
        }
    }
}
