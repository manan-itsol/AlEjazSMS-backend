using AlEjazSMS.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AlEjazSMS.Students
{
    public class StudentRepository : EfCoreRepository<AlEjazSMSDbContext, Student, long>, IStudentRepository
    {
        public StudentRepository(IDbContextProvider<AlEjazSMSDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Student>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails(true);
        }
    }
}
