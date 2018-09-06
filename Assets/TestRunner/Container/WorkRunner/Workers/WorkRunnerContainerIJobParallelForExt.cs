using System;
using TestRunner.Config.Worker.Interfaces;
using TestRunner.Workers;
using Unity.Jobs;

namespace TestRunner.Container.WorkRunner.Workers
{
    internal sealed class
        WorkRunnerContainerIJobParallelForExt<TWorker, TConfig, T1> : WorkRunnerContainerUnityJob<TWorker, TConfig>
        where TWorker : struct, IWorker<T1>
        where TConfig : class, IWorkConfigIJobParallelFor
    {
        public WorkRunnerContainerIJobParallelForExt(TConfig config) : base(config)
        {
        }

        public override Type WorkerType()
        {
            return typeof(IJobParallelForExt);
        }

        protected override IJobExtensionsWrapper InitJobExtensionsWrapper()
        {
            return new JobExtensionsWrapper(typeof(IJobParallelForExtensions),
                nameof(IJobParallelForExtensions.Schedule), nameof(IJobParallelForExtensions.Run));
        }

        protected override object[] BatchedParameters(ref TWorker worker)
        {
            return new[] {worker, ((IJobParallelForExt<T1>) worker).DataSize, GetConfig().BatchCount, Type.Missing};
        }

        protected override object[] UnBatchedParameters(ref TWorker worker)
        {
            return new object[] {worker, ((IJobParallelForExt<T1>) worker).DataSize};
        }
    }
}