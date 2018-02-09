using RuntimeProxy.Interfaces;
using System;

namespace RuntimeProxy
{
    // https://msdn.microsoft.com/en-us/library/system.runtime.remoting.proxies.realproxy(v=vs.110).aspx

    // https://dzone.com/articles/aspect-oriented-programming-in-c-with-realproxy 

    internal static class Program
    {
        static void Main(string[] args)
        {
            var op = new InterfacesOpera();
            var ret = op.GetInterfaces(typeof(IService), typeof(IService));

            foreach(var k in ret)
            {
                Console.WriteLine(k);
            }

            Console.WriteLine("Hello World!");
        }


    }
}
