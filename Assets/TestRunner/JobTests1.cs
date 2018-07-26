using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.IJob;
using TestRunner.Wrappers.IJobParallelFor;

namespace TestRunner
{
    public class JobTests<T1>
        where T1 : struct
    {
        internal static IJobWrapperBase RunIJob<TJob>(ref TJob job, IInputData<T1> data)
            where TJob : struct, IJobExtended<T1>
        {
            return new JobWrapper<IDataContainer<T1>, IInputData<T1>, TJob, T1>(ref job, ref data);
        }

        public static IJobWrapperBase RunIJob<TJob>(TJob job, T1[] itemArray1)
            where TJob : struct, IJobExtended<T1>
        {
            return RunIJob(ref job, new InputData<T1>(ref itemArray1));
        }

        internal static IJobWrapperBase RunIJobParallelFor<TJob>(ref TJob job, IInputData<T1> data)
            where TJob : struct, IJobParallelForExtended<T1>
        {
            return new JobParallelForWrapper<IDataContainer<T1>, IInputData<T1>, TJob, T1>(ref job, ref data);
        }

        public static IJobWrapperBase RunIJobParallelFor<TJob>(TJob job, T1[] itemArray1)
            where TJob : struct, IJobParallelForExtended<T1>
        {
            return RunIJobParallelFor(ref job, new InputData<T1>(ref itemArray1));
        }
    }
}