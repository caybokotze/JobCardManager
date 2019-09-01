using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvoiceService;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers.Api
{
    public class QuotationController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public QuotationController()
        {
            _context = new ApplicationDbContext();
        }
        //
        public IHttpActionResult Get(int? id)
        {
            return Ok(_context.Quotations.ToList());
        }

        public IHttpActionResult Post([FromBody]JsonQuoteMappingObject quotationMap)
        {
            var person = _context.Customers.SingleOrDefault(s => s.Id == quotationMap.CustomerId);

            var quote = new Quotation();

            quote.Customers.Add(person);
            quote.CreatedAt = DateTime.Now;
            quote.Description = quotationMap.Notes;

            var stockItemList = new List<StockItem>();

            foreach (var stockItem in quotationMap.InvoiceItems)
            {
                stockItemList.Add(_context.StockItems.SingleOrDefault(s => s.Id == stockItem.Id));
            }

            quote.StockItems = stockItemList;

            _context.Quotations.Add(quote);
            _context.SaveChanges();
            return Ok();
        }
    }

    public class JsonQuoteMappingObject
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double Discount { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
