using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;
using System.Data.Entity;

namespace JobCardSystem.Persistence.Repositories
{
    public class StockRepository : Repository<StockItem>, IStockRepository
    {
        public StockRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context;

        public IEnumerable<StockItem> GetStockItemsWithSuppliers()
        {
            return ApplicationDbContext.StockItems
                .Include(i => i.Supplier)
                .ToList();
        }

        public IEnumerable<StockItem> GetStockItemsWithSuppliers(int pageIndex, int pageSize)
        {
            return ApplicationDbContext.StockItems
                .Include(c => c.Supplier)
                .OrderBy(c => c.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<StockItem> GetStockItems(int[] stockItemIds)
        {
            var list = new List<StockItem>();
            foreach (var item in stockItemIds)
            {
                var stockItem = ApplicationDbContext.StockItems.SingleOrDefault(f => f.Id == item);
                list.Add(stockItem);
            }
            return list;
        }

        public IEnumerable<StockItem> GetStockItemsWithSupplierId(int supplierId)
        { 
            return ApplicationDbContext.StockItems.Where(w => w.SupplierId == supplierId).ToList();
        }

        

    }
}