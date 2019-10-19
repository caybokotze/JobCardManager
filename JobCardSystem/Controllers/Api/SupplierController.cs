using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers.Api
{
    public class SupplierController : ApiController
    {
        private ApplicationDbContext _context;
        public SupplierController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: api/Supplier/5
        public IHttpActionResult Get(string value = null)
        {
            IQueryable<Supplier> suppliers = _context.Suppliers;

            if (!String.IsNullOrWhiteSpace(value))
            {
                suppliers = _context.Suppliers.Where(n => n.Name.Contains(value));
            }
            return Ok(suppliers);
        }

        // POST: api/Supplier
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Supplier/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Supplier/5
        public void Delete(int id)
        {
        }
    }
}
