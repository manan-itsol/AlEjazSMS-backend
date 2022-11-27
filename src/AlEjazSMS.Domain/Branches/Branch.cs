using AlEjazSMS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.Branches
{
    public class Branch : AuditedEntity<int>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
}
