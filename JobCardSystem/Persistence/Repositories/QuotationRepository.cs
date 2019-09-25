using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;

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
            return ApplicationDbContext.Quotations.Where(w => w.Approve == true);
        }
    }
}