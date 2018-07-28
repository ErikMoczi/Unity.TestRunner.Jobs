﻿using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.IJob;
using TestRunner.Wrappers.IJobParallelFor;

namespace TestRunner
{
    public static class JobTests<T1, T2, T3, T4>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        internal static IJobWrapperBase RunIJob<TJob>(TJob job, IInputData<T1, T2, T3, T4> data)
            where TJob : struct, IJobExtended<T1, T2, T3, T4>
        {
            return new JobWrapper<IDataContainer<T1, T2, T3, T4>, IInputData<T1, T2, T3, T4>, TJob, T1, T2, T3, T4>(job,
                data);
        }

        public static IJobWrapperBase RunIJob<TJob>(TJob job, T1[] itemArray1, T2[] itemArray2, T3[] itemArray3,
            T4[] itemArray4)
            where TJob : struct, IJobExtended<T1, T2, T3, T4>
        {
            return RunIJob(job, new InputData<T1, T2, T3, T4>(itemArray1, itemArray2, itemArray3, itemArray4));
        }

        internal static IJobWrapperBase RunIJobParallelFor<TJob>(TJob job, IInputData<T1, T2, T3, T4> data)
            where TJob : struct, IJobParallelForExtended<T1, T2, T3, T4>
        {
            return new JobParallelForWrapper<IDataContainer<T1, T2, T3, T4>, IInputData<T1, T2, T3, T4>, TJob, T1, T2,
                T3, T4>(job, data);
        }

        public static IJobWrapperBase RunIJobParallelFor<TJob>(TJob job, T1[] itemArray1, T2[] itemArray2,
            T3[] itemArray3, T4[] itemArray4)
            where TJob : struct, IJobParallelForExtended<T1, T2, T3, T4>
        {
            return RunIJobParallelFor(job,
                new InputData<T1, T2, T3, T4>(itemArray1, itemArray2, itemArray3, itemArray4));
        }
    }
}