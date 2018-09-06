using System;
using TestRunner.Config.Worker.Interfaces;
using TestRunner.Workers;
using Unity.Jobs;

namespace TestRunner.Container.WorkRunner.Workers
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

        protected override IJobExtensionsWrapper InitJobExtensionsWrapper()
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