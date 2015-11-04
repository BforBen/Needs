using System.Web.Http;

using System.Threading.Tasks;
using MongoDB.Driver;

namespace Needs.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            MongoDB.Bson.Serialization.BsonClassMap.RegisterClassMap<Models.EsdEntry>();
        }
    }
}
