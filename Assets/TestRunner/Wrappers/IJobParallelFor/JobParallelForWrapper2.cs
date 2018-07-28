﻿using TestRunner.Wrappers.Base;
using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using TestRunner.Jobs.Extensions;

namespace TestRunner.Wrappers.IJobParallelFor
{
    internal sealed class
        JobParallelForWrapper<TDataContainer, TData, TJob, T1, T2> : JobWrapperBase<TDataContainer, TData, TJob, T1, T2>
        where T1 : struct
        where T2 : struct
        where TDataContainer : class, IDataContainer<T1, T2>
        where TData : class, IInputData<T1, T2>
        where TJob : struct, IJobParallelForExtended<T1, T2>
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