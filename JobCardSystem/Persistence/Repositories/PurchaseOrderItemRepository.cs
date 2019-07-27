using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}