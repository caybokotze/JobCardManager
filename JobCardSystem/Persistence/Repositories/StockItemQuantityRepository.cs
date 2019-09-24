using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;
using System.Data.Entity;

namespace JobCardSystem.Persistence.Repositories
{
    public class StockItemQuantityRepository : Repository<StockItemQuantity>, IStockItemQuantityRepository
    {
        public StockItemQuantityRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext ApplicationDbContext => Context;

        public IEnumerable<StockItemQuantity> GetStockItemsForQuote(int id)
        {
            return ApplicationDbContext.StockItemQuantities.Include(w => w.StockItem).Where(w => w.QuotationId == id);
        }

    }
}