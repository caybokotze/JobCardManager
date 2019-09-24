﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers.Api
{
    public class ApproveController : ApiController
    {
        private ApplicationDbContext _context;
        public ApproveController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/ApproveQuote
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ApproveQuote/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ApproveQuote
        [HttpPost]
        public IHttpActionResult Post([FromBody]ApproveQuote approve)
        {
            if (approve.Val)
            {
                var quote = _context.Quotations.SingleOrDefault(s => s.Id == approve.ValId);
                quote.Approve = true;
                //
                _context.Entry(quote).State = EntityState.Modified;
                _context.SaveChanges();

                JobCard jobCard = new JobCard();
                jobCard.CreatedAt = DateTime.Now;
                _context.JobCards.Add(jobCard);
                _context.SaveChanges();

                return Ok();
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        // PUT: api/ApproveQuote/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApproveQuote/5
        public void Delete(int id)
        {
        }
    }

    public class ApproveQuote
    {
        public bool Val { get; set; }
        public int ValId { get; set; }
    }
}
