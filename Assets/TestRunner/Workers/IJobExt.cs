using TestRunner.Workers.Base;
using Unity.Jobs;

namespace TestRunner.Workers
{
    public interface IJobExt : IJob
    {
    }

    public interface IJobExt<T1> : IJobExt, IJobBase<T1>
        where T1 : struct
    {
    }

    public interface IJobExt<T1, T2> : IJobExt<T1>, IJobBase<T1, T2>
        where T1 : struct
        where T2 : struct
    {
    }

    public interface IJobExt<T1, T2, T3> : IJobExt<T1, T2>, IJobBase<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
    }

    public interface IJobExt<T1, T2, T3, T4> : IJobExt<T1, T2, T3>, IJobBase<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
    }

    public interface IJobExt<T1, T2, T3, T4, T5> : IJobExt<T1, T2, T3, T4>, IJobBase<T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
    }
}