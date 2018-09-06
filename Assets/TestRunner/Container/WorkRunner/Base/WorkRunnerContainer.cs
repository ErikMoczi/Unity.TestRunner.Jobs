using System;
using TestRunner.Config.Worker.Interfaces;
using TestRunner.Workers;

namespace TestRunner.Container.WorkRunner.Base
{
    internal abstract class WorkRunnerContainer<TWorker, TConfig> : BaseContainer<TConfig>,
        IWorkRunnerContainer<TWorker>
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfig
    {
        public WorkRunnerContainer(TConfig config) : base(config)
        {
            CheckWorkerType();
        }

        private void CheckWorkerType()
        {
            if (!WorkerType().IsAssignableFrom(typeof(TWorker)))
            {
                throw new Exception($"Internal {GetType().Name} incorrect job type");
            }
        }

        public abstract void Run(ref TWorker work);

        public abstract Type WorkerType();
    }
}