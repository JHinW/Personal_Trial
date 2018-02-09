using System;
using System.Collections.Generic;
using System.Text;

namespace Type
{
    public static class TypeTest
    {
        public static void Test(ReferenceType refType, ValueType valType)
        {
            refType.Number += 1;
            refType.Str += " is your name.";

            valType.Number += 1;
            valType.Str += " is your name.";

            valType.RefType.Number += 1;
            valType.RefType.Str += " is your name.";

        }
    }
}
