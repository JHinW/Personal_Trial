using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadAsync
{
    public class ThreadShell
    {
        public static Task Run(Func<Task> action)
        {
            return Task.Run(()=> {
                Task.Factory.StartNew(action);
                return Task.CompletedTask;
            });
        }

        public static Task Run(Action action)
        {
            return Task.Run(() => {
                Task.Factory.StartNew(action);
            });
        }

        public static Task LongRun(Func<Task> action)
        {
            return Task.Run(() => {
                Task.Factory.StartNew(action, 
                    CancellationToken.None, 
                    TaskCreationOptions.LongRunning, 
                    TaskScheduler.Default);

                return Task.CompletedTask;
            });
        }

        public static Task LongRun(Action action)
        {
            return Task.Run(() => {
                Task.Factory.StartNew(action,
                    CancellationToken.None,
                    TaskCreationOptions.LongRunning,
                    TaskScheduler.Default);
            });
        }

    }
}
