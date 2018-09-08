using TestWrapper.Container.Multi.Base;
using TestWrapper.Workers.Wrappers;

namespace TestWrapper.Facades
{
    internal class WorkFacade<TWorkerWrapper, TMultiContainer, T1> : WorkFacade<TWorkerWrapper, TMultiContainer>
        where TWorkerWrapper : class, IWorkerWrapper<T1>
        where TMultiContainer : class, IMultiContainer<T1>
    {
        public WorkFacade(string testName, TWorkerWrapper workerWrapper, TMultiContainer multiContainer) : base(
            testName, workerWrapper, multiContainer)
        {
        }

        protected override void SetUpSafe()
        {
            base.SetUpSafe();
            WorkerWrapper.DataSize = MultiContainer.DataSize;
            WorkerWrapper.Data1 = MultiContainer.Item1;
        }
    }
}