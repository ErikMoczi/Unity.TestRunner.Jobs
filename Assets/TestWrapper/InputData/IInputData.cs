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

    internal interface IInputData<T1, T2, T3, T4, T5, T6> : IInputData<T1, T2, T3, T4, T5>
    {
        Array ItemArray6 { get; }
    }

    internal interface IInputData<T1, T2, T3, T4, T5, T6, T7> : IInputData<T1, T2, T3, T4, T5, T6>
    {
        Array ItemArray7 { get; }
    }

    internal interface IInputData<T1, T2, T3, T4, T5, T6, T7, T8> : IInputData<T1, T2, T3, T4, T5, T6, T7>
    {
        Array ItemArray8 { get; }
    }

    internal interface IInputData<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IInputData<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        Array ItemArray9 { get; }
    }
}