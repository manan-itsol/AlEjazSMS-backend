using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Sections
{
    public class SectionDto: EntityDto<int>
    {
        public string Name { get; set; }

        public int ClassId { get; set; }
    }
}
