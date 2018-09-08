using System;
using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Container.WorkRunner.Base;
using TestWrapper.Workers;

namespace TestWrapper.Container.WorkRunner.Workers
{
    internal sealed class WorkRunnerContainerIPlainExt<TWorker, TConfig> : WorkRunnerContainer<TWorker, TConfig>
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfigDefault
    {
        public WorkRunnerContainerIPlainExt(TConfig config) : base(config)
        {
        }

        public override Type WorkerType()
        {
            return typeof(IPlainExt);
        }

        public override void Run(ref TWorker work)
        {
            ((IPlainExt) work).Execute();
        }
    }
}