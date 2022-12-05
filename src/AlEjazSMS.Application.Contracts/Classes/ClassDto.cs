using AlEjazSMS.Common;
using AlEjazSMS.Sections;
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

        public string BranchName { get; set; }

        public List<SectionDto> Sections { get; set; }
    }
}
