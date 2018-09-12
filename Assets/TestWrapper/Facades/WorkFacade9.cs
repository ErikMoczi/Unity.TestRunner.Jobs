using TestWrapper.Container.Multi.Base;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper.Facades
{
    internal class
        WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2, T3, T4, T5, T6, T7, T8, T9> : WorkFacade<TWorkerWrapper,
            TMultiContainer, T1, T2, T3, T4, T5, T6, T7, T8>
        where TWorkerWrapper : class, IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        where TMultiContainer : class, IMultiContainer<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public WorkFacade(string testName, TWorkerWrapper workerWrapper, TMultiContainer multiContainer) : base(
            testName, workerWrapper, multiContainer)
        {
        }

        protected override void SetUpSafe()
        {
            base.SetUpSafe();
            WorkerWrapper.Data9 = MultiContainer.Item9;
        }
    }
}