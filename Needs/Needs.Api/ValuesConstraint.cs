using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Collections.Generic;

namespace Needs.Api
{
    /// <summary>
    /// Source: http://blogs.msdn.com/b/webdev/archive/2013/10/17/attribute-routing-in-asp-net-mvc-5.aspx
    /// </summary>
    public class ValuesConstraint : IHttpRouteConstraint
    {
        private readonly string[] validOptions;
        public ValuesConstraint(string options)
        {
            validOptions = options.Split('|');
        }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}