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
    public static class WorkerTests<T1>
        where T1 : struct
    {
        internal static IWorkWrapper RunIJob<TJob, TConfig>(TJob job, IInputData<T1> data, TConfig config)
            where TJob : struct, IJobExt<T1>
            where TConfig : class, IWorkConfigIJob
        {
            return new JobWrapper<IStructContainer<TConfig, T1>, IInputData<T1>, TJob, TConfig, T1>(job, data, config);
        }

        public static IWorkWrapper RunIJob<TJob, TConfig>(TJob job, T1[] itemArray1, TConfig config)
            where TJob : struct, IJobExt<T1>
            where TConfig : class, IWorkConfigIJob
        {
            return RunIJob(job, new InputData<T1>(itemArray1), config);
        }

        internal static IWorkWrapper RunIJobParallelFor<TJob, TConfig>(TJob job, IInputData<T1> data, TConfig config)
            where TJob : struct, IJobParallelForExt<T1>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return new JobParallelForWrapper<IStructContainer<TConfig, T1>, IInputData<T1>, TJob, TConfig, T1>(job,
                data, config);
        }

        public static IWorkWrapper RunIJobParallelFor<TJob, TConfig>(TJob job, T1[] itemArray1, TConfig config)
            where TJob : struct, IJobParallelForExt<T1>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return RunIJobParallelFor(job, new InputData<T1>(itemArray1), config);
        }

        internal static IWorkWrapper RunINonJob<TJob, TConfig>(TJob job, IInputData<T1> data, TConfig config = null)
            where TJob : struct, INonJobExt<T1>
            where TConfig : class, IWorkConfigINonJob
        {
            return new NonJobWrapper<IArrayContainer<TConfig, T1>, IInputData<T1>, TJob, TConfig, T1>(job, data,
                config);
        }

        public static IWorkWrapper RunINonJob<TJob>(TJob job, T1[] itemArray1)
            where TJob : struct, INonJobExt<T1>
        {
            return RunINonJob(job, new InputData<T1>(itemArray1), new WorkConfigINonJob());
        }
    }
}