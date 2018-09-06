using TestRunner.Config.Data.Interfaces;
using TestRunner.Container.Multi.Base;
using TestRunner.Facades.SetUp;
using TestRunner.InputData;
using TestRunner.Workers.Wrappers;

namespace TestRunner.Facades
{
    internal abstract class WorkFacade<TMultiContainer, TData, TWorkerWrapper, TConfig> : IWorkFacade
        where TMultiContainer : class, IMultiContainer
        where TData : class, IInputData
        where TWorkerWrapper : class, IWorkerWrapper
        where TConfig : class, IDataConfig
    {
        protected TWorkerWrapper Worker;

        protected TMultiContainer MultiContainer => _multiContainer;
        private readonly TMultiContainer _multiContainer;

        public WorkFacade(TWorkerWrapper worker, TData data, TConfig[] config)
        {
            Worker = worker;
            _multiContainer = GetMultiContainer(data, config);
        }

        private TMultiContainer GetMultiContainer(TData data, TConfig[] config)
        {
            return InitMultiContainer(data, config);
        }

        protected abstract TMultiContainer InitMultiContainer(TData data, TConfig[] config);

        public virtual void Init()
        {
            _multiContainer.Init();
        }

        public void Dispose()
        {
            _multiContainer.Dispose();
        }

        public void Run()
        {
            Worker.Run();
        }

        public IWorkerWrapperSetUp SetUp()
        {
            return new WorkerWrapperSetUp(Worker.SetUp(), MultiContainer.SetUp());
        }
    }
}