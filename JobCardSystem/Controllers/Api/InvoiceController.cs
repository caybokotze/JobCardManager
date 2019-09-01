using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web.Http;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers.Api
{
    public class InvoiceController : ApiController
    {
        private ApplicationDbContext _context;
        public InvoiceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return null;
        }

        [HttpPost]
        public IHttpActionResult Post()
        {
            return null;
        }


    }
}
