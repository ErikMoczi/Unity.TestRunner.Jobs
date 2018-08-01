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
    public static class WorkerTests<T1, T2, T3, T4, T5>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        internal static IWorkWrapper RunIJob<TWorker, TConfig>(string testName, TWorker worker,
            IInputData<T1, T2, T3, T4, T5> data, TConfig config)
            where TWorker : struct, IJobExt<T1, T2, T3, T4, T5>
            where TConfig : class, IWorkConfigIJob
        {
            return new JobWrapper<IStructContainer<TConfig, T1, T2, T3, T4, T5>, IInputData<T1, T2, T3, T4, T5>, TWorker
                , TConfig, T1, T2, T3, T4, T5>(testName, worker, data, config);
        }

        public static IWorkWrapper RunIJob<TWorker, TConfig>(string testName, TWorker worker, T1[] itemArray1,
            T2[] itemArray2, T3[] itemArray3, T4[] itemArray4, T5[] itemArray5, TConfig config)
            where TWorker : struct, IJobExt<T1, T2, T3, T4, T5>
            where TConfig : class, IWorkConfigIJob
        {
            return RunIJob(testName, worker,
                new InputData<T1, T2, T3, T4, T5>(itemArray1, itemArray2, itemArray3, itemArray4, itemArray5), config);
        }

        internal static IWorkWrapper RunIJobParallelFor<TWorker, TConfig>(string testName, TWorker worker,
            IInputData<T1, T2, T3, T4, T5> data, TConfig config)
            where TWorker : struct, IJobParallelForExt<T1, T2, T3, T4, T5>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return new JobParallelForWrapper<IStructContainer<TConfig, T1, T2, T3, T4, T5>,
                IInputData<T1, T2, T3, T4, T5>, TWorker, TConfig, T1, T2, T3, T4, T5>(testName, worker, data, config);
        }

        public static IWorkWrapper RunIJobParallelFor<TWorker, TConfig>(string testName, TWorker worker,
            T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4, T5[] itemArray5, TConfig config)
            where TWorker : struct, IJobParallelForExt<T1, T2, T3, T4, T5>
            where TConfig : class, IWorkConfigIJobParallelFor
        {
            return RunIJobParallelFor(testName, worker,
                new InputData<T1, T2, T3, T4, T5>(itemArray1, itemArray2, itemArray3, itemArray4, itemArray5), config);
        }

        internal static IWorkWrapper RunINonJob<TWorker, TConfig>(string testName, TWorker worker,
            IInputData<T1, T2, T3, T4, T5> data, TConfig config)
            where TWorker : struct, INonJobExt<T1, T2, T3, T4, T5>
            where TConfig : class, IWorkConfigINonJob
        {
            return new NonJobWrapper<IArrayContainer<TConfig, T1, T2, T3, T4, T5>, IInputData<T1, T2, T3, T4, T5>,
                TWorker, TConfig, T1, T2, T3, T4, T5>(testName, worker, data, config);
        }

        public static IWorkWrapper RunINonJob<TWorker>(string testName, TWorker worker, T1[] itemArray1,
            T2[] itemArray2, T3[] itemArray3, T4[] itemArray4, T5[] itemArray5)
            where TWorker : struct, INonJobExt<T1, T2, T3, T4, T5>
        {
            return RunINonJob(testName, worker,
                new InputData<T1, T2, T3, T4, T5>(itemArray1, itemArray2, itemArray3, itemArray4, itemArray5),
                new WorkConfigINonJob());
        }
    }
}