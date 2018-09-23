using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TestWrapper.Facades;
using Unity.PerformanceTesting;
using WorkSpace.Provider;
using WorkSpace.Provider.Settings;

namespace TestRunnerPerformance
{
    [Category("Performance")]
    internal class TestRunner
    {
        private ITestProvider _testProvider;
        private ITestSettings _testSettings;

        [PerformanceTest]
        public void TestRunner_Workers()
        {
            for (var index = 0; index < _testProvider.WorkFacades.Length; index++)
            {
                var workFacade = _testProvider.WorkFacades[index];

                #region FirstRun

                MainWork(workFacade, index.ToString(), true);

                #endregion

                #region WarmUp

                for (var i = 0; i < _testSettings.WarmUpCount; i++)
                {
                    MainWork(workFacade, index.ToString(), measure: false);
                }

                #endregion

                #region TestCase

                for (var i = 0; i < _testSettings.TotalRuns; i++)
                {
                    MainWork(workFacade, index.ToString());
                }

                #endregion
            }
        }

        [SetUp]
        public void SetUp()
        {
            _testSettings = Utils.LoadTestSettings();
            _testProvider = new TestProvider(_testSettings);
        }

        [TearDown]
        public void TearDown()
        {
            var context = TestContext.CurrentTestExecutionContext;
            if (Equals(context.CurrentResult.ResultState, ResultState.Success))
            {
                var data = Utils.ParsePerformanceTestData(context.CurrentResult.Output);
                var performanceTest = Utils.GetPerformanceTest(data);
                var testRunnerResults = ParsePerformanceTest(performanceTest);
                var json = Utils.CreateTestRunnerResultJson(testRunnerResults);
                TestContext.WriteLine(Utils.TestRunnerPrefix + json);
            }
        }

        private void MainWork(IWorkFacade workFacade, string name, bool firstRun = false, bool measure = true)
        {
            workFacade.SetUp();
            if (measure)
            {
                using (Measure.Scope(new SampleGroupDefinition(
                    Utils.DefinitionName(name, firstRun ? Utils.FirstKeyWord : string.Empty),
                    _testSettings.SampleUnit)))
                {
                    workFacade.Run();
                }
            }
            else
            {
                workFacade.Run();
            }

            workFacade.CleanUp();
        }

        private TestRunnerResult[] ParsePerformanceTest(PerformanceTest performanceTest)
        {
            var results = new List<TestRunnerResult>();
            for (var i = 0; i < _testProvider.WorkFacades.Length; i++)
            {
                var workFacade = _testProvider.WorkFacades[i];
                var sampleGroup = performanceTest.SampleGroups.First(group =>
                    group.Definition.Name.Equals(Utils.DefinitionName(i.ToString())));
                var firstSampleGroup = performanceTest.SampleGroups.First(group =>
                    group.Definition.Name.Equals(Utils.DefinitionName(i.ToString(), Utils.FirstKeyWord)));
                results.Add(
                    new TestRunnerResult
                    {
                        BaseSetUp = new TestRunnerResult._Base
                        {
                            TestName = workFacade.Info().TestName,
                            DataSize = _testSettings.DataSize,
                            TotalRuns = _testSettings.TotalRuns
                        },
                        Worker = new TestRunnerResult._Worker
                        {
                            Name = workFacade.Info().InfoWorker.Name,
                            NameSpace = workFacade.Info().InfoWorker.Namespace,
                            JobType = workFacade.Info().InfoWorker.JobType,
                            Config = workFacade.Info().InfoWorker.Config,
                            Data = workFacade.Info().InfoDataArray.ToString()
                        },
                        TestResults = new TestRunnerResult._Results
                        {
                            First = Math.Round(firstSampleGroup.Min, _testSettings.ResultsPrecision),
                            Min = Math.Round(sampleGroup.Min, _testSettings.ResultsPrecision),
                            Max = Math.Round(sampleGroup.Max, _testSettings.ResultsPrecision),
                            Median = Math.Round(sampleGroup.Median, _testSettings.ResultsPrecision),
                            Average = Math.Round(sampleGroup.Average, _testSettings.ResultsPrecision),
                            StandardDeviation = Math.Round(sampleGroup.StandardDeviation,
                                _testSettings.ResultsPrecision)
                        }
                    }
                );
            }

            return results.ToArray();
        }
    }
}