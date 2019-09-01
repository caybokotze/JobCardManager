using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobCardSystem.Controllers.Api
{
    public class JobCardController : ApiController
    {
        // GET: api/JobCard
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JobCard/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JobCard
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JobCard/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JobCard/5
        public void Delete(int id)
        {
        }
    }
}
