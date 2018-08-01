using System;

namespace TestRunner.Workers.Base
{
    public interface IWorker : IDisposable
    {
        void Init();
    }
}