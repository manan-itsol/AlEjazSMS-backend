using AlEjazSMS.Students;
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
        public string Code { get; set; }

        public string Name { get; set; }

        public string Section { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
