using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace AlEjazSMS.Students
{
    public interface IStudentAppService: IApplicationService
    {
        string GetStudent();
    }
}
