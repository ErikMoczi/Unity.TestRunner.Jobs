using System;
using TestWrapper.Workers;

namespace TestWrapper.Container.WorkRunner.Base
{
    internal interface IWorkRunnerContainer<TWorker> : IBaseContainer
        where TWorker : struct, IWorker
    {
        void Run(ref TWorker work);
        Type WorkerType();
    }
}