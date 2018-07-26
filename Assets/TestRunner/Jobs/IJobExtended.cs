using Unity.Jobs;

namespace TestRunner.Jobs
{
    public interface IJobExtended : IJobBase, IJob
    {
    }

    public interface IJobExtended<T1> : IJobExtended, IJobBase<T1>
        where T1 : struct
    {
    }

    public interface IJobExtended<T1, T2> : IJobExtended<T1>, IJobBase<T1, T2>
        where T1 : struct
        where T2 : struct
    {
    }

    public interface IJobExtended<T1, T2, T3> : IJobExtended<T1, T2>, IJobBase<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
    }

    public interface IJobExtended<T1, T2, T3, T4> : IJobExtended<T1, T2, T3>, IJobBase<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
    }

    public interface IJobExtended<T1, T2, T3, T4, T5> : IJobExtended<T1, T2, T3, T4>, IJobBase<T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
    }
}