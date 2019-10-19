using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobCardSystem.Persistence;
using System.Data.Entity;

namespace JobCardSystem.Controllers.Api
{
    public class QuoteTotalController : ApiController
    {
        private ApplicationDbContext _context;

        public QuoteTotalController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/QuoteTotal
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/QuoteTotal/5
        public IHttpActionResult Get(int id)
        {
            var sum = 0.00;
            var quote = _context.Quotations.SingleOrDefault(s => s.Id == id);
            var stockItemQuantities = _context.StockItemQuantities.Include(i => i.StockItem).Where(w => w.QuotationId == quote.Id);
            foreach (var item in stockItemQuantities)
            {
                sum += (item.StockItem.SellingPrice * item.Quantity);
            }

            quote.Total = sum;
            //
            return Ok(quote);
        }

        // POST: api/QuoteTotal
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/QuoteTotal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/QuoteTotal/5
        public void Delete(int id)
        {
        }
    }
}
