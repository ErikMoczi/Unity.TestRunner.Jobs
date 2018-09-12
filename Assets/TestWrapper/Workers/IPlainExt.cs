namespace TestWrapper.Workers
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

    public interface IPlainExt<T1, T2, T3, T4, T5, T6> : IPlainExt<T1, T2, T3, T4, T5>, IWorker<T1, T2, T3, T4, T5, T6>
    {
    }

    public interface IPlainExt<T1, T2, T3, T4, T5, T6, T7> : IPlainExt<T1, T2, T3, T4, T5, T6>,
        IWorker<T1, T2, T3, T4, T5, T6, T7>
    {
    }

    public interface IPlainExt<T1, T2, T3, T4, T5, T6, T7, T8> : IPlainExt<T1, T2, T3, T4, T5, T6, T7>,
        IWorker<T1, T2, T3, T4, T5, T6, T7, T8>
    {
    }

    public interface IPlainExt<T1, T2, T3, T4, T5, T6, T7, T8, T9> : IPlainExt<T1, T2, T3, T4, T5, T6, T7, T8>,
        IWorker<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
    }
}