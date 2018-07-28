using TestRunner.Wrappers.Base;
using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using TestRunner.Jobs.Extensions;

namespace TestRunner.Wrappers.IJob
{
    internal sealed class JobWrapper<TDataContainer, TData, TJob, T1> : JobWrapperBase<TDataContainer, TData, TJob, T1>
        where T1 : struct
        where TDataContainer : class, IDataContainer<T1>
        where TData : class, IInputData<T1>
        where TJob : struct, IJobExtended<T1>
    {
        public JobWrapper(ref TJob job, ref TData data) : base(ref job, ref data)
        {
        }

        protected override void TestCase(bool scheduled)
        {
            Job.RunTest(scheduled);
        }
    }
}