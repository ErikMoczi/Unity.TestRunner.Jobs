using TestWrapper.Container.Multi.Base;
using TestWrapper.Facades;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper.Utils.Factories
{
    internal static class WorkFacadeFactory
    {
        public static IWorkFacade Instantiate<TWorkerWrapper, TMultiContainer, T1>(string testName,
            TWorkerWrapper workerWrapper, TMultiContainer multiContainer)
            where TWorkerWrapper : class, IWorkerWrapper<T1>
            where TMultiContainer : class, IMultiContainer<T1>
        {
            return new WorkFacade<TWorkerWrapper, TMultiContainer, T1>(testName, workerWrapper, multiContainer);
        }

        public static IWorkFacade Instantiate<TWorkerWrapper, TMultiContainer, T1, T2>(string testName,
            TWorkerWrapper workerWrapper, TMultiContainer multiContainer)
            where TWorkerWrapper : class, IWorkerWrapper<T1, T2>
            where TMultiContainer : class, IMultiContainer<T1, T2>
        {
            return new WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2>(testName, workerWrapper, multiContainer);
        }

        public static IWorkFacade Instantiate<TWorkerWrapper, TMultiContainer, T1, T2, T3>(string testName,
            TWorkerWrapper workerWrapper, TMultiContainer multiContainer)
            where TWorkerWrapper : class, IWorkerWrapper<T1, T2, T3>
            where TMultiContainer : class, IMultiContainer<T1, T2, T3>
        {
            return new WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2, T3>(testName, workerWrapper, multiContainer);
        }

        public static IWorkFacade Instantiate<TWorkerWrapper, TMultiContainer, T1, T2, T3, T4>(string testName,
            TWorkerWrapper workerWrapper, TMultiContainer multiContainer)
            where TWorkerWrapper : class, IWorkerWrapper<T1, T2, T3, T4>
            where TMultiContainer : class, IMultiContainer<T1, T2, T3, T4>
        {
            return new WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2, T3, T4>(testName, workerWrapper,
                multiContainer);
        }

        public static IWorkFacade Instantiate<TWorkerWrapper, TMultiContainer, T1, T2, T3, T4, T5>(string testName,
            TWorkerWrapper workerWrapper, TMultiContainer multiContainer)
            where TWorkerWrapper : class, IWorkerWrapper<T1, T2, T3, T4, T5>
            where TMultiContainer : class, IMultiContainer<T1, T2, T3, T4, T5>
        {
            return new WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2, T3, T4, T5>(testName, workerWrapper,
                multiContainer);
        }
    }
}