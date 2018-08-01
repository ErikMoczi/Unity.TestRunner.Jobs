using TestRunner.DataContainer.Array;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Wrappers.Base.Config;

namespace TestRunner.Wrappers.INonJob
{
    internal class
        NonJobWrapper<TDataContainer, TData, TWorker, TConfig, T1, T2, T3, T4, T5> : NonJobWrapper<TDataContainer, TData
            , TWorker, TConfig, T1, T2, T3, T4>
        where TDataContainer : class, IArrayContainer<TConfig, T1, T2, T3, T4, T5>
        where TData : class, IInputData<T1, T2, T3, T4, T5>
        where TWorker : struct, INonJobExt<T1, T2, T3, T4, T5>
        where TConfig : class, IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        public NonJobWrapper(TWorker worker, TData data, TConfig config) : base(worker, data, config)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new ArrayContainer<TConfig, T1, T2, T3, T4, T5>(data.ItemArray1, data.ItemArray2,
                data.ItemArray3, data.ItemArray4, data.ItemArray5) as TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Worker.Data5 = DataContainer.Item5;
        }
    }
}