using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer.Array
{
    internal interface IArrayContainer<TConfig, T1> : IDataContainer<TConfig>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
    {
        T1[] Item1 { get; }
    }

    internal interface IArrayContainer<TConfig, T1, T2> : IArrayContainer<TConfig, T1>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
    {
        T2[] Item2 { get; }
    }

    internal interface IArrayContainer<TConfig, T1, T2, T3> : IArrayContainer<TConfig, T1, T2>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        T3[] Item3 { get; }
    }

    internal interface IArrayContainer<TConfig, T1, T2, T3, T4> : IArrayContainer<TConfig, T1, T2, T3>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        T4[] Item4 { get; }
    }

    internal interface IArrayContainer<TConfig, T1, T2, T3, T4, T5> : IArrayContainer<TConfig, T1, T2, T3, T4>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        T5[] Item5 { get; }
    }
}