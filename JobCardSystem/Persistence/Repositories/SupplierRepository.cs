using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;

namespace JobCardSystem.Persistence.Repositories
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context;

    }
}