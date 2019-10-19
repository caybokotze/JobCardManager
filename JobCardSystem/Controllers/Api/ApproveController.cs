using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobCardSystem.BusinessLogic;
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

                if (quote.Approve == false)
                {
                    JobCard jobCard = new JobCard();
                    jobCard.CreatedAt = DateTime.Now;
                    jobCard.QuotationId = approve.ValId;
                    jobCard.CustomerId = quote.CustomerId;
                    jobCard.JobStatusId = 3;
                    //
                    _context.JobCards.Add(jobCard);
                    _context.SaveChanges();
                }

                quote.Approve = true;
                //Mailer.SendInvoiceEmail(quote.Id, "Please have a look at this invoice.");
                //
                _context.Entry(quote).State = EntityState.Modified;
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
