using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Jobs;

namespace TestRunner.Wrappers.Base
{
    internal abstract class
        JobWrapperBase<TDataContainer, TData, TJob, T1, T2, T3, T4> : JobWrapperBase<TDataContainer, TData, TJob, T1, T2
            , T3>
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where TData : class, IInputData<T1, T2, T3, T4>
        where TDataContainer : class, IDataContainer<T1, T2, T3, T4>
        where TJob : struct, IJobBase<T1, T2, T3, T4>
    {
        protected JobWrapperBase(TJob job, TData data) : base(job, data)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new DataContainer<T1, T2, T3, T4>(data.ItemArray1, data.ItemArray2, data.ItemArray3, data.ItemArray4)
                as TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Job.Data4 = DataContainer.Item4;
        }
    }
}