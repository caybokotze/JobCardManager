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
    public class CustomerController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        //
        public IHttpActionResult Get(string value = null)
        {
            IQueryable<Customer> customers = _context.Customers;

            if (!String.IsNullOrWhiteSpace(value))
            {
                customers = _context.Customers.Where(n => n.Name.Contains(value));
            }
            return Ok(customers);
        }
    }
}
