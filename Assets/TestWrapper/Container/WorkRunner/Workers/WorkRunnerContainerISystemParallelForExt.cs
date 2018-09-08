using System;
using System.Threading.Tasks;
using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Container.WorkRunner.Base;
using TestWrapper.Workers;

namespace TestWrapper.Container.WorkRunner.Workers
{
    internal sealed class
        WorkRunnerContainerISystemParallelForExt<TWorker, TConfig, T1> : WorkRunnerContainer<TWorker, TConfig>
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfigDefault
    {
        public WorkRunnerContainerISystemParallelForExt(TConfig config) : base(config)
        {
        }

        public override Type WorkerType()
        {
            return typeof(ISystemParallelForExt);
        }

        public override void Run(ref TWorker work)
        {
            var systemParallelForExt = (ISystemParallelForExt<T1>) work;
            var parallelLoopResult = Parallel.For(0, systemParallelForExt.DataSize, systemParallelForExt.Execute);

            while (!parallelLoopResult.IsCompleted)
            {
            }
        }
    }
}