using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Branches
{
    public class UpdateBranchRequestDto: CreateBranchRequestDto, IEntityDto<int>
    {
        public int Id { get; set; }
    }
}
