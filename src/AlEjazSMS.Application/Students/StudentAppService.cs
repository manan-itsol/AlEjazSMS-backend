using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AlEjazSMS.Students
{
    public class StudentAppService: ApplicationService, IStudentAppService
    {
        public StudentAppService()
        {
        }

        public string GetStudent()
        {
            return "Owais Saleem";
        }
    }
}
