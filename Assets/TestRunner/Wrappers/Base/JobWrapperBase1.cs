using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;

namespace TestRunner.Wrappers.Base
{
    internal abstract class
        JobWrapperBase<TDataContainer, TData, TJob, T1> : JobWrapperBase<TDataContainer, TData, TJob>
        where T1 : struct
        where TData : class, IInputData<T1>
        where TDataContainer : class, IDataContainer<T1>
        where TJob : struct, IJobBase<T1>
    {
        protected JobWrapperBase(ref TJob job, ref TData data) : base(ref job, ref data)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new DataContainer<T1>(data.ItemArray1) as TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Job.DataSize = DataContainer.DataSize;
            Job.Data1 = DataContainer.Item1;
        }
    }
}