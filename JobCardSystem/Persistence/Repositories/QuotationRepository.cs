using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;
using System.Data.Entity;

namespace JobCardSystem.Persistence.Repositories
{
    public class QuotationRepository : Repository<Quotation>, IQuotationRepository
    {
        public QuotationRepository(ApplicationDbContext context) : base(context)
        {
        }

        ApplicationDbContext ApplicationDbContext => Context;

        public IEnumerable<Quotation> GetAllApproved()
        {
            return ApplicationDbContext.Quotations.Include(i => i.Customer).Where(w => w.Approve == true);
        }

        public IEnumerable<Quotation> GetAllCustomers()
        {
            return ApplicationDbContext.Quotations.Include(i => i.Customer);
        }
    }
}