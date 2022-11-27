using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Common
{
    public class GetAllRequestDto : PagedAndSortedResultRequestDto
    {
        public string SearchKey { get; set; }
    }
}
