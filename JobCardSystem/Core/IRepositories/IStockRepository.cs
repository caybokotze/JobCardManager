using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.IRepositories
{
    public interface IStockRepository : IRepository<StockItem>
    {
        IEnumerable<StockItem> GetStockItemsWithSuppliers();

        IEnumerable<StockItem> GetStockItemsWithSuppliers(int pageNumber, int pageSize);

        IEnumerable<StockItem> GetStockItems(int[] stockItemIds);

        IEnumerable<StockItem> GetStockItemsWithSupplierId(int supplierId);

    }
}
