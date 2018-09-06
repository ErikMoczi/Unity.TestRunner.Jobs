using System;
using TestRunner.Workers;

namespace TestRunner.Container.WorkRunner.Base
{
    internal interface IWorkRunnerContainer<TWorker> : IBaseContainer
        where TWorker : struct, IWorker
    {
        void Run(ref TWorker work);
        Type WorkerType();
    }
}