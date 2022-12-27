using System;
using System.Collections.Generic;
using System.Text;

namespace AlEjazSMS.Students
{
    public class UpdateStudentRequestDto : CreateStudentRequestDto
    {
        public long Id { get; set; }
        public StudentStatus Status { get; set; }
    }

}
