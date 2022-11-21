using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.FeeStructures
{
    public class FeeStructureLineItem : AuditedEntity<int>
    {
        protected FeeStructureLineItem()
        {
        }

        public FeeStructureLineItem(int feeStructureId, string shortDescription, decimal amount)
        {
            FeeStructureId = feeStructureId;
            ShortDescription = shortDescription;
            Amount = amount;
        }

        public int FeeStructureId { get; set; }
        public virtual FeeStructure FeeStructure { get; set; }

        public string ShortDescription { get; set; }

        public decimal Amount { get; set; }
    }
}
