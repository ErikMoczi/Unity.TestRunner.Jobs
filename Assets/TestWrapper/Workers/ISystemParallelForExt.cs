namespace TestWrapper.Workers
{
    public interface ISystemParallelForExt
    {
        void Execute(int index);
    }

    public interface ISystemParallelForExt<T1> : ISystemParallelForExt, IWorker<T1>
    {
    }

    public interface ISystemParallelForExt<T1, T2> : ISystemParallelForExt<T1>, IWorker<T1, T2>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3> : ISystemParallelForExt<T1, T2>, IWorker<T1, T2, T3>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4> : ISystemParallelForExt<T1, T2, T3>, IWorker<T1, T2, T3, T4>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4, T5> : ISystemParallelForExt<T1, T2, T3, T4>,
        IWorker<T1, T2, T3, T4, T5>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4, T5, T6> : ISystemParallelForExt<T1, T2, T3, T4, T5>,
        IWorker<T1, T2, T3, T4, T5, T6>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4, T5, T6, T7> : ISystemParallelForExt<T1, T2, T3, T4, T5, T6>,
        IWorker<T1, T2, T3, T4, T5, T6, T7>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4, T5, T6, T7, T8> :
        ISystemParallelForExt<T1, T2, T3, T4, T5, T6, T7>, IWorker<T1, T2, T3, T4, T5, T6, T7, T8>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        ISystemParallelForExt<T1, T2, T3, T4, T5, T6, T7, T8>, IWorker<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
    }
}