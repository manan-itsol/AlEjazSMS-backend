using AlEjazSMS.Branches;
using AlEjazSMS.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.Classes
{
    public class Class : AuditedEntity<int>
    {
        public Class()
        {
            ClassSections = new HashSet<ClassSection>();
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }

        public virtual ICollection<ClassSection> ClassSections { get; set; }
    }
}
