using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlEjazSMS.Sections
{
    public class CreateSectionRequestDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
