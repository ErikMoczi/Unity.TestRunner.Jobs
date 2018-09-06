using System;
using TestRunner.Config.Worker.Interfaces;
using TestRunner.Container.WorkRunner.Base;
using TestRunner.Workers;

namespace TestRunner.Container.WorkRunner.Workers
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