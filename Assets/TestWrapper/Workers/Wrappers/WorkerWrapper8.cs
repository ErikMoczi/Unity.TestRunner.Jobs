using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5, T6, T7, T8> :
        WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5, T6, T7>, IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7, T8>
        where TWorker : struct, IWorker<T1, T2, T3, T4, T5, T6, T7, T8>
        where TConfig : class, IWorkConfig
    {
        public T8 Data8
        {
            get => Worker.Data8;
            set => Worker.Data8 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}