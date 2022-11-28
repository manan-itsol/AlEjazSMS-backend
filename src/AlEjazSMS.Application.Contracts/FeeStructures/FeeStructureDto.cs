using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.FeeStructures
{
    public class FeeStructureDto: EntityDto<int>
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public List<FeeStructureLineItemDto> LineItems { get; set; }
    }
}
