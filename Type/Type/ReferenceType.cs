using System;
using System.Collections.Generic;
using System.Text;

namespace Type
{
    public class ReferenceType
    {
        public int Number { get; set; }

        public string Str { get; set; }

        public ReferenceType(int number, string str)
        {
            Number = number;
            Str = str;
        }
    }
}
