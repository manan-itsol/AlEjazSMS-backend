using AlEjazSMS.FeeStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AlEjazSMS.Students
{
    public class StudentFeeStructure: Entity<int>
    {
        public long StudentId { get; set; }
        public virtual Student Student { get; set; }
        
        public int FeeStructureId { get; set; }
        public virtual FeeStructure FeeStructure { get; set; }
    }
}
