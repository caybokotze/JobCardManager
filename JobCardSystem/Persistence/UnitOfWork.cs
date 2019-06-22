using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core;
using JobCardSystem.Core.IRepositories;
using JobCardSystem.Persistence.Repositories;

namespace JobCardSystem.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext cntx)
        {
            _context = cntx;
            StockItems = new StockRepository(_context);
            Invoices = new InvoiceRespository(_context);
            JobCards = new JobCardRepository(_context);
            JobStatuses = new JobStatusRepository(_context);
            Suppliers = new SupplierRepository(_context);
            JobTypes = new JobTypeRepository(_context);

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

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}