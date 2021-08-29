using System;
using System.Threading;

namespace MultithreadedExamples
{
    public class InterlockExample : IExecutable
    {
        private static int usingResource = 0;
        public void Execute()
        {
            for (var i = 0; i < 10; i++)
            {
                var thread = new Thread(DoWork)
                {
                    Name = $"Thread{ i + 1 }"
                };
                
                thread.Start();
            }
        }

        public void DoWork()
        {
            if (Interlocked.Exchange(ref usingResource, 1) == 0)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired the lock");
                Thread.Sleep(500);
                
                Console.WriteLine($"{Thread.CurrentThread.Name} exiting the lock");
                Interlocked.Exchange(ref usingResource, 0);
                return;
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} was denied the lock.");
        }
    }
}