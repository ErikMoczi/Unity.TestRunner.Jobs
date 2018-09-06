using Unity.Jobs;

namespace TestRunner.Workers
{
    public interface IJobParallelForExt : IJobParallelFor
    {
    }

    public interface IJobParallelForExt<T1> : IJobParallelForExt, IWorker<T1>
    {
    }

    public interface IJobParallelForExt<T1, T2> : IJobParallelForExt<T1>, IWorker<T1, T2>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3> : IJobParallelForExt<T1, T2>, IWorker<T1, T2, T3>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4> : IJobParallelForExt<T1, T2, T3>, IWorker<T1, T2, T3, T4>
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4, T5> : IJobParallelForExt<T1, T2, T3, T4>,
        IWorker<T1, T2, T3, T4, T5>
    {
    }
}