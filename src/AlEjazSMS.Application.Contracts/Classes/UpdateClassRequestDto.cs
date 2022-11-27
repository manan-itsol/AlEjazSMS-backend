using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Classes
{
    public class UpdateClassRequestDto : CreateClassRequestDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
