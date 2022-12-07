using AlEjazSMS.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlEjazSMS.Students
{
    public class StudentGetAllRequestDto: GetAllRequestDto
    {
        public List<int> BranchIds { get; set; }
        public List<int> ClassIds { get; set; }
        public List<int> SectionIds { get; set; }
    }
}
