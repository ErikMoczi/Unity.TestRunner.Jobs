using System;
using TestRunner.Config.Worker.Interfaces;
using TestRunner.Container;
using TestRunner.Container.SetUp;
using TestRunner.Container.WorkRunner.Base;

namespace TestRunner.Workers.Wrappers
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
            _runner = GetRunner();
        }

        public IContainerWorkerSetUp SetUp()
        {
            return new ContainerWorkerSetUp(typeof(TWorker).Name, typeof(TWorker).Namespace, GetConfig().ToString(),
                _runner.WorkerType().Name);
        }

        private IWorkRunnerContainer<TWorker> GetRunner()
        {
            return InitRunner();
        }

        protected abstract IWorkRunnerContainer<TWorker> InitRunner();

        public abstract void Run();
    }
}