using TestRunner.DataContainer.Struct;
using TestRunner.InputData;
using TestRunner.Workers.Base;
using TestRunner.Wrappers.Base.Config;

namespace TestRunner.Wrappers.Base.Job
{
    internal abstract class
        JobWrapperBase<TDataContainer, TData, TWorker, TConfig, T1, T2, T3, T4> : JobWrapperBase<TDataContainer, TData,
            TWorker, TConfig, T1, T2, T3>
        where TDataContainer : class, IStructContainer<TConfig, T1, T2, T3, T4>
        where TData : class, IInputData<T1, T2, T3, T4>
        where TWorker : struct, IJobBase<T1, T2, T3, T4>
        where TConfig : class, IWorkConfigIJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        protected JobWrapperBase(TWorker worker, TData data, TConfig config) : base(worker, data, config)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new StructContainer<TConfig, T1, T2, T3, T4>(data.ItemArray1, data.ItemArray2, data.ItemArray3,
                data.ItemArray4) as TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Worker.Data4 = DataContainer.Item4;
        }
    }
}