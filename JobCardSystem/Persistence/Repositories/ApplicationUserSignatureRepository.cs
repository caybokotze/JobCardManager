
using System.Collections.Generic;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.IRepositories;
using System.Data.Entity;
using JobCardSystem.Persistence.Repositories;

namespace JobCardSystem.Persistence.Repositories
{
    public class ApplicationUserSignatureRepository : Repository<ApplicationUserSignature>, IApplicationUserSignature
    {
        public ApplicationUserSignatureRepository(ApplicationDbContext context) : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext => Context;

        public IEnumerable<ApplicationUserSignature> GetSignaturesWithApplicationUsers()
        {
            return ApplicationDbContext.ApplicationUserSignatures.Include(s => s.ApplicationUser);
        }
    }
}