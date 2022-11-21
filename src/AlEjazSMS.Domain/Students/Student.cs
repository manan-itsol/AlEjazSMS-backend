using AlEjazSMS.Classes;
using AlEjazSMS.FeeStructures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AlEjazSMS.Students
{
    public class Student: AuditedEntity<long>
    {
        //Personal Info
        public long RollNo { get; set; }

        public string Name { get; set; }

        public string CNIC { get; set; }

        public string PhoneNumber { get; set; }

        public string FatherName { get; set; }

        public string FatherCNIC { get; set; }

        public string PresentAddress { get; set; }

        public DateTime AdmissionDate { get; set; }

        // Class
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }

        //Fee
        public int? FeeStructureId { get; set; }
        public virtual FeeStructure FeeStructure { get; set; }


        public StudentStatus Status { get; set; }
    }
}
