using AlEjazSMS.Classes;
using AlEjazSMS.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.Sections
{
    public class Section: AuditedEntity<int>
    {
        public string Name { get; set; }
        
        public virtual ICollection<ClassSection> ClassSections { get; set; }
    }
}
