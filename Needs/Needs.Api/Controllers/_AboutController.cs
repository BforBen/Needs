using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Needs.Api.Controllers
{
    public class _AboutController : ApiController
    {
        [Route("_about", Order = 1)]
        [HttpGet]
        public IHttpActionResult About()
        {
            var Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return Ok(String.Format("{0}.{1}.{2}", Ver.Major, Ver.Minor, Ver.Build));
        }

        [Route("_hello", Order = 1)]
        [HttpGet]
        public IHttpActionResult Hello()
        {
            return Ok("Hello");
        }
    }
}
