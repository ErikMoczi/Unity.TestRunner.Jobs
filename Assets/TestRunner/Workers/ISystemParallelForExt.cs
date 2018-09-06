namespace TestRunner.Workers
{
    public interface ISystemParallelForExt
    {
        void Execute(int index);
    }

    public interface ISystemParallelForExt<T1> : ISystemParallelForExt, IWorker<T1>
    {
    }

    public interface ISystemParallelForExt<T1, T2> : ISystemParallelForExt<T1>, IWorker<T1, T2>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3> : ISystemParallelForExt<T1, T2>, IWorker<T1, T2, T3>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4> : ISystemParallelForExt<T1, T2, T3>, IWorker<T1, T2, T3, T4>
    {
    }

    public interface ISystemParallelForExt<T1, T2, T3, T4, T5> : ISystemParallelForExt<T1, T2, T3, T4>,
        IWorker<T1, T2, T3, T4, T5>
    {
    }
}