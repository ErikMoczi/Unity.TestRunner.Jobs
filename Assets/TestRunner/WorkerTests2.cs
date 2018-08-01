using TestRunner.DataContainer.Array;
using TestRunner.DataContainer.Struct;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using TestRunner.Wrappers.IJob;
using TestRunner.Wrappers.IJobParallelFor;
using TestRunner.Wrappers.INonJob;

namespace TestRunner
{
    public static class WorkerTests<T1, T2>
        where T1 : struct
        where T2 : struct
    {
        internal static IWorkWrapper RunIJob<TJob, TConfig>(TJob job, IInputData<T1, T2> data, TConfig config)
            where TJob : struct, IJobExt<T1, T2>
            where TConfig : class, IWorkConfigIJob
        {
            return new JobWrapper<IStructContainer<TConfig, T1, T2>, IInputData<T1, T2>, TJob, TConfig, T1, T2>(job,
                data, config);
        }

        public static IWorkWrapper RunIJob<TJob, TConfig>(TJob job, T1[] itemArray1, T2[] itemArray2, TConfig config)
            where TJob : struct, IJobExt<T1, T2>
            where TConfig : class, IWorkConfigIJob
        {
            return RunIJob(job, new InputData<T1, T2>(itemArray1, itemArray2), config);
        }

        internal static IWorkWrapper RunIJobParallelFor<TJob, TConfig>(TJob job, IInputData<T1, T2> data,
            TConfig config)
            where TJob : struct, IJobParallelForExt<T1, T2>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return new JobParallelForWrapper<IStructContainer<TConfig, T1, T2>, IInputData<T1, T2>, TJob, TConfig, T1,
                T2>(job, data, config);
        }

        public static IWorkWrapper RunIJobParallelFor<TJob, TConfig>(TJob job, T1[] itemArray1, T2[] itemArray2,
            TConfig config)
            where TJob : struct, IJobParallelForExt<T1, T2>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return RunIJobParallelFor(job, new InputData<T1, T2>(itemArray1, itemArray2), config);
        }

        internal static IWorkWrapper RunINonJob<TJob, TConfig>(TJob job, IInputData<T1, T2> data, TConfig config = null)
            where TJob : struct, INonJobExt<T1, T2>
            where TConfig : class, IWorkConfigINonJob
        {
            return new NonJobWrapper<IArrayContainer<TConfig, T1, T2>, IInputData<T1, T2>, TJob, TConfig, T1, T2>(job,
                data, config);
        }

        public static IWorkWrapper RunINonJob<TJob>(TJob job, T1[] itemArray1, T2[] itemArray2)
            where TJob : struct, INonJobExt<T1, T2>
        {
            return RunINonJob(job, new InputData<T1, T2>(itemArray1, itemArray2), new WorkConfigINonJob());
        }
    }
}