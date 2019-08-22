using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.Domain.Configurations;
using JobCardSystem.Core.IRepositories;

namespace JobCardSystem.Persistence.Repositories
{
    public class PurchaseOrderItemRepository : Repository<PurchaseOrderItem>, IPurchaseOrderItemRepository
    {
        public PurchaseOrderItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context;

        public IEnumerable<PurchaseOrderItem> GetPurchaseOrderItemsEagerStock(int purchaseOrderId)
        {
            return ApplicationDbContext.PurchaseOrderItems.Include(i => i.StockItem).Where(w => w.PurchaseOrderId == purchaseOrderId);
        }
    }
}