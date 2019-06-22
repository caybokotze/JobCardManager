using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;

namespace JobCardSystem.Persistence.Repositories
{
    public class JobTypeRepository : Repository<JobType>, IJobTypeRepository
    {
        public JobTypeRepository(ApplicationDbContext context) : base(context)
        {
            
        }

        private ApplicationDbContext applicationDbContext => Context;
    }
}