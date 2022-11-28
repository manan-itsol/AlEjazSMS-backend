using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Branches
{
    public class BranchDto: EntityDto<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
