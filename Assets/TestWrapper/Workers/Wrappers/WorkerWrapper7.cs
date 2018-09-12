using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5, T6, T7> :
        WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5, T6>, IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7>
        where TWorker : struct, IWorker<T1, T2, T3, T4, T5, T6, T7>
        where TConfig : class, IWorkConfig
    {
        public T7 Data7
        {
            get => Worker.Data7;
            set => Worker.Data7 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }
    }
}