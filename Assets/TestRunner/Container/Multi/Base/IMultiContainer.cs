using TestRunner.Container.SetUp;

namespace TestRunner.Container.Multi.Base
{
    internal interface IMultiContainer : IRefreshContainer, IContainerInfoMulti
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
}