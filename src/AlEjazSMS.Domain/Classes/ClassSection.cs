using AlEjazSMS.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AlEjazSMS.Classes
{
    public class ClassSection : Entity<int>
    {
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
    }
}
