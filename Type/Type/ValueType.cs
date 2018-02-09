using System;
using System.Collections.Generic;
using System.Text;

namespace Type
{
    public struct ValueType
    {
        public int Number { get; set; }

        public string Str { get; set; }


        public ReferenceType RefType { get; set; }


        public ValueType(int number, string str)
        {
            Number = number;
            Str = str;

            RefType =  new ReferenceType(1, "wangjin"); ;
        }
    }
}
