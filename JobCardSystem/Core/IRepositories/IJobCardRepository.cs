using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobCardSystem.Core.Domain;

namespace JobCardSystem.Core.IRepositories
{
    public interface IJobCardRepository : IRepository<JobCard>
    {
        IEnumerable<JobCard> GetJobCardsWithJobStatus(int pageIndex, int pageSize);

        IEnumerable<JobCard> GetJobCardWithAllTypes(int pageIndex, int pageSize);

        IEnumerable<JobCard> GetJobCardForUser(string id);

        IEnumerable<JobCard> GetJobCardWithUser(int pageIndex, int pageSize);

        JobCard GetJobCardWithCustomer(int jobCardId);

    }
}
