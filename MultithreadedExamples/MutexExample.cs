using System;
using System.Threading;

namespace MultithreadedExamples
{
    public class MutexExample : IExecutable
    {
        private static Mutex _mutex = new();
        
        public void Execute()
        {
            for (int i = 1; i <= 5; i++)
            {
                var threadObject = new Thread(DoWork)
                {
                    Name = "Thread " + i
                };
                
                threadObject.Start();
            }

            Console.ReadKey();
        }

        public void DoWork()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} wants to party...");

            try
            {
                _mutex.WaitOne();
                Console.WriteLine($"Success: {Thread.CurrentThread.Name} is processing now");
                Thread.Sleep(2000);
                Console.WriteLine($"Exit: {Thread.CurrentThread.Name} has completed its task");
            }
            finally
            {
                _mutex.ReleaseMutex();
            }
        }
    }
}