using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AlEjazSMS.Students
{
    public class StudentDto : EntityDto<long>
    {
        public long RollNo { get; set; }

        public string Name { get; set; }

        public string CNIC { get; set; }

        public string PhoneNumber { get; set; }

        public string FatherName { get; set; }

        public string FatherCNIC { get; set; }

        public string PresentAddress { get; set; }

        public DateTime AdmissionDate { get; set; }

        public int SectionId { get; set; }

        public int? FeeStructureId { get; set; }

        public StudentStatus Status { get; set; }
    }
}
