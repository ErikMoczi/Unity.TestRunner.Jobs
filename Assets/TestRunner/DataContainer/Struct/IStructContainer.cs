using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace TestRunner.DataContainer.Struct
{
    internal interface IStructContainer<TConfig, T1> : IDataContainer<TConfig>
        where TConfig : IWorkConfig
        where T1 : struct
    {
        NativeArray<T1> Item1 { get; }
    }

    internal interface IStructContainer<TConfig, T1, T2> : IStructContainer<TConfig, T1>
        where TConfig : IWorkConfig
        where T1 : struct
        where T2 : struct
    {
        NativeArray<T2> Item2 { get; }
    }

    internal interface IStructContainer<TConfig, T1, T2, T3> : IStructContainer<TConfig, T1, T2>
        where TConfig : IWorkConfig
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        NativeArray<T3> Item3 { get; }
    }

    internal interface IStructContainer<TConfig, T1, T2, T3, T4> : IStructContainer<TConfig, T1, T2, T3>
        where TConfig : IWorkConfig
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        NativeArray<T4> Item4 { get; }
    }

    internal interface IStructContainer<TConfig, T1, T2, T3, T4, T5> : IStructContainer<TConfig, T1, T2, T3, T4>
        where TConfig : IWorkConfig
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        NativeArray<T5> Item5 { get; }
    }
}