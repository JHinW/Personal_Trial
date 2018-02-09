using Serilizer;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            FunctionSerilize.FunctionSerilize_main(args);
        }

        public static void testStringSerilizer()
        {
            var testStr = "ssssssss";
            var json = Serilizer.WriteFromObject(testStr);
            var outs = (string)Serilizer.ReadToObject(json, typeof(string));

            Console.WriteLine(outs);
        }


        public static void TaskCompletionSource_test()
        {
            TaskCompletionSource<int> tcs1 = new TaskCompletionSource<int>();

            var json = Serilizer.WriteFromObject(tcs1);
            var tcs2 = (TaskCompletionSource<int>)Serilizer.ReadToObject(json, typeof(TaskCompletionSource<int>));
            Task<int> t1 = tcs2.Task;

            // Start a background task that will complete tcs1.Task
            Task.Factory.StartNew(() =>
            {

                // var tcs2 = (TaskCompletionSource<int>)Serilizer.ReadToObject(json, typeof(TaskCompletionSource<int>));
                Thread.Sleep(1000);
                tcs2.SetResult(15);
            });

            // The attempt to get the result of t1 blocks the current thread until the completion source gets signaled.
            // It should be a wait of ~1000 ms.
            Stopwatch sw = Stopwatch.StartNew();
            int result = t1.Result;
            sw.Stop();

            Console.WriteLine("(ElapsedTime={0}): t1.Result={1} (expected 15) ", sw.ElapsedMilliseconds, result);
        }
    }
}
