using System;
using System.Text;
using UnityEngine.Profiling;

namespace TestRunner.Facades
{
    internal sealed class TestFacade<TWorkFacade> : ITestFacade
        where TWorkFacade : class, IWorkFacade
    {
        private const string TestNamePrefix = "TestRunner";

        private readonly TWorkFacade _workFacade;
        private readonly string _testName;

        public TestFacade(string testName, TWorkFacade workFacade)
        {
            _workFacade = workFacade;
            _testName = testName;
        }

        public void Run()
        {
            try
            {
                InitWorkFacade();
                BeginTracking();
                TestCase();
                EndTracking();
                CleanUpWorkFacade();
            }
            catch (Exception e)
            {
                var worker = _workFacade.SetUp().Worker;
                throw new Exception($"Problem with running {_testName} - {worker.Name}|{worker.JobType}", e);
            }
        }

        private void InitWorkFacade()
        {
            _workFacade.Init();
        }

        private void CleanUpWorkFacade()
        {
            _workFacade.Dispose();
        }

        public void TestCase()
        {
            _workFacade.Run();
        }

        private void BeginTracking()
        {
            Profiler.BeginSample($"|{TestNamePrefix}| {_testName}: {SetUpData()}");
        }

        private void EndTracking()
        {
            Profiler.EndSample();
        }

        public void Dispose()
        {
            CleanUpWorkFacade();
        }


        private string FormatConfig(string config)
        {
            return string.IsNullOrEmpty(config) ? string.Empty : $"({config})";
        }

        private string SetUpData()
        {
            var workerWrapperSetUp = _workFacade.SetUp();

            var workerSetUp = workerWrapperSetUp.Worker;
            var multiContainerSetUps = workerWrapperSetUp.MultiContainer;

            var workerConfig = $"{workerSetUp.Name}<{workerSetUp.JobType}>{FormatConfig(workerSetUp.Config)}";

            var dataStructureConfig = new StringBuilder();
            for (int i = 0; i < multiContainerSetUps.Length; i++)
            {
                dataStructureConfig.Append(
                    $"{multiContainerSetUps[i].Name}{FormatConfig(multiContainerSetUps[i].Config)}"
                );
                if (i != multiContainerSetUps.Length - 1)
                {
                    dataStructureConfig.Append(", ");
                }
            }

            return $"{workerConfig} {{{dataStructureConfig}}}";
        }
    }
}