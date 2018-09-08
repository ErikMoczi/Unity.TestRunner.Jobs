using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Workers;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper.Utils.Factories
{
    internal static class WorkerWrapperFactory<TConfig>
        where TConfig : class, IWorkConfig
    {
        public static IWorkerWrapper<T1> Instantiate<TWorker, T1>(TConfig config)
            where TWorker : struct, IWorker<T1>
        {
            return new WorkerWrapper<TWorker, TConfig, T1>(config);
        }

        public static IWorkerWrapper<T1, T2> Instantiate<TWorker, T1, T2>(TConfig config)
            where TWorker : struct, IWorker<T1, T2>
        {
            return new WorkerWrapper<TWorker, TConfig, T1, T2>(config);
        }

        public static IWorkerWrapper<T1, T2, T3> Instantiate<TWorker, T1, T2, T3>(TConfig config)
            where TWorker : struct, IWorker<T1, T2, T3>
        {
            return new WorkerWrapper<TWorker, TConfig, T1, T2, T3>(config);
        }

        public static IWorkerWrapper<T1, T2, T3, T4> Instantiate<TWorker, T1, T2, T3, T4>(TConfig config)
            where TWorker : struct, IWorker<T1, T2, T3, T4>
        {
            return new WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4>(config);
        }

        public static IWorkerWrapper<T1, T2, T3, T4, T5> Instantiate<TWorker, T1, T2, T3, T4, T5>(TConfig config)
            where TWorker : struct, IWorker<T1, T2, T3, T4, T5>
        {
            return new WorkerWrapper<TWorker, TConfig, T1, T2, T3, T4, T5>(config);
        }
    }
}