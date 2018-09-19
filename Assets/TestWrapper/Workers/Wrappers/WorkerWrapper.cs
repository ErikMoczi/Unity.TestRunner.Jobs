using System;
using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Container;
using TestWrapper.Container.Info;
using TestWrapper.Container.WorkRunner.Base;

namespace TestWrapper.Workers.Wrappers
{
    internal abstract class WorkerWrapper<TWorker, TConfig> : BaseContainer<TConfig>, IWorkerWrapper
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfig
    {
        protected TWorker Worker;
        protected IWorkRunnerContainer<TWorker> Runner => _runner;

        private readonly IWorkRunnerContainer<TWorker> _runner;

        public WorkerWrapper(TConfig config) : base(config)
        {
            if (typeof(TWorker).GetConstructors().Length > 1)
            {
                throw new Exception(
                    $"Remove all constructors of {typeof(TWorker)}, only explicit parameterless constructor"
                );
            }

            Worker = new TWorker();
            _runner = InitRunner();
        }

        private IWorkRunnerContainer<TWorker> InitRunner()
        {
            return CreateRunner();
        }

        protected abstract IWorkRunnerContainer<TWorker> CreateRunner();

        public new IContainerInfoWorker Info()
        {
            return new ContainerInfoWorker(typeof(TWorker).Name, typeof(TWorker).Namespace, GetConfig().ToString(),
                _runner.WorkerType().Name);
        }

        public abstract void Run();

        public void CustomSetUp()
        {
            Worker.CustomSetUp();
        }

        public void CustomCleanUp()
        {
            Worker.CustomCleanUp();
        }
    }
}