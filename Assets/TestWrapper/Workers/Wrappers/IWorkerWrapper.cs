using TestWrapper.Container;
using TestWrapper.Container.Info.Methods;
using TestWrapper.Utils.Interfaces;

namespace TestWrapper.Workers.Wrappers
{
    internal interface IWorkerWrapper : IBaseContainer, IInfoWorker, IRun, IWorker
    {
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

    internal interface IWorkerWrapper<T1, T2, T3, T4, T5, T6> : IWorker<T1, T2, T3, T4, T5, T6>,
        IWorkerWrapper<T1, T2, T3, T4, T5>
    {
    }

    internal interface IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7> : IWorker<T1, T2, T3, T4, T5, T6, T7>,
        IWorkerWrapper<T1, T2, T3, T4, T5, T6>
    {
    }

    internal interface IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7, T8> : IWorker<T1, T2, T3, T4, T5, T6, T7, T8>,
        IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7>
    {
    }

    internal interface IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IWorker<T1, T2, T3, T4, T5, T6, T7, T8, T9>,
        IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7, T8>
    {
    }
}