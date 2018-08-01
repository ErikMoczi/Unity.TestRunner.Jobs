using TestRunner.DataContainer.Struct;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Workers.Extensions;
using TestRunner.Wrappers.Base.Config;
using TestRunner.Wrappers.Base.Job;

namespace TestRunner.Wrappers.IJob
{
    internal sealed class
        JobWrapper<TDataContainer, TData, TWorker, TConfig, T1> : JobWrapperBase<TDataContainer, TData, TWorker, TConfig
            , T1>
        where TDataContainer : class, IStructContainer<TConfig, T1>
        where TData : class, IInputData<T1>
        where TWorker : struct, IJobExt<T1>
        where TConfig : class, IWorkConfigIJob
        where T1 : struct
    {
        public JobWrapper(TWorker job, TData data, TConfig config) : base(job, data, config)
        {
        }

        protected override void TestCase(TConfig config)
        {
            Worker.RunTest(config);
        }
    }
}