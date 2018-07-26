namespace TestRunner.InputData
{
    internal interface IInputData
    {
    }

    internal interface IInputData<T1> : IInputData
        where T1 : struct
    {
        T1[] ItemArray1 { get; }
    }

    internal interface IInputData<T1, T2> : IInputData<T1>
        where T1 : struct
        where T2 : struct
    {
        T2[] ItemArray2 { get; }
    }

    internal interface IInputData<T1, T2, T3> : IInputData<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        T3[] ItemArray3 { get; }
    }

    internal interface IInputData<T1, T2, T3, T4> : IInputData<T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        T4[] ItemArray4 { get; }
    }

    internal interface IInputData<T1, T2, T3, T4, T5> : IInputData<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        T5[] ItemArray5 { get; }
    }
}