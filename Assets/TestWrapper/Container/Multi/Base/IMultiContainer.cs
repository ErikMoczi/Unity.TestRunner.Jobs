using TestWrapper.Container.Info.Methods;

namespace TestWrapper.Container.Multi.Base
{
    internal interface IMultiContainer : IRefreshContainer, IInfoDataArray
    {
        int DataSize { get; }
    }

    internal interface IMultiContainer<T1> : IMultiContainer
    {
        T1 Item1 { get; }
    }

    internal interface IMultiContainer<T1, T2> : IMultiContainer<T1>
    {
        T2 Item2 { get; }
    }

    internal interface IMultiContainer<T1, T2, T3> : IMultiContainer<T1, T2>
    {
        T3 Item3 { get; }
    }

    internal interface IMultiContainer<T1, T2, T3, T4> : IMultiContainer<T1, T2, T3>
    {
        T4 Item4 { get; }
    }

    internal interface IMultiContainer<T1, T2, T3, T4, T5> : IMultiContainer<T1, T2, T3, T4>
    {
        T5 Item5 { get; }
    }

    internal interface IMultiContainer<T1, T2, T3, T4, T5, T6> : IMultiContainer<T1, T2, T3, T4, T5>
    {
        T6 Item6 { get; }
    }

    internal interface IMultiContainer<T1, T2, T3, T4, T5, T6, T7> : IMultiContainer<T1, T2, T3, T4, T5, T6>
    {
        T7 Item7 { get; }
    }

    internal interface IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8> : IMultiContainer<T1, T2, T3, T4, T5, T6, T7>
    {
        T8 Item8 { get; }
    }

    internal interface
        IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        T9 Item9 { get; }
    }

    internal interface
        IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        T10 Item10 { get; }
    }

    internal interface
        IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8,
            T9, T10>
    {
        T11 Item11 { get; }
    }

    internal interface
        IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IMultiContainer<T1, T2, T3, T4, T5, T6, T7,
            T8, T9, T10, T11>
    {
        T12 Item12 { get; }
    }
}