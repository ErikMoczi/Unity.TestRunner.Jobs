﻿using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using TestRunner.Jobs.Extensions;
using TestRunner.Wrappers.Base;

namespace TestRunner.Wrappers.IJob
{
    internal class
        JobWrapper<TDataContainer, TData, TJob, T1, T2, T3> : JobWrapperBase<TDataContainer, TData, TJob, T1, T2, T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where TDataContainer : class, IDataContainer<T1, T2, T3>
        where TData : class, IInputData<T1, T2, T3>
        where TJob : struct, IJobExtended<T1, T2, T3>
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