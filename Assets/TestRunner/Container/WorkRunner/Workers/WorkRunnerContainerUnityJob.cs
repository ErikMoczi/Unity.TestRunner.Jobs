using System;
using System.Reflection;
using TestRunner.Config.Worker.Interfaces;
using TestRunner.Container.WorkRunner.Base;
using TestRunner.Workers;
using Unity.Jobs;

namespace TestRunner.Container.WorkRunner.Workers
{
    internal abstract class WorkRunnerContainerUnityJob<TWorker, TConfig> : WorkRunnerContainer<TWorker, TConfig>
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfigUnityJob
    {
        private readonly IJobExtensionsWrapper _extensionsWrapper;

        public WorkRunnerContainerUnityJob(TConfig config) : base(config)
        {
            _extensionsWrapper = GetJobExtensionsWrapper();
        }

        private IJobExtensionsWrapper GetJobExtensionsWrapper()
        {
            return InitJobExtensionsWrapper();
        }

        protected abstract IJobExtensionsWrapper InitJobExtensionsWrapper();

        protected abstract object[] BatchedParameters(ref TWorker worker);
        protected abstract object[] UnBatchedParameters(ref TWorker worker);

        public sealed override void Run(ref TWorker worker)
        {
            var jobExType = Assembly.GetAssembly(_extensionsWrapper.ExtensionType)
                .GetType(_extensionsWrapper.ExtensionType.ToString());

            string methodName;
            object[] invokeParameters;
            if (GetConfig().Scheduled)
            {
                invokeParameters = BatchedParameters(ref worker);
                methodName = _extensionsWrapper.MethodNameBatched;
            }
            else
            {
                invokeParameters = UnBatchedParameters(ref worker);
                methodName = _extensionsWrapper.MethodNameUnBatched;
            }

            var methodInfo = jobExType.GetMethod(methodName);
            if (methodInfo == null)
            {
                throw new Exception($"Unity Job Api has changed - correct it!");
            }

            var genericMethodInfo = methodInfo.MakeGenericMethod(typeof(TWorker));
            var result = genericMethodInfo.Invoke(worker, invokeParameters);

            if (GetConfig().Scheduled)
            {
                ((JobHandle) result).Complete();
            }
        }
    }
}