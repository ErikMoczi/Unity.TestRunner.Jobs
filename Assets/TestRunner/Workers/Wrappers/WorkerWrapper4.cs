using TestRunner.Config.Worker.Interfaces;

namespace TestRunner.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4> : WorkerWrapper<TWorker, TConfig, T1, T2, T3>,
        IWorkerWrapper<T1, T2, T3, T4>
        where TWorker : struct, IWorker<T1, T2, T3, T4>
        where TConfig : class, IWorkConfig
    {
        public T4 Data4
        {
            get => Worker.Data4;
            set => Worker.Data4 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}