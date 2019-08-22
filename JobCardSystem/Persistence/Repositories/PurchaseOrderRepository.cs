using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;

namespace JobCardSystem.Persistence.Repositories
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        public PurchaseOrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context;

        public IEnumerable<PurchaseOrder> GetPurchaseOrdersWithSupplierDetails()
        {
            return ApplicationDbContext.PurchaseOrders.Include(i => i.Supplier);
        }

        public IEnumerable<PurchaseOrder> GetPurchaseOrderWithStockItems()
        {
            return ApplicationDbContext.PurchaseOrders.Include(i => i.PurchaseOrderItems);
        }


    }
}