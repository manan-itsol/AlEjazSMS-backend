using AlEjazSMS.FeeStructures;
using AlEjazSMS.FeeTransactions;
using AlEjazSMS.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.StudentFees
{
    public class StudentFee: AuditedEntity<long>
    {
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int FeeStructureId { get; set; }
        public virtual FeeStructure FeeStructure { get; set; }

        public decimal Amount { get; set; }
        
        public DateTime Date { get; set; }
        
        public DateTime DueDate { get; set; }

        public virtual ICollection<FeeTransaction> FeeTransactions { get; set; }
    }
}
