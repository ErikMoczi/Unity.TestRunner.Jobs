using TestRunner.DataContainer.Struct;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Workers.Extensions;
using TestRunner.Wrappers.Base.Config;
using TestRunner.Wrappers.Base.Job;

namespace TestRunner.Wrappers.IJobParallelFor
{
    internal sealed class
        JobParallelForWrapper<TDataContainer, TData, TWorker, TConfig, T1, T2, T3, T4> : JobWrapperBase<TDataContainer,
            TData, TWorker, TConfig, T1, T2, T3, T4>
        where TDataContainer : class, IStructContainer<TConfig, T1, T2, T3, T4>
        where TData : class, IInputData<T1, T2, T3, T4>
        where TWorker : struct, IJobParallelForExt<T1, T2, T3, T4>
        where TConfig : class, IWorkConfigIJobParallelFor
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        public JobParallelForWrapper(TWorker job, TData data, TConfig config) : base(job, data, config)
        {
        }

        protected override void TestCase(TConfig config)
        {
            Worker.RunTest(config, Worker.DataSize);
        }
    }
}