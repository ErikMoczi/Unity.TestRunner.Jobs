using TestRunner.DataContainer.Array;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Wrappers.Base.Config;

namespace TestRunner.Wrappers.INonJob
{
    internal class
        NonJobWrapper<TDataContainer, TData, TWorker, TConfig, T1, T2, T3> : NonJobWrapper<TDataContainer, TData,
            TWorker, TConfig, T1, T2>
        where TDataContainer : class, IArrayContainer<TConfig, T1, T2, T3>
        where TData : class, IInputData<T1, T2, T3>
        where TWorker : struct, INonJobExt<T1, T2, T3>
        where TConfig : class, IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        public NonJobWrapper(string testName, TWorker worker, TData data, TConfig config) : base(testName, worker, data,
            config)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new ArrayContainer<TConfig, T1, T2, T3>(data.ItemArray1, data.ItemArray2, data.ItemArray3) as
                TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Worker.Data3 = DataContainer.Item3;
        }
    }
}