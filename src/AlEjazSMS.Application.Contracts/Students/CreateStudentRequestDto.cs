using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlEjazSMS.Students
{
    public class CreateStudentRequestDto
    {
        public long RollNo { get; set; }

        [Required, MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string CNIC { get; set; }

        [Phone, MaxLength(13)]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string FatherName { get; set; }

        [MaxLength(20)]
        public string FatherCNIC { get; set; }

        [MaxLength(500)]
        public string PresentAddress { get; set; }

        public DateTime AdmissionDate { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public int SectionId { get; set; }

        public int? FeeStructureId { get; set; }
    }
}
