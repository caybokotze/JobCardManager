using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;
using System.Data.Entity;

namespace JobCardSystem.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetCustomersWithContracts(int pageIndex, int pageSize)
        {
            return ApplicationDbContext.Customers
                .Include(c => c.MaintenanceContract)
                .Include(c => c.ContractDuration)
                .Include(c => c.ServiceContract)
                .OrderBy(c => c.CreatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public ApplicationDbContext ApplicationDbContext => Context;
    }
}