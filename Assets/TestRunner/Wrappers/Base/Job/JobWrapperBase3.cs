using TestRunner.DataContainer.Struct;
using TestRunner.InputData;
using TestRunner.Workers.Base;
using TestRunner.Wrappers.Base.Config;

namespace TestRunner.Wrappers.Base.Job
{
    internal abstract class
        JobWrapperBase<TDataContainer, TData, TWorker, TConfig, T1, T2, T3> : JobWrapperBase<TDataContainer, TData,
            TWorker, TConfig, T1, T2>
        where TDataContainer : class, IStructContainer<TConfig, T1, T2, T3>
        where TData : class, IInputData<T1, T2, T3>
        where TWorker : struct, IJobBase<T1, T2, T3>
        where TConfig : class, IWorkConfigIJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        protected JobWrapperBase(string testName, TWorker worker, TData data, TConfig config) : base(testName, worker,
            data, config)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new StructContainer<TConfig, T1, T2, T3>(data.ItemArray1, data.ItemArray2, data.ItemArray3) as
                TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Worker.Data3 = DataContainer.Item3;
        }
    }
}