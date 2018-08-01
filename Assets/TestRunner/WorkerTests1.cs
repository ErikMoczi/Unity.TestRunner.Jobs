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
        internal static IWorkWrapper RunIJob<TWorker, TConfig>(string testName, TWorker worker, IInputData<T1> data,
            TConfig config)
            where TWorker : struct, IJobExt<T1>
            where TConfig : class, IWorkConfigIJob
        {
            return new JobWrapper<IStructContainer<TConfig, T1>, IInputData<T1>, TWorker, TConfig, T1>(testName, worker,
                data, config);
        }

        public static IWorkWrapper RunIJob<TWorker, TConfig>(string testName, TWorker worker, T1[] itemArray1,
            TConfig config)
            where TWorker : struct, IJobExt<T1>
            where TConfig : class, IWorkConfigIJob
        {
            return RunIJob(testName, worker, new InputData<T1>(itemArray1), config);
        }

        internal static IWorkWrapper RunIJobParallelFor<TWorker, TConfig>(string testName, TWorker worker,
            IInputData<T1> data, TConfig config)
            where TWorker : struct, IJobParallelForExt<T1>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return new JobParallelForWrapper<IStructContainer<TConfig, T1>, IInputData<T1>, TWorker, TConfig, T1>(
                testName, worker, data, config);
        }

        public static IWorkWrapper RunIJobParallelFor<TWorker, TConfig>(string testName, TWorker worker,
            T1[] itemArray1, TConfig config)
            where TWorker : struct, IJobParallelForExt<T1>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return RunIJobParallelFor(testName, worker, new InputData<T1>(itemArray1), config);
        }

        internal static IWorkWrapper RunINonJob<TWorker, TConfig>(string testName, TWorker worker, IInputData<T1> data,
            TConfig config = null)
            where TWorker : struct, INonJobExt<T1>
            where TConfig : class, IWorkConfigINonJob
        {
            return new NonJobWrapper<IArrayContainer<TConfig, T1>, IInputData<T1>, TWorker, TConfig, T1>(testName,
                worker, data, config);
        }

        public static IWorkWrapper RunINonJob<TWorker>(string testName, TWorker worker, T1[] itemArray1)
            where TWorker : struct, INonJobExt<T1>
        {
            return RunINonJob(testName, worker, new InputData<T1>(itemArray1), new WorkConfigINonJob());
        }
    }
}