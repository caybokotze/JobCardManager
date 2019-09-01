using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Persistence;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using InvoiceService;

namespace JobCardSystem.Controllers.Api
{
    public class StockItemController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public StockItemController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Get(string value = null)
        {
            IQueryable<StockItem> stockItems = _context.StockItems;

            if(!String.IsNullOrWhiteSpace(value))
            {
                stockItems = _context.StockItems.Where(n => n.Name.Contains(value));
            }
            return Ok(stockItems);
        }

        public IHttpActionResult Post([FromBody] StockItem stockItem)
        {
            return null;
        }

        public IEnumerable<StockItem> Search(string value)
        {
            if (!value.IsNullOrWhiteSpace())
            {
                return _context.StockItems.Where(s => s.Name.Contains(value)).ToList();
            }

            else
            {
                return null;
            }
        }
    }

    
}
