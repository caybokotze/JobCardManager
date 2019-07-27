using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.IRepositories
{
    public interface IPurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        IEnumerable<PurchaseOrder> GetPurchaseOrdersWithSupplierDetails();
    }
}
