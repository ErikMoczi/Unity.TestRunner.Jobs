using TestWrapper.Container.Multi.Base;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper.Facades
{
    internal class
        WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2, T3, T4, T5, T6, T7> : WorkFacade<TWorkerWrapper,
            TMultiContainer, T1, T2, T3, T4, T5, T6>
        where TWorkerWrapper : class, IWorkerWrapper<T1, T2, T3, T4, T5, T6, T7>
        where TMultiContainer : class, IMultiContainer<T1, T2, T3, T4, T5, T6, T7>
    {
        public WorkFacade(string testName, TWorkerWrapper workerWrapper, TMultiContainer multiContainer) : base(
            testName, workerWrapper, multiContainer)
        {
        }

        protected override void SetUpSafe()
        {
            base.SetUpSafe();
            WorkerWrapper.Data7 = MultiContainer.Item7;
        }
    }
}