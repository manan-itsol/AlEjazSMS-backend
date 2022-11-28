using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlEjazSMS.Classes
{
    public static class ClassEFCoreEntityExtensions
    {
        public static IQueryable<Class> IncludeDetails(this IQueryable<Class> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.ClassSections);
        }
    }
}
