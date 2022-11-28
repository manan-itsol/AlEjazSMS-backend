using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Sections
{
    public class UpdateSectionRequestDto : CreateSectionRequestDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
