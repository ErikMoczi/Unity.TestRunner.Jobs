using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Multi.Base;
using TestRunner.Facades;
using TestRunner.InputData;
using TestRunner.Workers.Wrappers;

namespace TestRunner.Extensions
{
    internal static class IWorkerWrapperExtension
    {
        internal static ITestFacade WorkerWrapper<TConfig, T1>(this IWorkerWrapper<T1> workerWrapper, string testName,
            IInputData<T1> data, TConfig[] config)
            where TConfig : class, IDataConfig
        {
            return new WorkFacade<IMultiContainer<T1>, IInputData<T1>, IWorkerWrapper<T1>, TConfig, T1>(workerWrapper,
                data, config).TestFacade(testName);
        }

        internal static ITestFacade WorkerWrapper<TConfig, T1, T2>(this IWorkerWrapper<T1, T2> workerWrapper,
            string testName, IInputData<T1, T2> data, TConfig[] config)
            where TConfig : class, IDataConfig
        {
            return new WorkFacade<IMultiContainer<T1, T2>, IInputData<T1, T2>, IWorkerWrapper<T1, T2>, TConfig, T1, T2>(
                workerWrapper, data, config).TestFacade(testName);
        }

        internal static ITestFacade WorkerWrapper<TConfig, T1, T2, T3>(this IWorkerWrapper<T1, T2, T3> workerWrapper,
            string testName, IInputData<T1, T2, T3> data, TConfig[] config)
            where TConfig : class, IDataConfig
        {
            return new WorkFacade<IMultiContainer<T1, T2, T3>, IInputData<T1, T2, T3>, IWorkerWrapper<T1, T2, T3>,
                TConfig, T1, T2, T3>(workerWrapper, data, config).TestFacade(testName);
        }

        internal static ITestFacade WorkerWrapper<TConfig, T1, T2, T3, T4>(
            this IWorkerWrapper<T1, T2, T3, T4> workerWrapper, string testName, IInputData<T1, T2, T3, T4> data,
            TConfig[] config)
            where TConfig : class, IDataConfig
        {
            return new WorkFacade<IMultiContainer<T1, T2, T3, T4>, IInputData<T1, T2, T3, T4>,
                    IWorkerWrapper<T1, T2, T3, T4>, TConfig, T1, T2, T3, T4>(workerWrapper, data, config)
                .TestFacade(testName);
        }

        internal static ITestFacade WorkerWrapper<TConfig, T1, T2, T3, T4, T5>(
            this IWorkerWrapper<T1, T2, T3, T4, T5> workerWrapper, string testName, IInputData<T1, T2, T3, T4, T5> data,
            TConfig[] config)
            where TConfig : class, IDataConfig
        {
            return new WorkFacade<IMultiContainer<T1, T2, T3, T4, T5>, IInputData<T1, T2, T3, T4, T5>,
                    IWorkerWrapper<T1, T2, T3, T4, T5>, TConfig, T1, T2, T3, T4, T5>(workerWrapper, data, config)
                .TestFacade(testName);
        }
    }
}