using System;
using System.Threading;

namespace MultithreadedExamples
{
    public class SemaphoreExample: IExecutable
    {
        private static Semaphore _semaphore = new(2, 3);

        public void Execute()
        {
            for (int i = 1; i <= 10; i++)
            {
                var threadObject = new Thread(DoWork)
                {
                    Name = "Thread"
                };
                
                threadObject.Start(i);
            }
        }

        public void DoWork()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " wants to party...");

            try
            {
                _semaphore.WaitOne();
                Console.WriteLine($"Success: {Thread.CurrentThread.Name} is doing its work");
                
                Thread.Sleep(5000);
                Console.WriteLine(Thread.CurrentThread.Name + " exit.");
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}