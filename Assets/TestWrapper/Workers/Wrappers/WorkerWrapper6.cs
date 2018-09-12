using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5, T6> :
        WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5>, IWorkerWrapper<T1, T2, T3, T4, T5, T6>
        where TWorker : struct, IWorker<T1, T2, T3, T4, T5, T6>
        where TConfig : class, IWorkConfig
    {
        public T6 Data6
        {
            get => Worker.Data6;
            set => Worker.Data6 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}