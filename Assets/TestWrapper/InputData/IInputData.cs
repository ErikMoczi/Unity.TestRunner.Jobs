using System;

namespace TestWrapper.InputData
{
    internal interface IInputData
    {
    }

    internal interface IInputData<T1> : IInputData
    {
        Array ItemArray1 { get; }
    }

    internal interface IInputData<T1, T2> : IInputData<T1>
    {
        Array ItemArray2 { get; }
    }

    internal interface IInputData<T1, T2, T3> : IInputData<T1, T2>
    {
        Array ItemArray3 { get; }
    }

    internal interface IInputData<T1, T2, T3, T4> : IInputData<T1, T2, T3>
    {
        Array ItemArray4 { get; }
    }

    internal interface IInputData<T1, T2, T3, T4, T5> : IInputData<T1, T2, T3, T4>
    {
        Array ItemArray5 { get; }
    }
}