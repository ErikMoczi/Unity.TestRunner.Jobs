using TestRunner.DataContainer.Array;
using TestRunner.InputData;
using TestRunner.Workers;
using TestRunner.Workers.Extensions;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;

namespace TestRunner.Wrappers.INonJob
{
    internal class
        NonJobWrapper<TDataContainer, TData, TWorker, TConfig, T1> : WorkWrapper<TDataContainer, TData, TWorker, TConfig
        >
        where TDataContainer : class, IArrayContainer<TConfig, T1>
        where TData : class, IInputData<T1>
        where TWorker : struct, INonJobExt<T1>
        where TConfig : class, IWorkConfigINonJob
        where T1 : struct
    {
        public NonJobWrapper(string testName, TWorker worker, TData data, TConfig config) : base(testName, worker, data,
            config)
        {
        }

        protected override TDataContainer InitDataContainer(TData data)
        {
            return new ArrayContainer<TConfig, T1>(data.ItemArray1) as TDataContainer;
        }

        protected override void InitJob()
        {
            base.InitJob();
            Worker.DataSize = DataContainer.DataSize;
            Worker.Data1 = DataContainer.Item1;
        }

        protected override void TestCase(TConfig config)
        {
            Worker.RunTest(config);
        }
    }
}