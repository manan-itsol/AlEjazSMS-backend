using System;
using System.Collections.Generic;
using System.Text;

namespace AlEjazSMS.Common
{
    public class LookupDto
    {
        /// <summary>
        /// The text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The value
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// AdditionalData, if it's required to send some additional info along with Text & Value
        /// </summary>
        public string AdditionalData { get; set; }
    }
}
