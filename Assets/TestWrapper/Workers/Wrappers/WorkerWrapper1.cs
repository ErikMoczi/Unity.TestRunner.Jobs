using System;
using TestWrapper.Config.Worker.Interfaces;
using TestWrapper.Container.WorkRunner.Base;
using TestWrapper.Container.WorkRunner.Workers;

namespace TestWrapper.Workers.Wrappers
{
    internal class WorkerWrapper<TWorker, TConfig, T1> : WorkerWrapper<TWorker, TConfig>, IWorkerWrapper<T1>
        where TWorker : struct, IWorker<T1>
        where TConfig : class, IWorkConfig
    {
        public int DataSize
        {
            get => Worker.DataSize;
            set => Worker.DataSize = value;
        }

        public T1 Data1
        {
            get => Worker.Data1;
            set => Worker.Data1 = value;
        }

        public WorkerWrapper(TConfig config) : base(config)
        {
        }

        protected sealed override IWorkRunnerContainer<TWorker> CreateRunner()
        {
            switch (Worker)
            {
                case IJobExt jobExt:
                {
                    return new WorkRunnerContainerIJobExt<TWorker, IWorkConfigIJob>(GetConfig() as IWorkConfigIJob);
                }
                case IJobParallelForExt jobParallelForExt:
                {
                    return new WorkRunnerContainerIJobParallelForExt<TWorker, IWorkConfigIJobParallelFor, T1>(
                        GetConfig() as IWorkConfigIJobParallelFor);
                }
                case ISystemParallelForExt systemParallelForExt:
                {
                    return new WorkRunnerContainerISystemParallelForExt<TWorker, IWorkConfigDefault, T1>(
                        GetConfig() as IWorkConfigDefault);
                }
                case IPlainExt plainExt:
                {
                    return new WorkRunnerContainerIPlainExt<TWorker, IWorkConfigDefault>(
                        GetConfig() as IWorkConfigDefault);
                }
                default:
                {
                    throw new Exception($"Internal missing implementation of worker - {Worker}");
                }
            }
        }

        public sealed override void Run()
        {
            Runner.Run(ref Worker);
        }
    }
}