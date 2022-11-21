using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.FeeStructures
{
    public class FeeStructure : AuditedAggregateRoot<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public List<FeeStructureLineItem> LineItems { get; set; }

        public void AddLineItem(string shortDescription, decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "You can not add a fee structure item with zero amount!",
                    nameof(amount)
                );
            }

            var existingLine = LineItems.FirstOrDefault(ol => ol.ShortDescription == shortDescription);
            if (existingLine == null)
            {
                LineItems.Add(new FeeStructureLineItem(this.Id, shortDescription, amount));
            }
            else
            {
                existingLine.Amount = amount;
            }
        }
    }
}
