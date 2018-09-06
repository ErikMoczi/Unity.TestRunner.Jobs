using TestRunner.Container.SetUp;

namespace TestRunner.Workers.Wrappers
{
    internal interface IWorkerWrapper : IContainerInfoWorker
    {
        void Run();
    }

    internal interface IWorkerWrapper<T1> : IWorker<T1>, IWorkerWrapper
    {
    }

    internal interface IWorkerWrapper<T1, T2> : IWorker<T1, T2>, IWorkerWrapper<T1>
    {
    }

    internal interface IWorkerWrapper<T1, T2, T3> : IWorker<T1, T2, T3>, IWorkerWrapper<T1, T2>
    {
    }

    internal interface IWorkerWrapper<T1, T2, T3, T4> : IWorker<T1, T2, T3, T4>, IWorkerWrapper<T1, T2, T3>
    {
    }

    internal interface IWorkerWrapper<T1, T2, T3, T4, T5> : IWorker<T1, T2, T3, T4, T5>, IWorkerWrapper<T1, T2, T3, T4>
    {
    }
}