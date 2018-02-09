using System;
using System.Threading;

namespace ThreadAsync
{
    class Program
    {
        static void Main(string[] args)
        {

            // TaskShortcut.Test();

            TaskContinue.testc();

            Thread.Sleep(Timeout.Infinite);
            Console.WriteLine("Hello World!");
        }
    }
}
