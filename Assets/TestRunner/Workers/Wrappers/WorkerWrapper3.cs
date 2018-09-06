using TestRunner.Config.Worker.Interfaces;

namespace TestRunner.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1, T2, T3> : WorkerWrapper<TWorker, TConfig, T1, T2>,
        IWorkerWrapper<T1, T2, T3>
        where TWorker : struct, IWorker<T1, T2, T3>
        where TConfig : class, IWorkConfig
    {
        public T3 Data3
        {
            get => Worker.Data3;
            set => Worker.Data3 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}