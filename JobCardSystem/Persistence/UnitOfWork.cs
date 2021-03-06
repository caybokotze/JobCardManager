﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;
using JobCardSystem.Persistence.Repositories;

namespace JobCardSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            StockItems = new StockRepository(_context);
            Invoices = new InvoiceRepository(_context);
            JobCards = new JobCardRepository(_context);
            JobStatuses = new JobStatusRepository(_context);
            Suppliers = new SupplierRepository(_context);
            JobTypes = new JobTypeRepository(_context);
            Customers = new CustomerRepository(_context);
            ServiceContracts = new ServiceContractRepository(_context);
            MaintenanceContracts = new MaintenanceContractRepository(_context);
            Areas = new AreaRepository(_context);
            PurchaseOrders = new PurchaseOrderRepository(_context);
            PurchaseOrderItems = new PurchaseOrderItemRepository(_context);
            ApplicationUserSignatures = new ApplicationUserSignatureRepository(_context);
            CustomerSignatures = new CustomerSignatureRepository(_context);
            JobStatusHistory = new JobStatusHistoryRepository(_context);
            Quotes = new QuotationRepository(_context);
            StockItemQuantities = new StockItemQuantityRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IStockRepository StockItems { get; }
        public IInvoiceRepository Invoices { get; }
        public IJobCardRepository JobCards { get; }
        public IJobStatusRepository JobStatuses { get; }
        public ISupplierRepository Suppliers { get; }
        public IJobTypeRepository JobTypes { get; }
        public ICustomerRepository Customers { get; }
        public IServiceContract ServiceContracts { get; }
        public IMaintenanceContract MaintenanceContracts { get; }
        public IAreaRepository Areas { get; }
        public IPurchaseOrderRepository PurchaseOrders { get; }
        public IPurchaseOrderItemRepository PurchaseOrderItems { get; }
        public IApplicationUserSignature ApplicationUserSignatures { get; }
        public ICustomerSignatureRepository CustomerSignatures { get; }
        public IJobStatusHistoryRepository JobStatusHistory { get; }
        public IQuotationRepository Quotes { get; }
        public IStockItemQuantityRepository StockItemQuantities { get; }


        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}