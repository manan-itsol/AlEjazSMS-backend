using AlEjazSMS.StudentFees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.FeeTransactions
{
    public class FeeTransaction: AuditedEntity<long>
    {
        public long StudentFeeId { get; set; }
        public virtual StudentFee StudentFee { get; set; }

        public decimal Amount { get; set; }
    }
}
