using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Workers.Wrappers
{
    internal class
        WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5> : WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4>,
            IWorkerWrapper<T1, T2, T3, T4, T5>
        where TWorker : struct, IWorker<T1, T2, T3, T4, T5>
        where TConfig : class, IWorkConfig
    {
        public T5 Data5
        {
            get => Worker.Data5;
            set => Worker.Data5 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}