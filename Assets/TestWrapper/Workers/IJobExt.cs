using Unity.Jobs;

namespace TestWrapper.Workers
{
    public interface IJobExt : IJob
    {
    }

    public interface IJobExt<T1> : IJobExt, IWorker<T1>
    {
    }

    public interface IJobExt<T1, T2> : IJobExt<T1>, IWorker<T1, T2>
    {
    }

    public interface IJobExt<T1, T2, T3> : IJobExt<T1, T2>, IWorker<T1, T2, T3>
    {
    }

    public interface IJobExt<T1, T2, T3, T4> : IJobExt<T1, T2, T3>, IWorker<T1, T2, T3, T4>
    {
    }

    public interface IJobExt<T1, T2, T3, T4, T5> : IJobExt<T1, T2, T3, T4>, IWorker<T1, T2, T3, T4, T5>
    {
    }

    public interface IJobExt<T1, T2, T3, T4, T5, T6> : IJobExt<T1, T2, T3, T4, T5>, IWorker<T1, T2, T3, T4, T5, T6>
    {
    }

    public interface IJobExt<T1, T2, T3, T4, T5, T6, T7> : IJobExt<T1, T2, T3, T4, T5, T6>,
        IWorker<T1, T2, T3, T4, T5, T6, T7>
    {
    }

    public interface IJobExt<T1, T2, T3, T4, T5, T6, T7, T8> : IJobExt<T1, T2, T3, T4, T5, T6, T7>,
        IWorker<T1, T2, T3, T4, T5, T6, T7, T8>
    {
    }

    public interface IJobExt<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IJobExt<T1, T2, T3, T4, T5, T6, T7, T8>,
        IWorker<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
    }
}