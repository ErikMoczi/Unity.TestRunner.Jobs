using Unity.Jobs;

namespace TestRunner.Workers
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
}