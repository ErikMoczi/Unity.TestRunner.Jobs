using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.IJob;
using TestRunner.Wrappers.IJobParallelFor;

namespace TestRunner
{
    public static class JobTests<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        internal static IJobWrapperBase RunIJob<TJob>(TJob job, IInputData<T1, T2> data)
            where TJob : struct, IJobExtended<T1, T2>
        {
            return new JobWrapper<IDataContainer<T1, T2>, IInputData<T1, T2>, TJob, T1, T2>(job, data);
        }

        public static IJobWrapperBase RunIJob<TJob>(TJob job, T1[] itemArray1, T2[] itemArray2)
            where TJob : struct, IJobExtended<T1, T2>
        {
            return RunIJob(job, new InputData<T1, T2>(itemArray1, itemArray2));
        }

        internal static IJobWrapperBase RunIJobParallelFor<TJob>(TJob job, IInputData<T1, T2> data)
            where TJob : struct, IJobParallelForExtended<T1, T2>
        {
            return new JobParallelForWrapper<IDataContainer<T1, T2>, IInputData<T1, T2>, TJob, T1, T2>(job, data);
        }

        public static IJobWrapperBase RunIJobParallelFor<TJob>(TJob job, T1[] itemArray1, T2[] itemArray2)
            where TJob : struct, IJobParallelForExtended<T1, T2>
        {
            return RunIJobParallelFor(job, new InputData<T1, T2>(itemArray1, itemArray2));
        }
    }
}