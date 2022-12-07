using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AlEjazSMS.Students
{
    public interface IStudentRepository: IRepository<Student, long>
    {
    }
}
