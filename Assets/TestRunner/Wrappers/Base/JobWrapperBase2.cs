using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;

namespace TestRunner.Wrappers.Base
{
    internal abstract class
        JobWrapperBase<TDataContainer, TData, TJob, T1, T2> : JobWrapperBase<TDataContainer, TData, TJob, T1>
        where T1 : struct
        where T2 : struct
        where TData : class, IInputData<T1, T2>
        where TDataContainer : class, IDataContainer<T1, T2>
        where TJob : struct, IJobBase<T1, T2>
    {
        protected JobWrapperBase(TJob job, TData data) : base(job, data)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new DataContainer<T1, T2>(data.ItemArray1, data.ItemArray2) as TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Job.Data2 = DataContainer.Item2;
        }
    }
}