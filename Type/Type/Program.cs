using System;
using System.Threading;

namespace Type
{
    class Program
    {
        static void Main(string[] args)
        {
            var refType = new ReferenceType(1, "wangjin");

            var valType = new ValueType(1, "wangjin");

            TypeTest.Test(refType, valType);




            Console.WriteLine($"refType => { refType.Number }  , { refType.Str } ");

            Console.WriteLine($"valType => { valType.Number }  , { valType.Str } ");

            Console.WriteLine($"---------------> refType => { valType.RefType.Number }  , { valType.RefType.Str } ");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
