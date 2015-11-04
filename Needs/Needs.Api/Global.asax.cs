using System.Web.Http;

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace Needs.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var camelConvention = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("CamelCase", camelConvention, type => true);

            BsonClassMap.RegisterClassMap<Models.EsdEntry>();
        }
    }
}
