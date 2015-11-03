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
        [Route("_about")]
        [HttpGet]
        public IHttpActionResult About()
        {
            var Ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            return Ok(String.Format("{0}.{1}.{2}", Ver.Major, Ver.Minor, Ver.Build));
        }

        [Route("_hello")]
        [HttpGet]
        public IHttpActionResult Hello()
        {
            return Ok("Hello");
        }
    }
}
