using TestRunner.DataContainer;
using TestRunner.InputData;
using TestRunner.Workers.Base;
using TestRunner.Wrappers.Base.Config;
using UnityEngine.Profiling;

namespace TestRunner.Wrappers.Base
{
    internal abstract class WorkWrapper<TDataContainer, TData, TWorker, TConfig> : IWorkWrapper
        where TDataContainer : class, IDataContainer<TConfig>
        where TData : class, IInputData
        where TWorker : struct, IWorker
        where TConfig : class, IWorkConfig
    {
        private const string TestNamePrefix = "TestRunner";

        protected readonly TDataContainer DataContainer;
        protected TWorker Worker;

        private readonly TConfig _config;
        private readonly string _testName;

        protected WorkWrapper(string testName, TWorker worker, TData data, TConfig config = null)
        {
            Worker = worker;
            DataContainer = GetDataContainer(data);
            _config = config;
            _testName = testName;
        }

        private TDataContainer GetDataContainer(TData data)
        {
            return InitDataContainer(data);
        }

        protected abstract TDataContainer InitDataContainer(TData data);

        public void Run()
        {
            InitData(_config);
            InitJob();
            BeginTracking();
            TestCase(_config);
            EndTracking();
            CleanUpJob();
            CleanUpData();
        }

        private void InitData(TConfig config)
        {
            DataContainer.Init(config);
        }

        private void CleanUpData()
        {
            DataContainer.Dispose();
        }

        protected virtual void InitJob()
        {
            Worker.Init();
        }

        protected virtual void CleanUpJob()
        {
            Worker.Dispose();
        }

        protected abstract void TestCase(TConfig config);

        private void BeginTracking()
        {
            Profiler.BeginSample($"|{TestNamePrefix}| {_testName}: {Worker.GetType().Name} {_config}");
        }

        private void EndTracking()
        {
            Profiler.EndSample();
        }

        public void Dispose()
        {
            CleanUpData();
            CleanUpJob();
        }
    }
}