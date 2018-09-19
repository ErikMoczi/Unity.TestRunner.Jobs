using TestWrapper.Container.Multi.Base;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper.Facades
{
    internal class
        WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2, T3, T4> : WorkFacade<TWorkerWrapper, TMultiContainer, T1, T2
            , T3>
        where TWorkerWrapper : class, IWorkerWrapper<T1, T2, T3, T4>
        where TMultiContainer : class, IMultiContainer<T1, T2, T3, T4>
    {
        public WorkFacade(string testName, TWorkerWrapper workerWrapper, TMultiContainer multiContainer) : base(
            testName, workerWrapper, multiContainer)
        {
        }

        protected override void SetUpUnSafe()
        {
            base.SetUpUnSafe();
            WorkerWrapper.Data4 = MultiContainer.Item4;
        }
    }
}