using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAsync
{
    public class TaskShortcut
    {
        public static void Test()
        {

            Console.WriteLine("Outer task executing.");
            var parent = ThreadShell.Run(() => {
                Console.WriteLine("Nested task starting.");
                Thread.SpinWait(500000);
                Console.WriteLine("Nested task completing.");
            });

            parent.Wait();
            Console.WriteLine("Outer has completed.");

        }
    }
}
