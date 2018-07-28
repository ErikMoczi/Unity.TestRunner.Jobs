using TestRunner.Wrappers.Base;
using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using TestRunner.Jobs.Extensions;

namespace TestRunner.Wrappers.IJobParallelFor
{
    internal sealed class
        JobParallelForWrapper<TDataContainer, TData, TJob, T1, T2, T3, T4, T5> : JobWrapperBase<TDataContainer, TData,
            TJob, T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where TDataContainer : class, IDataContainer<T1, T2, T3, T4, T5>
        where TData : class, IInputData<T1, T2, T3, T4, T5>
        where TJob : struct, IJobParallelForExtended<T1, T2, T3, T4, T5>
    {
        public JobParallelForWrapper(TJob job, TData data) : base(job, data)
        {
        }

        protected override void TestCase(bool scheduled)
        {
            Job.RunTest(scheduled, Job.DataSize);
        }
    }
}