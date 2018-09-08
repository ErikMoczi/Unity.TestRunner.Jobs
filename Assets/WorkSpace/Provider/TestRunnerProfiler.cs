using System;
using TestWrapper.Facades;
using TestWrapper.Facades.Info;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Provider
{
    public sealed class TestRunnerProfiler : MonoBehaviour
    {
        private const string TestNamePrefix = "TestRunner";

        [Header("Delay specific frames from start")] [SerializeField] [Range(0, 10)]
        private int _delayFrames = 3;

        [Header("Pause unity after finished test case")] [SerializeField] [Range(0, 10)]
        private int _pauseAfterFinishFrames = 5;

        [SerializeField] private TestSettings _testSettings;

        [NonSerialized] private TestProvider _testProvider;

        private int _currentRun;

        private void Awake()
        {
            _testProvider = new TestProvider(_testSettings);
        }

        private void Update()
        {
            if (_delayFrames + 1 > Time.frameCount)
            {
                return;
            }

            if (_testSettings.TotalRuns > _currentRun)
            {
                foreach (var workFacade in _testProvider.WorkFacades)
                {
                    TestCase(workFacade);
                }

                _currentRun++;
            }

            if (Time.frameCount > _pauseAfterFinishFrames + _delayFrames + 1 + _testSettings.TotalRuns)
            {
                EditorApplication.isPaused = true;
            }
        }

        private void TestCase(IWorkFacade workFacade)
        {
            workFacade.SetUp();
            BeginTracking(workFacade.Info());
            workFacade.Run();
            EndTracking();
            workFacade.CleanUp();
        }

        private void BeginTracking(IWorkWrapperInfo info)
        {
            Profiler.BeginSample($"|{TestNamePrefix}| {info}");
        }

        private void EndTracking()
        {
            Profiler.EndSample();
        }
    }
}