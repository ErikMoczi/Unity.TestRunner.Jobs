using System;
using Unity.Collections;

namespace TestRunner.Jobs
{
    public interface IJobBase : IDisposable
    {
        void Init();
    }

    public interface IJobBase<T1> : IJobBase
        where T1 : struct
    {
        int DataSize { get; set; }
        NativeArray<T1> Data1 { get; set; }
    }

    public interface IJobBase<T1, T2> : IJobBase<T1>
        where T1 : struct
        where T2 : struct
    {
        NativeArray<T2> Data2 { get; set; }
    }

    public interface IJobBase<T1, T2, T3> : IJobBase<T1, T2>
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        NativeArray<T3> Data3 { get; set; }
    }

    public interface IJobBase<T1, T2, T3, T4> : IJobBase<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        NativeArray<T4> Data4 { get; set; }
    }

    public interface IJobBase<T1, T2, T3, T4, T5> : IJobBase<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        NativeArray<T5> Data5 { get; set; }
    }
}