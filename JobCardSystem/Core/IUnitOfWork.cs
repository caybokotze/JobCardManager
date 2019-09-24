using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobCardSystem.Core.IRepositories;

namespace JobCardSystem.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IStockRepository StockItems { get; }
        IInvoiceRepository Invoices { get; }
        IJobCardRepository JobCards { get; }
        IJobStatusRepository JobStatuses { get; }
        ISupplierRepository Suppliers { get; }
        IJobTypeRepository JobTypes { get; }
        ICustomerRepository Customers { get; }
        IServiceContract ServiceContracts { get; }
        IMaintenanceContract MaintenanceContracts { get; }
        IAreaRepository Areas { get; }
        IPurchaseOrderRepository PurchaseOrders { get; }
        IPurchaseOrderItemRepository PurchaseOrderItems { get; }
        IApplicationUserSignature ApplicationUserSignatures { get; }
        ICustomerSignatureRepository CustomerSignatures { get; }
        IJobStatusHistoryRepository JobStatusHistory { get; }
        IQuotationRepository Quotes { get; }
        IStockItemQuantityRepository StockItemQuantities { get; }
        //
        int Complete();
    }
}
