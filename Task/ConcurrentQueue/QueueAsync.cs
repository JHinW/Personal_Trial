using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConcurrentQueue
{
    public class QueueAsync
    {

        public static void test()
        {
            ConcurrentQueue<int> concurrentQueue = new ConcurrentQueue<int>();

            for (int i = 0; i < 5000; i++)
            {
                concurrentQueue.Enqueue(i);
            }



            int itemCount = 0;

            Task[] queueTasks = new Task[20];
            for (int i = 0; i < queueTasks.Length; i++)
            {
                queueTasks[i] = Task.Factory.StartNew(() =>
                {
                    while (concurrentQueue.Count > 0)
                    {
                        int currentElement;
                        bool success = concurrentQueue.TryDequeue(out currentElement);
                        if (success)
                        {
                            Interlocked.Increment(ref itemCount);
                        }
                    }
                });
            }


        }
    }
}
