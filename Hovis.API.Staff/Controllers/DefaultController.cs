using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hovis.Api.Controllers
{
    public class DefaultController : ApiController
    {
        [Route("~/", Name = "default")]
        public IHttpActionResult Get()
        {
            return Ok("Hello");
        }
    }
}
