using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.FeeStructures
{
    public class FeeStructureLineItemDto: EntityDto<int>
    {
        public int FeeStructureId { get; set; }

        [Required, MaxLength(150)]
        public string ShortDescription { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}
