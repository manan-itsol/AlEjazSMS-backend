using System;
using System.Collections.Generic;
using System.Text;

namespace AlEjazSMS.Common
{
    public class GenericResponseDto<T>: BaseResponseDto
    {
        public T Data { get; set; }
    }
}
