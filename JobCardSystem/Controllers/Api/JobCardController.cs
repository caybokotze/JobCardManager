using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvoiceService;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;
using RestSharp;

namespace JobCardSystem.Controllers.Api
{
    public class JobCardController : ApiController
    {
        private ApplicationDbContext _context;
        public JobCardController()
        {
            _context = new ApplicationDbContext();

        }
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
        public IHttpActionResult Post([FromBody] JsonJobCardMappingObject quotationMap)
        {
            var quoteFromView = _context.Quotations.SingleOrDefault(s => s.Id == quotationMap.QuotationId);
            var stockItemQuanitites = _context.StockItemQuantities.Where(s => s.QuotationId == quoteFromView.Id);
            //
            var stockItemList = new List<StockItem>();
            //
            foreach (var stockItem in stockItemQuanitites)
            {
                _context.StockItemQuantities.Remove(stockItem);
                _context.SaveChanges();
            }
            //
            foreach (var stockItem in quotationMap.Items)
            {
                StockItemQuantity quantityItem = new StockItemQuantity();
                quantityItem.StockItemId = stockItem.Id;
                quantityItem.Quantity = stockItem.Quantity;
                quantityItem.QuotationId = quoteFromView.Id;
                //
                _context.Entry(quantityItem).State = EntityState.Modified;
                _context.SaveChanges();
                //
            }
            return Ok();
        }

        // PUT: api/JobCard/5
        public void Put(int id, [FromBody]string value)
        {
            //
        }

        // DELETE: api/JobCard/5
        public void Delete(int id)
        {
            //
        }
    }

    public class JsonJobCardMappingObject
    {
        public int QuotationId { get; set; }
        public int CustomerId { get; set; }
        public int JobCardId { get; set; }
        public string CustomerName { get; set; }
        public double Discount { get; set; }
        public string JobStatus { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        public ICollection<InvoiceItem> Items { get; set; }
    }
}
