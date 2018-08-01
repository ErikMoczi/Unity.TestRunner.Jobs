using TestRunner.Workers.Base;
using Unity.Jobs;

namespace TestRunner.Workers
{
    public interface IJobParallelForExt : IJobParallelFor
    {
    }

    public interface IJobParallelForExt<T1> : IJobParallelForExt, IJobBase<T1>
        where T1 : struct
    {
    }

    public interface IJobParallelForExt<T1, T2> : IJobParallelForExt<T1>, IJobBase<T1, T2>
        where T1 : struct
        where T2 : struct
    {
    }

    public interface IJobParallelForExt<T1, T2, T3> : IJobParallelForExt<T1, T2>, IJobBase<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4> : IJobParallelForExt<T1, T2, T3>,
        IJobBase<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
    }

    public interface IJobParallelForExt<T1, T2, T3, T4, T5> : IJobParallelForExt<T1, T2, T3, T4>,
        IJobBase<T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
    }
}