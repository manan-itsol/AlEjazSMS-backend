using AlEjazSMS.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlEjazSMS.Students
{
    public static class ClassEFCoreStudentExtensions
    {
        public static IQueryable<Student> IncludeDetails(this IQueryable<Student> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.ClassSection)
                    .ThenInclude(x => x.Class)
                .Include(x => x.ClassSection)
                    .ThenInclude(x => x.Section);
        }
    }
}
