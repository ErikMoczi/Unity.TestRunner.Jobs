using Unity.Jobs;

namespace TestRunner.Jobs
{
    public interface IJobParallelForExtended : IJobBase, IJobParallelFor
    {
    }

    public interface IJobParallelForExtended<T1> : IJobParallelForExtended, IJobBase<T1>
        where T1 : struct
    {
    }

    public interface IJobParallelForExtended<T1, T2> : IJobParallelForExtended<T1>, IJobBase<T1, T2>
        where T1 : struct
        where T2 : struct
    {
    }

    public interface IJobParallelForExtended<T1, T2, T3> : IJobParallelForExtended<T1, T2>, IJobBase<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
    }

    public interface IJobParallelForExtended<T1, T2, T3, T4> : IJobParallelForExtended<T1, T2, T3>,
        IJobBase<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
    }

    public interface IJobParallelForExtended<T1, T2, T3, T4, T5> : IJobParallelForExtended<T1, T2, T3, T4>,
        IJobBase<T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
    }
}