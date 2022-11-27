using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Classes
{
    public class ClassDto: EntityDto<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public int BranchId { get; set; }

        public List<string> SectionNames { get; set; }
    }
}
