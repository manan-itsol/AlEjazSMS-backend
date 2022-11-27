using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlEjazSMS.Classes
{
    public class CreateClassRequestDto
    {
        [Required, MaxLength(3)]
        public string Code { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int BranchId { get; set; }
    }
}
