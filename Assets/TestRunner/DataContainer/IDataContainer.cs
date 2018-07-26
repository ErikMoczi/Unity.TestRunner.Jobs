using System;
using Unity.Collections;

namespace TestRunner.DataContainer
{
    internal interface IDataContainer : IDisposable
    {
        void Init(Allocator allocator);
    }

    internal interface IDataContainer<T1> : IDataContainer
        where T1 : struct
    {
        int DataSize { get; }
        NativeArray<T1> Item1 { get; }
    }

    internal interface IDataContainer<T1, T2> : IDataContainer<T1>
        where T1 : struct
        where T2 : struct
    {
        NativeArray<T2> Item2 { get; }
    }

    internal interface IDataContainer<T1, T2, T3> : IDataContainer<T1, T2>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        NativeArray<T3> Item3 { get; }
    }

    internal interface IDataContainer<T1, T2, T3, T4> : IDataContainer<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        NativeArray<T4> Item4 { get; }
    }

    internal interface IDataContainer<T1, T2, T3, T4, T5> : IDataContainer<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        NativeArray<T5> Item5 { get; }
    }
}