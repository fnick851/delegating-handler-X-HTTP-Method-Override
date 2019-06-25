using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTPMethodHandler.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("single_value")]
        public string GetSingleValue()
        {
            return "value";
        }

        [HttpPost]
        [Route("single_value")]
        public string PostSingleValue(string para1)
        {
            return para1;
        }

        [HttpPatch]
        [Route("single_value")]
        public string HeadSingleValue()
        {
            return "HEAD reached";
        }
    }
}
