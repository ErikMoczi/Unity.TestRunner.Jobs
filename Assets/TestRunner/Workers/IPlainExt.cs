namespace TestRunner.Workers
{
    public interface IPlainExt
    {
        void Execute();
    }

    public interface IPlainExt<T1> : IPlainExt, IWorker<T1>
    {
    }

    public interface IPlainExt<T1, T2> : IPlainExt<T1>, IWorker<T1, T2>
    {
    }

    public interface IPlainExt<T1, T2, T3> : IPlainExt<T1, T2>, IWorker<T1, T2, T3>
    {
    }

    public interface IPlainExt<T1, T2, T3, T4> : IPlainExt<T1, T2, T3>, IWorker<T1, T2, T3, T4>
    {
    }

    public interface IPlainExt<T1, T2, T3, T4, T5> : IPlainExt<T1, T2, T3, T4>, IWorker<T1, T2, T3, T4, T5>
    {
    }
}