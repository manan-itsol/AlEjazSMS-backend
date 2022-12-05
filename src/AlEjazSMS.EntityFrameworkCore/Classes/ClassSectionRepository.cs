using AlEjazSMS.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AlEjazSMS.Classes
{
    public class ClassSectionRepository : EfCoreRepository<AlEjazSMSDbContext, ClassSection, int>, IClassSectionRepository
    {
        public ClassSectionRepository(IDbContextProvider<AlEjazSMSDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<ClassSection>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails(true);
        }
    }
}
