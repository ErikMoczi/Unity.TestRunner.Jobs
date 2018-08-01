using TestRunner.DataContainer.Struct;
using TestRunner.InputData;
using TestRunner.Workers.Base;
using TestRunner.Wrappers.Base.Config;

namespace TestRunner.Wrappers.Base.Job
{
    internal abstract class
        JobWrapperBase<TDataContainer, TData, TWorker, TConfig, T1> : WorkWrapper<TDataContainer, TData, TWorker,
            TConfig>
        where TDataContainer : class, IStructContainer<TConfig, T1>
        where TData : class, IInputData<T1>
        where TWorker : struct, IJobBase<T1>
        where TConfig : class, IWorkConfigIJob
        where T1 : struct
    {
        protected JobWrapperBase(string testName, TWorker worker, TData data, TConfig config) : base(testName, worker,
            data, config)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new StructContainer<TConfig, T1>(data.ItemArray1) as TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Worker.DataSize = DataContainer.DataSize;
            Worker.Data1 = DataContainer.Item1;
        }
    }
}