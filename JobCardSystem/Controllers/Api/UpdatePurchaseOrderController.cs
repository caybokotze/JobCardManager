using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobCardSystem.Controllers.Api
{
    public class UpdatePurchaseOrderController : ApiController
    {
        // GET: api/UpdatePurchaseOrder
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UpdatePurchaseOrder/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UpdatePurchaseOrder
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UpdatePurchaseOrder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UpdatePurchaseOrder/5
        public void Delete(int id)
        {
        }
    }
}
