using System;
using System.Threading;

namespace MultithreadedExamples
{
    public interface IExecutable
    {
        void Execute();
        void DoWork();
    }
}