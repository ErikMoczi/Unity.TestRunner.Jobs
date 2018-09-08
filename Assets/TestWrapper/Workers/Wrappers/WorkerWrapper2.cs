using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1, T2> : WorkerWrapper<TWorker, TConfig, T1>, IWorkerWrapper<T1, T2>
        where TWorker : struct, IWorker<T1, T2>
        where TConfig : class, IWorkConfig
    {
        public T2 Data2
        {
            get => Worker.Data2;
            set => Worker.Data2 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}