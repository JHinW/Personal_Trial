using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAsync
{
    public static class TaskContinue
    {
        public static void testc()
        {
            Task.Delay(12000)
                .ContinueWith(r =>
           {
               var subTask = Task.Run(() => Thread.Sleep(2000));
               return subTask;
           }).Wait();

        }
    }
}
