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
        internal static IWorkWrapper RunIJob<TWorker, TConfig>(string testName, TWorker worker, IInputData<T1, T2> data,
            TConfig config)
            where TWorker : struct, IJobExt<T1, T2>
            where TConfig : class, IWorkConfigIJob
        {
            return new JobWrapper<IStructContainer<TConfig, T1, T2>, IInputData<T1, T2>, TWorker, TConfig, T1, T2>(
                testName, worker, data, config);
        }

        public static IWorkWrapper RunIJob<TWorker, TConfig>(string testName, TWorker worker, T1[] itemArray1,
            T2[] itemArray2, TConfig config)
            where TWorker : struct, IJobExt<T1, T2>
            where TConfig : class, IWorkConfigIJob
        {
            return RunIJob(testName, worker, new InputData<T1, T2>(itemArray1, itemArray2), config);
        }

        internal static IWorkWrapper RunIJobParallelFor<TWorker, TConfig>(string testName, TWorker worker,
            IInputData<T1, T2> data, TConfig config)
            where TWorker : struct, IJobParallelForExt<T1, T2>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return new JobParallelForWrapper<IStructContainer<TConfig, T1, T2>, IInputData<T1, T2>, TWorker, TConfig, T1
                , T2>(testName, worker, data, config);
        }

        public static IWorkWrapper RunIJobParallelFor<TWorker, TConfig>(string testName, TWorker worker,
            T1[] itemArray1, T2[] itemArray2, TConfig config)
            where TWorker : struct, IJobParallelForExt<T1, T2>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return RunIJobParallelFor(testName, worker, new InputData<T1, T2>(itemArray1, itemArray2), config);
        }

        internal static IWorkWrapper RunINonJob<TWorker, TConfig>(string testName, TWorker worker,
            IInputData<T1, T2> data, TConfig config = null)
            where TWorker : struct, INonJobExt<T1, T2>
            where TConfig : class, IWorkConfigINonJob
        {
            return new NonJobWrapper<IArrayContainer<TConfig, T1, T2>, IInputData<T1, T2>, TWorker, TConfig, T1, T2>(
                testName, worker, data, config);
        }

        public static IWorkWrapper RunINonJob<TWorker>(string testName, TWorker worker, T1[] itemArray1,
            T2[] itemArray2)
            where TWorker : struct, INonJobExt<T1, T2>
        {
            return RunINonJob(testName, worker, new InputData<T1, T2>(itemArray1, itemArray2), new WorkConfigINonJob());
        }
    }
}