using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Unity.PerformanceTesting;
using UnityEngine;
using WorkSpace.Provider;
using WorkSpace.Provider.Settings;

namespace TestRunnerPerformance
{
    [Category("Performance")]
    public class TestRunner
    {
        private const string TestSettingsAsset = "TestSettings";
        private const string FirstKeyWord = "_First";
        private const string DefinitionPrefix = "#";
        private const string PerformanceTestPrefix = "##performancetestresult:";
        private const string TestRunnerPrefix = "##testrunnerresult:";

        private TestProvider _testProvider;
        private TestSettings _testSettings;

        [PerformanceTest]
        public void TestRunner_Workers()
        {
            for (var index = 0; index < _testProvider.WorkFacades.Length; index++)
            {
                var workFacade = _testProvider.WorkFacades[index];

                #region FirstRun

                workFacade.SetUp();
                using (Measure.Scope(new SampleGroupDefinition(DefinitionName(index, FirstKeyWord))))
                {
                    workFacade.Run();
                }

                workFacade.CleanUp();

                #endregion

                #region WarmUp

                for (var i = 0; i < _testSettings.WarmUpCount; i++)
                {
                    workFacade.SetUp();
                    workFacade.Run();
                    workFacade.CleanUp();
                }

                #endregion

                #region TestCase

                for (var i = 0; i < _testSettings.TotalRuns; i++)
                {
                    workFacade.SetUp();
                    using (Measure.Scope(new SampleGroupDefinition(DefinitionName(index))))
                    {
                        workFacade.Run();
                    }

                    workFacade.CleanUp();
                }

                #endregion
            }
        }

        [SetUp]
        public void Setup()
        {
            _testSettings = LoadTestSettings();
            _testProvider = new TestProvider(_testSettings);
        }

        [TearDown]
        public void TearDown()
        {
            var context = TestContext.CurrentTestExecutionContext;
            if (Equals(context.CurrentResult.ResultState, ResultState.Success))
            {
                var data = ParseTestData(context.CurrentResult.Output);
                var performanceTest = GetPerformanceTest(data);
                var testRunnerResults = ParsePerformanceTest(performanceTest);
                var json = CreateTestRunnerResultJson(testRunnerResults);
                TestContext.WriteLine(TestRunnerPrefix + json);
            }
        }

        private string ParseTestData(string data)
        {
            var performanceData = Regex.Match(data, $@"{PerformanceTestPrefix}[^\n]+$");
            if (performanceData.Success & performanceData.Groups.Count == 1)
            {
                return performanceData.Groups[0].Value.Trim().Replace(PerformanceTestPrefix, string.Empty);
            }

            throw new Exception(
                $"Problem with parsing performance test data, check Unity API {typeof(PerformanceTest)}"
            );
        }

        private PerformanceTest GetPerformanceTest(string jsonData)
        {
            return JsonUtility.FromJson<PerformanceTest>(jsonData);
        }

        private string CreateTestRunnerResultJson(TestRunnerResult[] testRunnerResults)
        {
            var data = new Wrapper<TestRunnerResult> {data = testRunnerResults};
            return JsonUtility.ToJson(data);
        }

        private TestRunnerResult[] ParsePerformanceTest(PerformanceTest performanceTest)
        {
            var results = new List<TestRunnerResult>();
            for (var i = 0; i < _testProvider.WorkFacades.Length; i++)
            {
                var workFacade = _testProvider.WorkFacades[i];
                var sampleGroup =
                    performanceTest.SampleGroups.First(group => group.Definition.Name.Equals(DefinitionName(i)));
                var firstSampleGroup = performanceTest.SampleGroups.First(group =>
                    group.Definition.Name.Equals(DefinitionName(i, FirstKeyWord)));
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
                            First = Math.Round(firstSampleGroup.Min, 2),
                            Min = Math.Round(sampleGroup.Min, 2),
                            Max = Math.Round(sampleGroup.Max, 2),
                            Median = Math.Round(sampleGroup.Median, 2),
                            Average = Math.Round(sampleGroup.Average, 2),
                            StandardDeviation = Math.Round(sampleGroup.StandardDeviation, 2)
                        }
                    }
                );
            }

            return results.ToArray();
        }

        private string DefinitionName(int index, string suffix = "")
        {
            return $"{DefinitionPrefix}{index}{(!string.IsNullOrEmpty(suffix) ? suffix : "")}";
        }

        private TestSettings LoadTestSettings()
        {
            return Resources.Load<TestSettings>(TestSettingsAsset);
        }
    }
}