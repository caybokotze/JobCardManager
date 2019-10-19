using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JobCardSystem.BusinessLogic;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.Domain.Configurations;
using JobCardSystem.Persistence;

namespace JobCardSystem.Controllers.Api
{
    public class PurchaseOrderController : ApiController
    {
        private ApplicationDbContext _context;
        //
        public PurchaseOrderController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/PurchaseOrder
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PurchaseOrder/5
        public string Get(int id)
        {
            return "value";
        }


        // POST: api/PurchaseOrder
        public IHttpActionResult Post([FromBody]JsonPurchaseOrderMappingObject objectFromView)
        {
            try
            {
                var purchaseOrderFromView = _context.Customers.SingleOrDefault(s => s.Id == objectFromView.SupplierId);
                //
                var purchaseOrder = new PurchaseOrder();
                var stockItemQuantities = new List<StockItemQuantity>();
                //
                purchaseOrder.SupplierId = objectFromView.SupplierId;
                purchaseOrder.CreatedAt = DateTime.Now;
                //
                var stockItemList = new List<PurchaseOrderItem>();
                //
                _context.PurchaseOrders.Add(purchaseOrder);
                _context.SaveChanges();
                int purchaseOrderId = purchaseOrder.Id;
                //
                foreach (var stockItem in objectFromView.OrderArray)
                {
                    var purchaseOrderItem = new PurchaseOrderItem();
                    purchaseOrderItem.StockItemId = stockItem.Identifier;
                    purchaseOrderItem.AmountOfItems = stockItem.Quantity;
                    purchaseOrderItem.PurchaseOrderId = purchaseOrderId;
                    //
                    _context.PurchaseOrderItems.Add(purchaseOrderItem);
                    _context.SaveChanges();
                }
                //
                //Mailer.SendApprovalRequest(purchaseOrderId, "Hello there.");
                return Ok("Hi there johnny.");
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/PurchaseOrder/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PurchaseOrder/5
        public void Delete(int id)
        {
        }
    }

    public class JsonPurchaseOrderMappingObject
    {
        public int SupplierId { get; set; }
        //
        public int[] StockItemArray { get; set; }
        public ICollection<StockArrayObject> OrderArray { get; set; }
        //public ICollection<InvoiceItem> Items { get; set; }
    }

}
