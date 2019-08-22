﻿
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;

namespace JobCardSystem.Persistence.Repositories
{
    public class JobCardRepository : Repository<JobCard>, IJobCardRepository
    {
        public JobCardRepository(ApplicationDbContext context) : base(context)
        {
        }
        public ApplicationDbContext ApplicationDbContext => Context;


        public JobCard GetJobCardWithCustomer(int jobCardId)
        {
            return ApplicationDbContext.JobCards.Include(i => i.Customer).SingleOrDefault(s => s.Id == jobCardId);
        }

        public IEnumerable<JobCard> GetJobCardsWithJobStatus(int pageIndex, int pageSize)
        {
            return ApplicationDbContext.JobCards
                .Include(c => c.JobStatus)
                .OrderBy(c => c.CreatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        public IEnumerable<JobCard> GetJobCardWithAllTypes(int pageIndex, int pageSize)
        {
            return ApplicationDbContext.JobCards
                .Include(c => c.JobStatus)
                .Include(c => c.JobType)
                .Include(c => c.Customer)
                .Include(c => c.ApplicationUsers)
                .OrderBy(c => c.CreatedAt)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public IEnumerable<JobCard> GetJobCardWithUser(int pageIndex, int pageSize)
        {
            return ApplicationDbContext.JobCards.Include(u => u.ApplicationUsers).ToList();
        }

        public IEnumerable<JobCard> GetJobCardForUser(string id)
        {
            var all = ApplicationDbContext.JobCards
                .Include(c => c.JobStatus)
                .Include(c => c.JobType)
                .Include(c => c.Customer)
                .Include(c => c.ApplicationUsers)
                .OrderBy(c => c.CreatedAt)
                .ToList();

            var forUser = new List<JobCard>();
            foreach (var item in all)
            {
                foreach (var user in item.ApplicationUsers)
                {
                    if (user.Id == id)
                    {
                        forUser.Add(item);
                    }
                }
            }

            return forUser;
        }

    }
}