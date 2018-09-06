using TestRunner.Container.SetUp;

namespace TestRunner.Facades.SetUp
{
    internal sealed class WorkerWrapperSetUp : IWorkerWrapperSetUp
    {
        private readonly IContainerWorkerSetUp _worker;
        private readonly IContainerSetUp[] _multiContainer;

        public IContainerWorkerSetUp Worker => _worker;
        public IContainerSetUp[] MultiContainer => _multiContainer;

        public WorkerWrapperSetUp(IContainerWorkerSetUp worker, IContainerSetUp[] multiContainer)
        {
            _worker = worker;
            _multiContainer = multiContainer;
        }
    }
}