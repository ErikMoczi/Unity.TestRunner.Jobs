using TestRunner.DataContainer.Struct;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Workers.Extensions;
using TestRunner.Wrappers.Base.Config;
using TestRunner.Wrappers.Base.Job;

namespace TestRunner.Wrappers.IJob
{
    internal sealed class
        JobWrapper<TDataContainer, TData, TWorker, TConfig, T1, T2, T3, T4, T5> : JobWrapperBase<TDataContainer, TData,
            TWorker, TConfig, T1, T2, T3, T4, T5>
        where TDataContainer : class, IStructContainer<TConfig, T1, T2, T3, T4, T5>
        where TData : class, IInputData<T1, T2, T3, T4, T5>
        where TWorker : struct, IJobExt<T1, T2, T3, T4, T5>
        where TConfig : class, IWorkConfigIJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        public JobWrapper(string testName, TWorker worker, TData data, TConfig config) : base(testName, worker, data,
            config)
        {
        }

        protected override void TestCase(TConfig config)
        {
            Worker.RunTest(config);
        }
    }
}