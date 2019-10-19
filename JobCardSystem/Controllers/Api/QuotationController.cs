using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using InvoiceService;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;
using System.Data.Entity;
using JobCardSystem.BusinessLogic;

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
        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (id.HasValue)
            {
                var returnList = _context.StockItemQuantities
                    .Where(w => w.QuotationId == id)
                    .Include(s => s.Quotation)
                    .Include(s => s.StockItem).ToList();
                    return Ok(returnList);
            }

            throw new HttpResponseException(HttpStatusCode.BadRequest);
            //
        }

        public IHttpActionResult Post([FromBody]JsonQuoteMappingObject quotationMap)
        {
            try
            {
                //var person = _context.Customers.SingleOrDefault(s => s.Id == quotationMap.CustomerId);
                //
                var quote = new Quotation();
                var stockItemQuantities = new List<StockItemQuantity>();
                //
                quote.CustomerId = quotationMap.CustomerId;
                quote.CreatedAt = DateTime.Now;
                //
                //var stockItemList = new List<StockItem>();
                //
                _context.Quotations.Add(quote);
                _context.SaveChanges();
                int quoteId = quote.Id;
                //
                double total = 0;

                foreach (var stockItem in quotationMap.OrderArray)
                {
                    var stockItemQuantity = new StockItemQuantity();
                    stockItemQuantity.StockItemId = stockItem.Identifier;
                    stockItemQuantity.Quantity = stockItem.Quantity;
                    stockItemQuantity.QuotationId = quoteId;
                    //
                    total += stockItem.Amount;
                    //
                    _context.StockItemQuantities.Add(stockItemQuantity);
                    _context.SaveChanges();
                }

                quote.Total = total;
                _context.Entry(quote).State = EntityState.Modified;
                _context.SaveChanges();
                //
                Mailer.SendApprovalRequest(quote.Id);
                return Ok();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
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
        //
        public int[] StockItemArray { get; set; }
        public ICollection<StockArrayObject> OrderArray { get; set; }
        //public ICollection<InvoiceItem> Items { get; set; }
    }

    public class StockArrayObject
    {
        public int Identifier { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}

