using System;
using System.Reflection;
using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Container.WorkRunner.Base;
using TestWrapper.Workers;
using Unity.Jobs;

namespace TestWrapper.Container.WorkRunner.Workers
{
    internal abstract class WorkRunnerContainerUnityJob<TWorker, TConfig> : WorkRunnerContainer<TWorker, TConfig>
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfigUnityJob
    {
        private readonly IJobExtensionsWrapper _extensionsWrapper;
        private readonly MethodInfo _genericMethodInfo;

        public WorkRunnerContainerUnityJob(TConfig config) : base(config)
        {
            _extensionsWrapper = InitJobExtensionsWrapper();
            _genericMethodInfo = InitRunMethod();
        }

        private IJobExtensionsWrapper InitJobExtensionsWrapper()
        {
            return CreateJobExtensionsWrapper();
        }

        protected abstract IJobExtensionsWrapper CreateJobExtensionsWrapper();

        protected abstract object[] BatchedParameters(ref TWorker worker);
        protected abstract object[] UnBatchedParameters(ref TWorker worker);

        public sealed override void Run(ref TWorker worker)
        {
            var result = _genericMethodInfo.Invoke(worker, GetInvokeParameters(ref worker));
            if (GetConfig().Scheduled)
            {
                ((JobHandle) result).Complete();
            }
        }

        private MethodInfo InitRunMethod()
        {
            var methodInfo = _extensionsWrapper.ExtensionType.GetMethod(GetMethodName());
            if (methodInfo == null)
            {
                throw new Exception($"Unity Job Api has changed - correct it!");
            }

            return methodInfo.MakeGenericMethod(typeof(TWorker));
        }

        private string GetMethodName()
        {
            return GetConfig().Scheduled
                ? _extensionsWrapper.MethodNameBatched
                : _extensionsWrapper.MethodNameUnBatched;
        }

        private object[] GetInvokeParameters(ref TWorker worker)
        {
            return GetConfig().Scheduled ? BatchedParameters(ref worker) : UnBatchedParameters(ref worker);
        }
    }
}