using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DayOneWindowsClient.Utilities
{
    [Serializable]
    class UTF8StringWriter : StringWriter
    {
        public UTF8StringWriter()
            : base()
        {
        }

        public UTF8StringWriter(IFormatProvider formatProvider)
            : base(formatProvider)
        {
        }

        public UTF8StringWriter(StringBuilder sb)
            : base(sb)
        {
        }

        public UTF8StringWriter(StringBuilder sb, IFormatProvider formatProvider)
            : base(sb, formatProvider)
        {
        }

        public override Encoding Encoding
        {
            get
            {
                return Encoding.UTF8;
            }
        }
    }
}
