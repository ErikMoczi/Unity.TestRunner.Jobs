using System;
using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Workers;
using Unity.Jobs;

namespace TestWrapper.Container.WorkRunner.Workers
{
    internal sealed class WorkRunnerContainerIJobExt<TWorker, TConfig> : WorkRunnerContainerUnityJob<TWorker, TConfig>
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfigIJob
    {
        public WorkRunnerContainerIJobExt(TConfig config) : base(config)
        {
        }

        public override Type WorkerType()
        {
            return typeof(IJobExt);
        }

        protected override IJobExtensionsWrapper CreateJobExtensionsWrapper()
        {
            return new JobExtensionsWrapper(
                typeof(IJobExtensions), nameof(IJobExtensions.Schedule), nameof(IJobExtensions.Run)
            );
        }

        protected override object[] BatchedParameters(ref TWorker worker)
        {
            return new[] {worker, Type.Missing};
        }

        protected override object[] UnBatchedParameters(ref TWorker worker)
        {
            return new object[] {worker};
        }
    }
}