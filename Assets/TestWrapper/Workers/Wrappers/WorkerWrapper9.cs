using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5, T6, T7, T8, T9> :
        WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5, T6, T7, T8>,
        IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where TWorker : struct, IWorker<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where TConfig : class, IWorkConfig
    {
        public T9 Data9
        {
            get => Worker.Data9;
            set => Worker.Data9 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}